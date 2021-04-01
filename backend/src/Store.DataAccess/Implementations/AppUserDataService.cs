﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Helper;
using Store.DataAccess.Repository.DBConf;
using Store.DataAccess.Repository.Entities;
using System;
using System.Linq;

namespace Store.DataAccess.Implementations
{
    public class AppUserDataService : DBRepositoryBase<AppUser>
    {
        private readonly ILogger<AppUserDataService> _log;
        private readonly IAccessConnectionString _connection;
        private readonly ILogger<StoreContext> _logContext;
        /// <summary>
        /// AppUser Data Service constructor
        /// </summary>
        /// <param name="log">Logger For Service</param>
        /// <param name="logContext">Logger For Context</param>
        public AppUserDataService(IAccessConnectionString connection, ILogger<AppUserDataService> log, ILogger<StoreContext> logContext)
        {
            this._logContext = logContext;
            this._log = log;
            this._connection = connection;
        }
        /// <summary>
        /// Function to Authenticate  AppUser
        /// </summary>
        /// <returns>Details of AppUser</returns>
        public override AppUser GetByCustom(string json)
        {
            AppUser result = null;
            try
            {
                _log.LogInformation("{0} method of {1} started in DataAccess at :\t{2}", "GetByCustom", "AppUserDataService", DateTime.UtcNow);
                using (var context = new StoreContext(_connection, _logContext))
                {
                    if (json != null)
                    {
                        string loginName = json.Split("#$#")[0];
                        string password = Base64EncDec.EncodePasswordToBase64(json.Split("#$#")[1]);
                        result = context.AppUser.Where(x=> x.IsActive && x.LoginName.ToLower() == loginName.ToLower()
                                && x.Password == password).Include(x=>x.Role).FirstOrDefault();
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in DataAcess at :\t{3}", e, "GetByCustom", "AppUserDataService", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in DataAccess at :\t{2}", "GetByCustom", "AppUserDataService", DateTime.UtcNow);
            }
        }
    }
}
