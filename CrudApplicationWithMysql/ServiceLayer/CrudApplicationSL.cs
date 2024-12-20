using CrudApplicationWithMysql.CommonLayer.Model;
using CrudApplicationWithMysql.RepositoryLayer;
using System.Text.RegularExpressions;

namespace CrudApplicationWithMysql.ServiceLayer
{
    public class CrudApplicationSL : ICrudApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRl;
        public readonly ILogger<CrudApplicationSL> _logger;

        /*public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string PhoneNumberRegex = @"^([1-9]{1}[0-9]{9})$";
        public readonly string GendarRegex = @"^(?:m|M|male|Male|f|F|female|Female)$";
*/
       
        public CrudApplicationSL(ICrudApplicationRL crudApplicationRl, ILogger<CrudApplicationSL> logger)
        {
            Console.WriteLine("crud application service layer initilaized");
            _crudApplicationRl = crudApplicationRl;
            _logger = logger;
        }

        public ICrudApplicationRL CrudApplicationRl => _crudApplicationRl;

        public async Task<AddInformationResponce> AddInformation(AddInformationRequest request)
        {
            /*AddInformationResponce responce = new AddInformationResponce();
            if (string.IsNullOrEmpty(request.UserName))
            {
                responce.IsSuccess = false;
                responce.Message = "UserName can't null or Empty";
                return responce;
            }
            if (string.IsNullOrEmpty(request.EmailId))
            {
                responce.IsSuccess = false;
                responce.Message = "Email Id can't null or Empty";
                return responce;
            }
            else
            {
                if (!(Regex.IsMatch(request.EmailId, EmailRegex)))
                {
                    responce.IsSuccess = false;
                    responce.Message = "Invalid email format. Please enter a valid email example: jameel@gmail.com";
                    return responce;
                }
            }
            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                responce.IsSuccess = false;
                responce.Message = "Phone Number can't null or Empty";
                return responce;
            }
            else
            {
                if (!(Regex.IsMatch(request.PhoneNumber, PhoneNumberRegex)))
                {
                    responce.IsSuccess = false;
                    responce.Message = "Invalid mobile number. Please enter a 10-digit number starting with a non-zero digit.";
                    return responce;
                }
            }
            if (request.Salary <= 0)
            {
                responce.IsSuccess = false;
                responce.Message = "Salary can't be less than zero";
                return responce;
            }
            if (string.IsNullOrEmpty(request.Gendar))
            {
                responce.IsSuccess = false;
                responce.Message = "Gendar can't null or empty";
                return responce;
            }
            else
            {
                if (!(Regex.IsMatch(request.Gendar, GendarRegex)))
                {
                    responce.IsSuccess = false;
                    responce.Message = "Invalid gender input. Please enter 'Male', 'Female', 'M', or 'F' (case-insensitive).";
                    return responce;
                }
            }*/

            _logger.LogInformation("AddInformation Method Calling In Service Layer.");
            return await _crudApplicationRl.AddInformation(request);
        }

       
        public async Task<ReadAllInformationResponce> ReadAllInformation()
        {
            _logger.LogInformation("ReadAllInformation Method Calling In Service Layer.");
            return await _crudApplicationRl.ReadAllInformation();
        }

        public async Task<UpdateAllInformationByIdRespnce> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateAllInformationById Method Calling In Service Layer.");
            return await _crudApplicationRl.UpdateAllInformationById(request);
        }


        public async Task<DeleteInformationByIdResponce> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation("DeleteInformationById Method Calling In Service Layer.");
            return await _crudApplicationRl.DeleteInformationById(request);
        }

        public async Task<GetDeleteAllInformationResponce> GetDeleteAllInformation()
        {
            _logger.LogInformation("GetDeleteAllInformation Method Calling In Service Layer.");
            return await _crudApplicationRl.GetDeleteAllInformation();
        }

        public async Task<DeleteAllInActiveInformationResponce> DeleteAllInActiveInformation()
        {
            _logger.LogInformation("DeleteAllInActiveInformation Method Calling In Service Layer.");
            return await _crudApplicationRl.DeleteAllInActiveInformation();
        }

        public async Task<ReadInformationByIdResponce> ReadInformationById(ReadInformationByIdRequest request)
        {
            _logger.LogInformation("ReadInformationById Method Calling In Service Layer.");
            return await _crudApplicationRl.ReadInformationById(request);
        }

        public async Task<UpdateOnceInformationByIdResponce> UpdateOnceInformationById(UpdateOnceInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOnceInformationById Method Calling In Service Layer.");
            return await _crudApplicationRl.UpdateOnceInformationById(request);
        }
    }
}
