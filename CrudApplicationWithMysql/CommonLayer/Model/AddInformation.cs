using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CrudApplicationWithMysql.CommonLayer.Model
{
    public class AddInformationRequest
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\\.[a-zA-Z]{2,4}(\\.[a-zA-Z]{2,3})?$",
            ErrorMessage = "Invalid email format. Please enter a valid email, e.g., example@gmail.com.")]
        [BindRequired]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression("^([1-9]{1}[0-9]{9})$",
            ErrorMessage = "Invalid mobile number. Please enter a 10-digit number starting with a non-zero digit.")]
        [BindRequired]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Salary should be greater than zero.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(?:m|M|male|Male|f|F|female|Female)$",
            ErrorMessage = "Invalid gender input. Please enter 'Male', 'Female', 'M', or 'F'.")]
        public string Gendar { get; set; }

    }


    public class AddInformationResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
