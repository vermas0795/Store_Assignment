using Microsoft.Extensions.DependencyInjection;
using Store.Business.Implementation;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using Store.DataAccess.Implementations;
using Store.DataAccess.Repository;
using Store.DataAccess.Repository.Entities;

namespace Store.Api.Extensions
{
    /// <summary>
    /// Extensions to enable registeration via dependency injection
    /// </summary>
    public static class ServiceCollectionApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            /* Register Services for Businees Service */

            services.AddTransient<IServiceRepository<AppUserModel>, AppUserService>();
            services.AddTransient<IServiceRepository<EstimationLogsModel>, EstimationLogsService>();

            /* Register Services for Data Service */

            services.AddTransient<IRepository<AppUser>, AppUserDataService>();
            services.AddTransient<IRepository<EstimationLogs>, EstimationLogsDataService>();

            return services;
        }
    }
}