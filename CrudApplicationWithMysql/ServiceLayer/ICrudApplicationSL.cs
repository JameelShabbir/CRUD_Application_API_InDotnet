using CrudApplicationWithMysql.CommonLayer.Model;
using CrudApplicationWithMysql.RepositoryLayer;

namespace CrudApplicationWithMysql.ServiceLayer
{
    public interface ICrudApplicationSL
    {
        ICrudApplicationRL CrudApplicationRl { get; }

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
