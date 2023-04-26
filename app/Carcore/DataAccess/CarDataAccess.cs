using MongoDB.Driver;
using Carcode.Models;

namespace Carcore.DataAccess
{
    public class CarDataAccess : ICarDataAccess
    {
        private const string connectionString = "mongodb://127.0.0.1:27017";
        private const string databaseName = "carcore_db";
        private const string MakeCollection = "makes";
        private const string ModelCollection = "models";


        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            return mongoDatabase.GetCollection<T>(collection);
        }


        public async Task<List<CarModel>> getCachedMakes()
        //public async Task<List<CarModel>> getCachedMakes(IMongoCollection<CarModel> cacheCollection)
        {
            var makeCollection = ConnectToMongo<CarModel>(MakeCollection);
            var cachedResults = await makeCollection.FindAsync(_ => true);
            return cachedResults.ToList();
        }

        public async Task<List<CarModel>> getCachedModelsForMake(string selectedMake)
        {
            var modelCollection = ConnectToMongo<CarModel>(ModelCollection);
            var cachedResults = await modelCollection.FindAsync(c => c.Make_Name == selectedMake);
            return cachedResults.ToList();
        }


        public Task CacheMakes(List<CarModel> makes)
        {
            var makeCollection = ConnectToMongo<CarModel>(MakeCollection);
            CreateExpireIndex(makeCollection);

            return makeCollection.InsertManyAsync(makes);
        }

        public Task CacheModels(List<CarModel> models)
        {
            var modelCollection = ConnectToMongo<CarModel>(ModelCollection);
            CreateExpireIndex(modelCollection);

            return modelCollection.InsertManyAsync(models);
        }

        public void CreateExpireIndex(IMongoCollection<CarModel> collection)
        {
            CreateIndexOptions indexOptions = new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(30) };
            IndexKeysDefinition<CarModel> indexKeys = Builders<CarModel>.IndexKeys.Ascending(c => c.CreatedAt);

            collection.Indexes.CreateOne(new CreateIndexModel<CarModel>(indexKeys, indexOptions));
        }

    }
}
