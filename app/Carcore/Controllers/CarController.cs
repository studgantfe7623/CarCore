using Carcode.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MongoDB.Driver;
using Carcore.Models;


namespace Carcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        //private const string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeId/440?format=json";

        private const string connectionString = "mongodb://127.0.0.1:27017";
        private const string databaseName = "carcore_db";
        private const string makeCollection = "makes";
        private readonly IConfiguration _config;

        public CarController(IConfiguration config)
        {
            _config = config;
        }


        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            return mongoDatabase.GetCollection<T>(collection);
        }


        [Route("getAllMakes")]
        [HttpGet]
        public async Task<List<CarModel>> GetAllMakes()
        {
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetAllMakes?format=json";
            List<string> allowedMakes = _config.GetSection("AllowedMakes").Get<List<string>>();

            IMongoCollection<T> _cacheCollection = ConnectToMongo<CarModel>(makeCollection);
            var cachedResponse = await _cacheCollection.FindAsync(_ => true);
            List<CarModel> cachedResponseList = cachedResponse.ToList();
          
            if (cachedResponseListAny())
                return cachedResponseList;
        

            //var cachedResponse = await _cacheCollection.Find(c => c.url == url).FirstOrDefaultAsync();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CarResultModel result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                    List<CarModel> makes = result.Results.Where(m => allowedMakes.Contains(m.Make_Name)).ToList();
                    // cache Api response into mongoDb
                    _cacheCollection.InsertMany(makes);

                    return makes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        // todo: Nach welcher Marke sucht der client?
        [Route("GetModelsForMake")]
        [HttpPost]
        //public async Task<List<CarModel>> GetModelsForMake(Car car)
        public async Task<List<CarModel>> GetModelsForMake([FromBody] string selectedMake)
        {
            //var response = string.Empty;
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/" + selectedMake + "?format=json";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CarResultModel result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                    return result.Results.ToList();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
