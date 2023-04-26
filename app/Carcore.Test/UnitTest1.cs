using Carcode.Models;
using Carcore.Controllers;
using Carcore.DataAccess;
using Moq;
using Moq.Protected;
using System.Net;

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

            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{""Count"":1,""Message"":""Response returned successfully"",""SearchCriteria"":null,""Results"":[]}"),
            };
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            _controller = new CarController(httpClient);


            // Act
            var result2 = await _controller.GetAllMakes();


            // Assert

        }

    }
}