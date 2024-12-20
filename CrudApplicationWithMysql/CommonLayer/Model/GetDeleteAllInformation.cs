namespace CrudApplicationWithMysql.CommonLayer.Model
{

    public class GetDeleteAllInformationResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetDeleteAllInformation> GetDeleteAllInformation { get; set; }
    }

    public class GetDeleteAllInformation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string Gendar { get; set; }
    }


}
