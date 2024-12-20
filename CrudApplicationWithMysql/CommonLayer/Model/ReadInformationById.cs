using System.ComponentModel.DataAnnotations;

namespace CrudApplicationWithMysql.CommonLayer.Model
{
    public class ReadInformationByIdRequest
    {
        [Required(ErrorMessage ="User is is Mandetory")]
        public int UserId { get; set; }
    }

    public class ReadInformationByIdResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ReadInformationById Data { get; set; }
    }

    public class ReadInformationById
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
