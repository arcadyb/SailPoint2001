using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using SailPoint.Controllers;
using SailPoint.Models;
using SailPoint.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class AutoCompleteControllerTest
    {
        AutoCompleteController _controller;
        private readonly Mock<IDataAccessService> _mockDataService;
        IDataAccessService _service;
        ILogger<DataAccessService> _loggerDa;
        ILogger<AutoCompleteController> _loggerJc;
        IMemoryCache memoryCache;

        public AutoCompleteControllerTest()
        {
            //or use this short equivalent 
            _loggerJc = Mock.Of<ILogger<AutoCompleteController>>();
            _loggerDa = Mock.Of<ILogger<DataAccessService>>();
            _mockDataService = new Mock<IDataAccessService>();
            _service = new DataAccessService(_loggerDa, memoryCache);
            _controller = new AutoCompleteController(_mockDataService.Object, _loggerJc);

        }
        [Fact]
        public async Task GetCityTestAsync()
        {
            var pageId = 1;
            _mockDataService.Setup(repo => repo.GetCities("ab"))
                .Returns(Task.FromResult(new AutoCompleteList() { 
                ListItems = new List<City>()
                {
                    new City()
                    {
                        Id=1,
                        Name="AbuDabi"
                    }
                }

                } ));
            var result = await _controller.Get("ab");
            //Assert

            Assert.Equal(result.ListItems.FirstOrDefault()?.Name,"AbuDabi");

        }
    }
}
