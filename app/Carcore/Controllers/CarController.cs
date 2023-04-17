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
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }


        [Route("getAllMakes")]
        [HttpGet]
        public async Task<List<CarModel>> GetAllMakes()
        { 
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetAllMakes?format=json";
            List<string> allowedMakes = _config.GetSection("AllowedMakes").Get<List<string>>();

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
        [HttpGet]
        //public async Task<List<CarModel>> GetModelsForMake(Car car)
        public async Task<List<CarModel>> GetModelsForMake()
        {
            //var response = string.Empty;
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CarResultModel result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                    return result.Results.Take(3).ToList();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
