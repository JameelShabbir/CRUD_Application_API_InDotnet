namespace CrudApplicationWithMysql.CommonLayer.Model
{
    public class ReadAllInformationResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetReadAllInformation> ReadAllInformation { get; set; }
    }
    public class GetReadAllInformation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string Gendar { get; set; }
        public bool IsActive { get; set; }


    }

}
