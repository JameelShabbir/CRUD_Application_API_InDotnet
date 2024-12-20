using System.ComponentModel.DataAnnotations;

namespace CrudApplicationWithMysql.CommonLayer.Model
{
    public class UpdateOnceInformationByIdRequest
    {
        [Required(ErrorMessage ="User Id is Mandetory field.")]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Salary is Mandetory field.")]
        public int Salary { get; set; }

    }

    public class UpdateOnceInformationByIdResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }


}
