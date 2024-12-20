using CrudApplicationWithMysql.CommonLayer.Model;

namespace CrudApplicationWithMysql.RepositoryLayer
{
    public interface ICrudApplicationRL
    {
        public Task<AddInformationResponce> AddInformation(AddInformationRequest request);

        public Task<ReadAllInformationResponce> ReadAllInformation();

        public Task<UpdateAllInformationByIdRespnce> UpdateAllInformationById(UpdateAllInformationByIdRequest request);

        public Task<DeleteInformationByIdResponce> DeleteInformationById(DeleteInformationByIdRequest request);
        public Task<GetDeleteAllInformationResponce> GetDeleteAllInformation();

        public Task<DeleteAllInActiveInformationResponce> DeleteAllInActiveInformation();

        public Task<ReadInformationByIdResponce> ReadInformationById(ReadInformationByIdRequest request);

        public Task<UpdateOnceInformationByIdResponce> UpdateOnceInformationById(UpdateOnceInformationByIdRequest request);


    }
}
