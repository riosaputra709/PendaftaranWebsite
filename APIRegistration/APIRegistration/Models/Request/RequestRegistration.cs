using System.ComponentModel.DataAnnotations;

namespace APIRegistration.Models.Request
{
    public class RequestRegistration
    {
        public string companyName {get; set;}

        public string npwp {get; set;}

        public string directorName {get; set;}
        
        public string picName {get; set;}
        
        public string email {get; set;}
        
        public string phoneNumber {get; set;}

        public bool allowAccess { get; set; }
    }
}
