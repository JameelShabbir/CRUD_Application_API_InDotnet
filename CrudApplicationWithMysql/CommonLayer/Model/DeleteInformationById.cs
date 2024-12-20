using System.ComponentModel.DataAnnotations;

namespace CrudApplicationWithMysql.CommonLayer.Model
{

    public class DeleteInformationByIdRequest
    {
        [Required(ErrorMessage = "User id is required.")]
        public int UserId { get; set; }

    }

    public class DeleteInformationByIdResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
