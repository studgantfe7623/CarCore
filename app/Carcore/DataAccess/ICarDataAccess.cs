using Carcode.Models;
using MongoDB.Driver;

namespace Carcore.DataAccess
{
    public interface ICarDataAccess
    {
        IMongoCollection<T> ConnectToMongo<T>(in string collection);
        Task<List<CarModel>> getCachedMakes();
        Task<List<CarModel>> getCachedModelsForMake(string selectedMake);
        Task CacheMakes(List<CarModel> makes);
        Task CacheModels(List<CarModel> models);
        void CreateExpireIndex(IMongoCollection<CarModel> collection);
    }
}
