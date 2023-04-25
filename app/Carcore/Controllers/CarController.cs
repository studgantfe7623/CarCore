using Carcode.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MongoDB.Driver;
using Carcore.Models;
using Carcore.DataAccess;

namespace Carcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        //private const string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeId/440?format=json";

        private readonly IConfiguration _config;
        private CarDataAccess db;

        public CarController(IConfiguration config)
        {
            _config = config;
            db = new CarDataAccess();
        }



        [Route("getAllMakes")]
        [HttpGet]
        public async Task<List<CarModel>> GetAllMakes()
        {
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetAllMakes?format=json";
            //List<string> allowedMakes = _config.GetSection("AllowedMakes").Get<List<string>>();


            List<string> allowedMakes = new List<string>{
      "AUDI","ALFA","ROMEO","BENTLEY","BMW","BUGATTI","CHEVROLET","FERRARI","FIAT","FORD","HONDA","HYUNDAI","INFINITI",   "JAGUAR",    "KIA",    "KOENIGSEGG",    "KTM",   "LAMBORGHINI",    "LANCIA"   , "LEXUS",   "LOTUS","MAYBACH",   "MAZDA",    "MCLAREN",  "MERCEDES-BENZ", "MINI",    "MITSUBISHI",    "NISSAN",    "OPEL",  "PAGANI",   "PEUGEOT", "POLESTAR",  "PORSCHE",    "ROLLS",    "ROYCE",    "SAAB",   "SMART",    "SUBARU",   "SUZUKI",   "TESLA",    "TOYOTA",    "VOLKSWAGEN",   "VOLVO"
            };

            List<CarModel> cachedResponse = await db.getCachedMakes();

            if (cachedResponse.Any())
                return cachedResponse;

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
                    // Set the CreatedAt property to the current date and time
                    makes.ForEach(m => m.CreatedAt = DateTime.Now);
                    // cache Api response into mongoDb
                    await db.CacheMakes(makes);

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

            List<CarModel> cachedResponse = await db.getCachedModelsForMake(selectedMake);

            if (cachedResponse.Any())
                return cachedResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CarResultModel result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                    List<CarModel> models = result.Results.ToList();
                    // cache Api response into mongoDb
                    await db.CacheModels(models);

                    return models;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
