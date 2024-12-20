using CrudApplicationWithMysql.CommonLayer.Model;
using CrudApplicationWithMysql.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CrudApplicationWithMysql.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        public readonly ICrudApplicationSL _crudApplicationSL;
        public readonly ILogger<CrudApplicationController> _logger;

        public CrudApplicationController(ICrudApplicationSL crudApplicationSL, ILogger<CrudApplicationController> logger)
        {
            _crudApplicationSL = crudApplicationSL;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            AddInformationResponce responce = new AddInformationResponce();
            _logger.LogInformation($"AddInformation API calling in controller...{JsonConvert.SerializeObject(request)}");
            try
            {
                responce = await _crudApplicationSL.AddInformation(request);


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
        }


        [HttpGet]
        public async Task<IActionResult> ReadAllInformation()
        {
            ReadAllInformationResponce responce = new ReadAllInformationResponce();
            _logger.LogInformation($"ReadAllInformation API calling in controller.");
            try
            {
                responce = await _crudApplicationSL.ReadAllInformation();
                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message, Data = responce.ReadAllInformation });
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"ReadAllInformation API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }
            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message, Data = responce.ReadAllInformation });
        }



        [HttpPut]
        public async Task<IActionResult> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdRespnce responce = new UpdateAllInformationByIdRespnce();
            _logger.LogInformation($"UpdateAllInformationById API calling in controller...{JsonConvert.SerializeObject(request)}");
            try
            {
                responce = await _crudApplicationSL.UpdateAllInformationById(request);


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponce responce = new DeleteInformationByIdResponce();
            _logger.LogInformation($"DeleteInformationById API calling in controller...{JsonConvert.SerializeObject(request)}");
            try
            {
                responce = await _crudApplicationSL.DeleteInformationById(request);


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"DeleteInformationById API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
        }




        [HttpGet]
        public async Task<IActionResult> GetDeleteAllInformation()
        {
            GetDeleteAllInformationResponce responce = new GetDeleteAllInformationResponce();
            _logger.LogInformation($"ReadAllInformation API calling in controller.");
            try
            {
                responce = await _crudApplicationSL.GetDeleteAllInformation(); 
                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message, Data = responce.GetDeleteAllInformation });
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"GetDeleteAllInformation API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }
            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message, Data = responce.GetDeleteAllInformation });
        }




        [HttpDelete]
        public async Task<IActionResult> DeleteAllInActiveInformation()
        {
            DeleteAllInActiveInformationResponce responce = new DeleteAllInActiveInformationResponce();
            _logger.LogInformation($"DeleteAllInActiveInformation API calling in controller.");
            try
            {
                responce = await _crudApplicationSL.DeleteAllInActiveInformation(); 


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"DeleteAllInActiveInformation API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
        }




        [HttpPost]
        public async Task<IActionResult> ReadInformationById(ReadInformationByIdRequest request) 
        {
            ReadInformationByIdResponce responce = new ReadInformationByIdResponce();
            _logger.LogInformation($"ReadInformationById API calling in controller...{JsonConvert.SerializeObject(request)}");
            try
            {
                responce = await _crudApplicationSL.ReadInformationById(request);


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"ReadInformationById API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message, data = responce.Data });
        }




        [HttpPatch]
        public async Task<IActionResult> UpdateOnceInformationById(UpdateOnceInformationByIdRequest request)
        {
            UpdateOnceInformationByIdResponce responce = new UpdateOnceInformationByIdResponce();
            _logger.LogInformation($"UpdateOnceInformationById API calling in controller...{JsonConvert.SerializeObject(request)}");
            try
            {
                responce = await _crudApplicationSL.UpdateOnceInformationById(request);


                if (!responce.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"UpdateOnceInformationById API Error Occure : Message {ex.Message} ");
                return BadRequest(new { IsSuccess = responce.IsSuccess, Message = responce.Message });

            }

            return Ok(new { IsSuccess = responce.IsSuccess, Message = responce.Message });
        }


    }
}
