using CrudApplicationWithMysql.Common_Utility;
using CrudApplicationWithMysql.CommonLayer.Model;
using MySqlConnector;

namespace CrudApplicationWithMysql.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        public readonly ILogger<CrudApplicationRL> _logger;
        public CrudApplicationRL(IConfiguration configuration, ILogger<CrudApplicationRL> logger)
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDbString"]);
            _logger = logger;
        }

        public async Task<AddInformationResponce> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation("AddInformation method is calling in Repository layer. ");
            AddInformationResponce responce = new AddInformationResponce();
            responce.IsSuccess = true;
            responce.Message = "Successfull";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.AddInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailId", request.EmailId);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gendar", request.Gendar);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if (Status <= 0)
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Query not executed";
                        _logger.LogError("Error Occur : Query not executed.");
                        return responce;
                    }
                };

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"Error occure at AddInformation Repository Layer.{ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }


        public async Task<ReadAllInformationResponce> ReadAllInformation()
        {
            ReadAllInformationResponce responce = new ReadAllInformationResponce();
            responce.IsSuccess = true;
            responce.Message = "Success";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                responce.ReadAllInformation = new List<GetReadAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getdata = new GetReadAllInformation();
                                    getdata.UserId = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    getdata.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    getdata.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    getdata.PhoneNumber = dataReader["PhoneNumber"] != DBNull.Value ? Convert.ToString(dataReader["PhoneNumber"]) : string.Empty;
                                    getdata.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    getdata.Gendar = dataReader["Gendar"] != DBNull.Value ? Convert.ToString(dataReader["Gendar"]) : string.Empty;
                                    getdata.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;

                                    responce.ReadAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                responce.IsSuccess = true;
                                responce.Message = "Data not Found or Database Empty";
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        responce.IsSuccess = false;
                        responce.Message = ex.Message;
                        _logger.LogError("GetAllInformation occure : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError("GetAllInformation occure : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }

        public async Task<UpdateAllInformationByIdRespnce> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateAllInformationById method is calling in Repository layer. ");
            UpdateAllInformationByIdRespnce responce = new UpdateAllInformationByIdRespnce();
            responce.IsSuccess = true;
            responce.Message = "Successfull";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.UpdateAllInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailId", request.EmailId);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if (Status <= 0)
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Query not executed";
                        _logger.LogError("Error Occur : Query not executed.");
                        return responce;
                    }
                };

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"Error occure at UpdateAllInformationById Repository Layer.{ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }

        public async Task<DeleteInformationByIdResponce> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation("DeleteInformationById method is calling in Repository layer. ");
            DeleteInformationByIdResponce responce = new DeleteInformationByIdResponce();
            responce.IsSuccess = true;
            responce.Message = "Successfull";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.DeleteInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if (Status <= 0)
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Query not executed";
                        _logger.LogError("Error Occur : Query not executed.");
                        return responce;
                    }
                };

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"Error occure at DeleteInformationById Repository Layer.{ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }



        public async Task<GetDeleteAllInformationResponce> GetDeleteAllInformation()
        {
            GetDeleteAllInformationResponce responce = new GetDeleteAllInformationResponce();
            responce.IsSuccess = true;
            responce.Message = "Success";

            try
            {
                _logger.LogInformation("GetDeleteAllInformation Data Access Layer calling...");
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetDeleteAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                responce.GetDeleteAllInformation = new List<GetDeleteAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetDeleteAllInformation getdata = new GetDeleteAllInformation();
                                    getdata.UserId = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    getdata.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    getdata.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    getdata.PhoneNumber = dataReader["PhoneNumber"] != DBNull.Value ? Convert.ToString(dataReader["PhoneNumber"]) : string.Empty;
                                    getdata.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    getdata.Gendar = dataReader["Gendar"] != DBNull.Value ? Convert.ToString(dataReader["Gendar"]) : string.Empty;

                                    responce.GetDeleteAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                responce.IsSuccess = true;
                                responce.Message = "Data not Found ";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        responce.IsSuccess = false;
                        responce.Message = ex.Message;
                        _logger.LogError("GetDeleteAllInformation occure : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError("GetDeleteAllInformation occure : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }



        public async Task<DeleteAllInActiveInformationResponce> DeleteAllInActiveInformation()
        {

            _logger.LogInformation("DeleteAllInActiveInformation method is calling in Repository layer. ");
            DeleteAllInActiveInformationResponce responce = new DeleteAllInActiveInformationResponce();
            responce.IsSuccess = true;
            responce.Message = "Successfull";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.DeleteAllInActiveInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if (Status <= 0)
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Query not executed";
                        _logger.LogError("Error Occur : Query not executed.");
                        return responce;
                    }
                };

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"Error occure at DeleteAllInActiveInformation Repository Layer.{ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }



        public async Task<ReadInformationByIdResponce> ReadInformationById(ReadInformationByIdRequest request)
         {
            ReadInformationByIdResponce responce = new ReadInformationByIdResponce();
            responce.IsSuccess = true;
            responce.Message = "Success";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadInformationById, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                responce.Data = new CommonLayer.Model.ReadInformationById();

                                if (await dataReader.ReadAsync())
                                {
                                    responce.Data.UserId = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    responce.Data.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    responce.Data.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    responce.Data.PhoneNumber = dataReader["PhoneNumber"] != DBNull.Value ? Convert.ToString(dataReader["PhoneNumber"]) : string.Empty;
                                    responce.Data.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    responce.Data.Gender = dataReader["Gendar"] != DBNull.Value ? Convert.ToString(dataReader["Gendar"]) : string.Empty;
                                    responce.Data.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;

                                }
                            }
                            else
                            {
                                responce.IsSuccess = true;
                                responce.Message = "Data not Found.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        responce.IsSuccess = false;
                        responce.Message = ex.Message;
                        _logger.LogError("ReadInformationById occure : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError("ReadInformationById occure : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;
        }

        public async Task<UpdateOnceInformationByIdResponce> UpdateOnceInformationById(UpdateOnceInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOnceInformationById method is calling in Repository layer. ");
            UpdateOnceInformationByIdResponce responce = new UpdateOnceInformationByIdResponce();
            responce.IsSuccess = true;
            responce.Message = "Successfull";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new(SqlQueries.UpdateOnceInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if (Status <= 0)
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Query not executed";
                        _logger.LogError("Error Occur : Query not executed.");
                        return responce;
                    }
                };

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
                _logger.LogError($"Error occure at UpdateOnceInformationById Repository Layer.{ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return responce;

        }
    }

}
