
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SailPoint.Models;
using SailPoint.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace SailPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoCompleteController : ControllerBase
    {
        private IDataAccessService _citiesRepo;
 
        private readonly ILogger<AutoCompleteController> _logger;

        public AutoCompleteController(
            IDataAccessService da,
            ILogger<AutoCompleteController> logger
            )
        {
            _citiesRepo = da;
            _logger = logger;
        }
        [HttpGet]
        public async Task<AutoCompleteList> Get(string searchStr)
        {
           
            try
            {
                var ret = await _citiesRepo.GetCities(searchStr);
                           
                return ret;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw new HttpRequestException(ex.Message);
            }
        }
 
    }
}
