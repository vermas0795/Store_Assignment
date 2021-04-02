using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.Api.Configuration;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/entity/[controller]")]
    public class EstimationLogsController : ControllerBase
    {
        private IServiceRepository<EstimationLogsModel> _service;
        private readonly ILogger<EstimationLogsController> _log;
        private readonly IConfiguration Configuration;
        public EstimationLogsController(IServiceRepository<EstimationLogsModel> service,
            ILogger<EstimationLogsController> log
            , IConfiguration configuration)
        {
            _service = service;
            _log = log;
            Configuration = configuration;
        }

        /// <summary>
        /// EstimationLogs User
        /// </summary>
        /// <param name="model">JSON Model Details</param>
        /// <returns>Returns the new Entity document</returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EstimationLogs([FromBody] EstimationLogsModel model)
        {
            try
            {
                _log.LogInformation("{0} method of {1} started in Api at :\t{2}", "EstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                var result = _service.Insert(model);
                if (result != null)
                {
                    _log.LogInformation("{0} method of {1} is Successfull in Api at :\t{2}", "EstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                    return Ok(result);
                }
                else
                {
                    _log.LogInformation("{0} method of {1} is Un-Successfull in Api at :\t{2}", "EstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in Api at :\t{3}", e, "EstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in Api at :\t{2}", "EstimationLogs", "EstimationLogsController", DateTime.UtcNow);
            }
        }
    }
}
