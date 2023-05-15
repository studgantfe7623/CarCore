using Carcode.Models;
using Carcore.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Carcore.Test
{

    //purpose of this test class is to test the internal REST APi
    [TestClass]
    public class IntegrationsTestAPI
    {
        private readonly HttpClient _httpClient;
        private Mock<ICarDataAccess> mockDb;

        public IntegrationsTestAPI()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();

            mockDb = new Mock<ICarDataAccess>();
        }


        [TestMethod]
        public async Task GetAllMakes_ReturnApiResponse()
        {
            //Datenbank muss hier gemoqqt werden damit nix in die DB geschrieben wird
            //mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());

            var response = await _httpClient.GetAsync("api/Car/getAllMakes");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            List<CarModel> models = await response.Content.ReadFromJsonAsync<List<CarModel>>();

            Assert.IsNotNull(models);
            Assert.IsTrue(models.Count > 0);
        }

        [TestMethod]
        public async Task GetModelsForMake_ReturnsApiResponse()
        {
            //Datenbank muss hier gemoqqt werden damit nix in die DB geschrieben wird
            //mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());

            var content = new StringContent("\"Toyota\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Car/GetModelsForMake", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            List<CarModel> models = await response.Content.ReadFromJsonAsync<List<CarModel>>();

            Assert.IsNotNull(models);
            Assert.IsTrue(models.Count > 0);
        }


    }
}
