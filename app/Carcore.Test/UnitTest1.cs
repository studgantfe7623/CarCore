using Carcode.Models;
using Carcore.Controllers;
using Carcore.DataAccess;
using Carcore.Models;
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
        private CarController _controller;


        [TestMethod]
        public async Task GetAllMakes_ReturnApiResponse2()
        {
            // Arrange
            var mockDb = new Mock<ICarDataAccess>();
            mockDb.Setup(x => x.getCachedMakes()).ReturnsAsync(new List<CarModel>());
            //mockDb.Setup(x => x.CacheMakes(It.IsAny<List<CarModel>>()))

            var handlerMock = new Mock<HttpMessageHandler>();
            var carResult = new CarResultModel
            {
                Count = 2,
                Message = "Response returned successfully",
                Results = new List<CarModel>{
                    new CarModel { Make_ID = 582, Make_Name= "AUDI" },
                    new CarModel { Make_ID=583, Make_Name ="BENTLEY"}
                },
                SearchCriteria = null
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
            _controller = new CarController(httpClient, mockDb.Object);
            var result = await _controller.GetAllMakes();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

    }
}