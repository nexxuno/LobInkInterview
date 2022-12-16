using LobInkInterview.Controllers;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using LobInkInterview.DataAccess.Repositories;
using LobInkInterview.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobInkInterview.Tests
{
    public class ControllersTests
    {
        [Fact]
        public async Task AdventureController_Get_Ok()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<AdventureController>>();
            var adventureRepoMock = new Mock<IAdventuresRepository>();
            var signatureHandlerMock = new Mock<ISignatureHandler>();
            var adventureController = new AdventureController(loggerMock.Object, adventureRepoMock.Object,
                signatureHandlerMock.Object);

            var expectedAdventures = new List<AdventureDAL>
            {
                new AdventureDAL
                {
                    Title= "Test"
                },
                new AdventureDAL
                {
                    Title= "Test2"
                }
            };
            adventureRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedAdventures);

            //Act
            var result = await adventureController.Get();

            //Assert
            //would need to create a proper comparison, not just the title
            Assert.Equal(2, result.Count());
            Assert.Equal(expectedAdventures[0].Title, result.ElementAt(0).Title);
            Assert.Equal(expectedAdventures[1].Title, result.ElementAt(1).Title);
        }
    }
}
