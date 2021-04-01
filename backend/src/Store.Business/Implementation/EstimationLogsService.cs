using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using Store.DataAccess.Repository;
using Store.DataAccess.Repository.Entities;

namespace Store.Business.Implementation
{
    public class EstimationLogsService : BaseService<EstimationLogsModel>
    {
        readonly ILogger<EstimationLogsService> _log;
        readonly IRepository<EstimationLogs> _EstimationLogsDataService;
        /// <summary>
        /// EstimationLogs Business Service constructor
        /// </summary>
        /// <param name="connection">Connection String</param>
        /// <param name="log">Logger For Service</param>
        /// <param name="EstimationLogsDataService">Logger For DataService</param>
        public EstimationLogsService(IRepository<EstimationLogs> EstimationLogsDataService, ILogger<EstimationLogsService> log)
        {
            this._log = log;
            this._EstimationLogsDataService = EstimationLogsDataService;
        }
        /// <summary>
        /// Function to check EstimationLogs 
        /// </summary>
        /// <param name="model">EstimationLogs input</param>
        /// <returns>Details of EstimationLogs</returns>
        public override EstimationLogsModel Insert(EstimationLogsModel model)
        {
            try
            {
                EstimationLogs entity;
                _log.LogInformation("{0} method of {1} started in Business at :\t{2}", "GetByCustom", "EstimationLogsService", DateTime.UtcNow);
                MapperConfiguration config1 = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EstimationLogsModel, EstimationLogs>();
                });
                IMapper iMapper1 = config1.CreateMapper();
                entity = iMapper1.Map<EstimationLogsModel, EstimationLogs>(model);

                var result = _EstimationLogsDataService.Insert(entity);

                MapperConfiguration config2 = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EstimationLogs, EstimationLogsModel>();
                });
                IMapper iMapper2 = config2.CreateMapper();
                model = iMapper1.Map<EstimationLogs,EstimationLogsModel>(result);
                return model;
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in Business at :\t{3}", e, "GetByCustom", "EstimationLogsService", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in Business at :\t{2}", "GetByCustom", "EstimationLogsService", DateTime.UtcNow);
            }
        }
    }
}
