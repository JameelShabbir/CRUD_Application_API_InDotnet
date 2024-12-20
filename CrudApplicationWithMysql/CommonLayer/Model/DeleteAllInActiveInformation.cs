using System.ComponentModel.DataAnnotations;

namespace CrudApplicationWithMysql.CommonLayer.Model
{
 
    public class DeleteAllInActiveInformationResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
