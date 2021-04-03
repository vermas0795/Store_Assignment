using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using System;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/entity/[controller]")]
    public class EstimationLogsController : ControllerBase
    {
        private IServiceRepository<EstimationLogsModel> _service;
        private readonly ILogger<EstimationLogsController> _log;
        public EstimationLogsController(IServiceRepository<EstimationLogsModel> service,
            ILogger<EstimationLogsController> log
            )
        {
            _service = service;
            _log = log;
        }

        /// <summary>
        /// EstimationLogs User
        /// </summary>
        /// <param name="model">JSON Model Details</param>
        /// <returns>Returns the new Entity document</returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddEstimationLogs([FromBody] EstimationLogsModel model)
        {
            try
            {
                _log.LogInformation("{0} method of {1} started in Api at :\t{2}", "AddEstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                var result = _service.Insert(model);
                if (result != null)
                {
                    _log.LogInformation("{0} method of {1} is Successfull in Api at :\t{2}", "AddEstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                    return Ok(result);
                }
                else
                {
                    _log.LogInformation("{0} method of {1} is Un-Successfull in Api at :\t{2}", "AddEstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in Api at :\t{3}", e, "AddEstimationLogs", "EstimationLogsController", DateTime.UtcNow);
                return NotFound();
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in Api at :\t{2}", "AddEstimationLogs", "EstimationLogsController", DateTime.UtcNow);
            }
        }
    }
}
