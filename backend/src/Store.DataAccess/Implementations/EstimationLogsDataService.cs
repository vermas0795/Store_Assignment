using Microsoft.Extensions.Logging;
using Store.DataAccess.Helper;
using Store.DataAccess.Repository.DBConf;
using Store.DataAccess.Repository.Entities;
using System;
using System.Linq;

namespace Store.DataAccess.Implementations
{
    public class EstimationLogsDataService : DBRepositoryBase<EstimationLogs>
    {
        private readonly ILogger<EstimationLogsDataService> _log;
        private readonly IAccessConnectionString _connection;
        private readonly ILogger<StoreContext> _logContext;
        /// <summary>
        /// EstimationLog Data Service constructor
        /// </summary>
        /// <param name="log">Logger For Service</param>
        /// <param name="logContext">Logger For Context</param>
        public EstimationLogsDataService(IAccessConnectionString connection, ILogger<EstimationLogsDataService> log, ILogger<StoreContext> logContext)
        {
            this._logContext = logContext;
            this._log = log;
            this._connection = connection;
        }
        /// <summary>
        /// Function to Authenticate  EstimationLog
        /// </summary>
        /// <returns>Details of EstimationLog</returns>
        public override EstimationLogs Insert(EstimationLogs entity)
        {
            try
            {
                _log.LogInformation("{0} method of {1} started in DataAccess at :\t{2}", "GetByCustom", "EstimationLogDataService", DateTime.UtcNow);
                using (var context = new StoreContext(_connection, _logContext))
                {
                    context.EstimationLogs.Add(entity);
                    context.SaveChanges();
                }
                return entity;
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in DataAcess at :\t{3}", e, "GetByCustom", "EstimationLogDataService", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in DataAccess at :\t{2}", "GetByCustom", "EstimationLogDataService", DateTime.UtcNow);
            }
        }
    }
}
