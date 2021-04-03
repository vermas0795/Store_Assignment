using Microsoft.Extensions.Logging;
using Store.DataAccess.Repository.DBConf;
using Store.DataAccess.Repository.Entities;
using System;

namespace Store.DataAccess.Implementations
{
    public class EstimationLogsDataService : DBRepositoryBase<EstimationLogs>
    {
        private readonly ILogger<EstimationLogsDataService> _log;
        private StoreContext _context;

        /// <summary>
        /// EstimationLog Data Service constructor
        /// </summary>
        /// <param name="log">Logger For Service</param>
        /// <param name="context">Context</param>
        public EstimationLogsDataService(ILogger<EstimationLogsDataService> log,StoreContext context)
        {
            this._log = log;
            this._context = context;
        }
        /// <summary>
        /// Function to Insert EstimationLog
        /// </summary>
        /// <returns>Details of EstimationLog</returns>
        public override EstimationLogs Insert(EstimationLogs entity)
        {
            try
            {
                _log.LogInformation("{0} method of {1} started in DataAccess at :\t{2}", "Insert", "EstimationLogDataService", DateTime.UtcNow);
                using (_context)
                {
                    _context.EstimationLogs.Add(entity);
                    _context.SaveChanges();
                }
                return entity;
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in DataAcess at :\t{3}", e, "Insert", "EstimationLogDataService", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in DataAccess at :\t{2}", "Insert", "EstimationLogDataService", DateTime.UtcNow);
            }
        }
    }
}
