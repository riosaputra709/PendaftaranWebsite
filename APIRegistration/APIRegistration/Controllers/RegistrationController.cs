using APIRegistration.Models.Request;
using APIRegistration.Models.Response;
using APIRegistration.Repositories;
using APIRegistration.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        RegistrationRepository rr = RegistrationRepository.Instance;

        [Route("AddRegistration")]
        [HttpPost]
        public async Task<ActionResult<ResponseAPI>> AddRegistration([FromForm] RequestRegistration req, IFormFile npwpFile, IFormFile powerOfAttorneyFile)
        {
            ResponseAPI response = new ResponseAPI();
            response.Status = "error";

            try
            {
                //validasi
                if(req.allowAccess == false)
                {
                    response.Message = "Allow access belum di centang";
                    return BadRequest(response);
                }
                if (string.IsNullOrEmpty(req.companyName))
                {
                    response.Message = "Company Name tidak boleh kosong";
                    return BadRequest(response);
                }

                if (string.IsNullOrEmpty(req.npwp))
                {
                    response.Message = "NPWP tidak boleh kosong";
                    return BadRequest(response);
                }

                if (string.IsNullOrEmpty(req.directorName))
                {
                    response.Message = "Director Name tidak boleh kosong";
                    return BadRequest(response);
                }

                if (string.IsNullOrEmpty(req.picName))
                {
                    response.Message = "PIC Name tidak boleh kosong";
                    return BadRequest(response);
                }

                if (string.IsNullOrEmpty(req.email))
                {
                    response.Message = "Email tidak boleh kosong";
                    return BadRequest(response);
                }

                if (string.IsNullOrEmpty(req.phoneNumber))
                {
                    response.Message = "No Telepon tidak boleh kosong";
                    return BadRequest(response);
                }

                if (npwpFile == null)
                {
                    response.Message = "File NPWP tidak boleh kosong";
                    return BadRequest(response);
                }
                if (powerOfAttorneyFile == null)
                {
                    response.Message = "File power Of Attorney tidak boleh kosong";
                    return BadRequest(response);
                }


                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                // Simpan file NPWP
                var npwpFilePath = Path.Combine(uploadDir, npwpFile.FileName);
                using (var stream = new FileStream(npwpFilePath, FileMode.Create))
                {
                    await npwpFile.CopyToAsync(stream);
                }

                // Simpan file Power of Attorney
                var powerOfAttorneyFilePath = Path.Combine(uploadDir, powerOfAttorneyFile.FileName);
                using (var stream = new FileStream(powerOfAttorneyFilePath, FileMode.Create))
                {
                    await powerOfAttorneyFile.CopyToAsync(stream);
                }

                //proses simpan ke database
                rr.SimpanRegistration(req, npwpFile.FileName, powerOfAttorneyFile.FileName);


                //return sukses
                response.Status = "success";
                response.Message = "Berhasil Registrasi";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "error";
                response.Message = ex.Message;
                return StatusCode(500, response);
            }

        }
    }
}
