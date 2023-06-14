using Carcode.Models;
using Carcore.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Testcontainers.MongoDb;

namespace Carcore.Test
{

    //purpose of this test class is to test the internal REST API
    [TestClass]
    public class IntegrationsTestAPI
    {
        private MongoDbContainer? _mongoDbContainer;
        private Mock<ICarDataAccess> mockDb;
        private WebApplicationFactory<Program> _webAppFactory;

        public IntegrationsTestAPI()
        {
            mockDb = new Mock<ICarDataAccess>();
        }

        [TestInitialize]
        public async Task Initialize()
        {

            var testProjectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(testProjectDir, "appsettings.Test.json");

            _webAppFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, config) =>
                {
                    // Add the configuration from appsettings.test.json
                    config.AddJsonFile(configPath);
                });
            });


            // Start the MongoDB container
            _mongoDbContainer = new MongoDbBuilder()
                .WithImage("mongo:latest")
                .WithUsername("mongo")
                .WithPassword("mongo")
                .WithPortBinding(12345, 27017)
                .Build();

            await _mongoDbContainer.StartAsync();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Stop and dispose of the MongoDB container
            await _mongoDbContainer.StopAsync();
            //_mongoDbContainer.DisposeAsync();
        }


        [TestMethod]
        public async Task GetAllMakes_ReturnApiResponse()
        {
            HttpClient _httpClient = _webAppFactory.CreateClient();
            //Datenbank muss hier gemoqqt werden damit nix in die DB geschrieben wird
            mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());

            var response = await _httpClient.GetAsync("api/Car/getAllMakes");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var models = await response.Content.ReadFromJsonAsync<List<CarModel>>();

            Assert.IsNotNull(models);
            Assert.IsTrue(models.Count > 0);
        }

        [TestMethod]
        public async Task GetModelsForMake_ReturnsApiResponse()
        {
            HttpClient _httpClient = _webAppFactory.CreateClient();
            //Datenbank muss hier gemoqqt werden damit nix in die DB geschrieben wird
            mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());

            var content = new StringContent("\"Toyota\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Car/GetModelsForMake", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var models = await response.Content.ReadFromJsonAsync<List<CarModel>>();

            Assert.IsNotNull(models);
            Assert.IsTrue(models.Count > 0);
        }


    }
}
