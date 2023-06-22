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
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ICarDataAccess _db;
        private readonly string baseApiUrl;

        public CarController(HttpClient httpClient, ICarDataAccess db, IConfiguration config)
        {
            _httpClient = httpClient;
            _db = db;
            _config = config;
            baseApiUrl = _config.GetValue<string>("baseApiUrl");
        }


        [Route("getAllMakes")]
        [HttpGet]
        public async Task<List<CarModel>> GetAllMakes()
        {
            string url = baseApiUrl + "GetAllMakes?format=json";
            var allowedMakes = _config.GetSection("AllowedMakes").Get<List<string>>();

            List<CarModel> cachedResponse = await _db.getCachedMakes();

            if (cachedResponse.Any())
                return cachedResponse;


            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                List<CarModel> makes = result.Results.Where(m => allowedMakes.Contains(m.Make_Name)).ToList();
                // Set the CreatedAt property to the current date and time
                makes.ForEach(m => m.CreatedAt = DateTime.Now);
                // cache Api response into mongoDb
                await _db.CacheMakes(makes);

                return makes;
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
        }

        [Route("GetModelsForMake")]
        [HttpPost]
        public async Task<List<CarModel>> GetModelsForMake([FromBody] string selectedMake)
        {
            string url = baseApiUrl + "getmodelsformake/" + selectedMake + "?format=json";

            List<CarModel> cachedResponse = await _db.getCachedModelsForMake(selectedMake);

            if (cachedResponse.Any())
                return cachedResponse;

            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CarResultModel>(responseContent);
                List<CarModel> models = result.Results.ToList();
                // cache Api response into mongoDb
                await _db.CacheModels(models);

                return models;
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
        }
    }
}
