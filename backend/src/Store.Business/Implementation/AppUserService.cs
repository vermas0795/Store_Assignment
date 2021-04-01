using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using Store.DataAccess.Repository;
using Store.DataAccess.Repository.Entities;

namespace Store.Business.Implementation
{
    public class AppUserService : BaseService<AppUserModel>
    {
        readonly ILogger<AppUserService> _log;
        readonly IRepository<AppUser> _AppUserDataService;
        /// <summary>
        /// AppUser Business Service constructor
        /// </summary>
        /// <param name="connection">Connection String</param>
        /// <param name="log">Logger For Service</param>
        /// <param name="AppUserDataService">Logger For DataService</param>
        public AppUserService(IRepository<AppUser> AppUserDataService, ILogger<AppUserService> log)
        {
            this._log = log;
            this._AppUserDataService = AppUserDataService;
        }
        /// <summary>
        /// Function to check AppUser 
        /// </summary>
        /// <param name="json">AppUser input</param>
        /// <returns>Details of AppUser</returns>
        public override AppUserModel GetByCustom(string json)
        {
            AppUserModel AppUser = new AppUserModel();
            try
            {
                _log.LogInformation("{0} method of {1} started in Business at :\t{2}", "GetByCustom", "AppUserService", DateTime.UtcNow);
                var result = _AppUserDataService.GetByCustom(json);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AppUser, AppUserModel>()
                    .ForMember(d => d.Role, o => o.MapFrom(t => t.Role.Description))
                    .ForMember(d => d.Discount, o => o.MapFrom(t => t.Role.Discount));
                });
                IMapper iMapper = config.CreateMapper();
                AppUser = iMapper.Map<AppUser,AppUserModel>(result);
                return AppUser;
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in Business at :\t{3}", e, "GetByCustom", "AppUserService", DateTime.UtcNow);
                throw e;
            }
            finally
            {
                AppUser = null;
                _log.LogInformation("{0} method of {1} ended in Business at :\t{2}", "GetByCustom", "AppUserService", DateTime.UtcNow);
            }
        }
    }
}
