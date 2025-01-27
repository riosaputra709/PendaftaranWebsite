using APIRegistration.Models.Request;
using APIRegistration.Repositories.Base;
using System.Data.SqlClient;

namespace APIRegistration.Repositories
{
    public class RegistrationRepository : BaseRepository
    {
        public static RegistrationRepository instance = null;
        public static RegistrationRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegistrationRepository();
                }
                return instance;
            }
        }

        internal void SimpanRegistration(RequestRegistration req, string npwpFile, string powerOfAttorneyFile)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            try
            {
                string query = @"INSERT INTO pendaftarantable (companyName, npwp, directorName, picName, email, phoneNumber, npwpFile, powerOfAttorneyFile)" +
                                " VALUES (@companyName, @npwp, @directorName, @picName, @email, @phoneNumber, @npwpFile, @powerOfAttorneyFile)";

                SqlCommand comm = new SqlCommand(query, sqlConnection);
                comm.Parameters.AddWithValue("@companyName", req.companyName);
                comm.Parameters.AddWithValue("@npwp", req.npwp);
                comm.Parameters.AddWithValue("@directorName", req.directorName);
                comm.Parameters.AddWithValue("@picName", req.picName);
                comm.Parameters.AddWithValue("@email", req.email);
                comm.Parameters.AddWithValue("@phoneNumber", req.phoneNumber);
                comm.Parameters.AddWithValue("@npwpFile", npwpFile);
                comm.Parameters.AddWithValue("@powerOfAttorneyFile", powerOfAttorneyFile);

                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
