using Carcode.Models;
using Carcore.Controllers;
using Carcore.DataAccess;
using Carcore.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Carcore.Test
{
    [TestClass]
    public class UnitTest1
    {
        private CarController? _controller;
        private Mock<ICarDataAccess> mockDb;
        private IConfiguration _config;
   
        public UnitTest1()
        {
            mockDb = new Mock<ICarDataAccess>();
          
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true);

            _config = configurationBuilder.Build();
        }

        [TestMethod]
        public async Task GetAllMakes_ReturnApiResponse()
        {
            // Arrange         
            mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());
            //mockDb.Setup(x => x.CacheMakes(It.IsAny<List<CarModel>>()))

            var handlerMock = new Mock<HttpMessageHandler>();
            var carResult = new CarResultModel
            {
                Count = 2,
                Message = "Response returned successfully",
                Results = new List<CarModel>{
                    new CarModel { Make_ID = 582, Make_Name = "AUDI" },
                    new CarModel { Make_ID = 583, Make_Name = "BENTLEY"}
                },
                // SearchCriteria = null
            };
            var json = JsonConvert.SerializeObject(carResult);
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
                //Content = new StringContent(@"{""Count"":1,""Message"":""Response returned successfully"",""SearchCriteria"":null,""Results"":[]}"),
            };
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            // Act
            _controller = new CarController(httpClient, mockDb.Object, _config);
            var result = await _controller.GetAllMakes();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetAllMakes_ReturnsBadRequest()
        {
            //Arrange
            mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());

            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("The request was invalid"),
            };

            handlerMock
              .Protected()
              .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);


            // Act and Assert
            _controller = new CarController(httpClient, mockDb.Object, _config);

            await Assert.ThrowsExceptionAsync<HttpRequestException>(_controller.GetAllMakes);
        }

        [TestMethod]
        public async Task GetModelsForMake_ReturnsApiResponse()
        {
            // Arrange    
            var selectedMake = "BMW";
            mockDb.Setup(x => x.getCachedModelsForMake(selectedMake)).ReturnsAsync(new List<CarModel>());


            var handlerMock = new Mock<HttpMessageHandler>();
            var carResult = new CarResultModel
            {
                Count = 2,
                Message = "Response returned successfully",
                Results = new List<CarModel>{
                    new CarModel { Make_ID = 452, Make_Name = selectedMake, Model_ID = 1707, Model_Name = "135i"},
                    new CarModel { Make_ID = 452, Make_Name = selectedMake, Model_ID = 1714, Model_Name = "X6"}
                },
                SearchCriteria = selectedMake
            };
            var json = JsonConvert.SerializeObject(carResult);
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            handlerMock
              .Protected()
              .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            // Act
            _controller = new CarController(httpClient, mockDb.Object, _config);
            var result = await _controller.GetModelsForMake(selectedMake);

            // Assert
            Assert.AreEqual(2, result.Count);
        }


    }
}