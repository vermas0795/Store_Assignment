using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Store.Api.Extensions;
using Store.DataAccess.Repository.DBConf;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using Store.DataAccess.Repository.Entities;

namespace Store.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string CorsPolicy = "_CorsPolicy";

        /// <summary>
        /// Startup Constructor
        /// </summary>
        /// <param name="configuration">Configuartion</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Dependency Injection Service Extension
            services.AddApiServices();

            //JWT Auth Conf
            services.AddAuth(Configuration);

            //Adding Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
            });

            //Add Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
            services.AddTransient<IAccessConnectionString, AccessConnectionString>();
            services.AddTransient<StoreContext>();
            services.AddLogging(loggingBuilder =>  loggingBuilder.AddSerilog(dispose: true));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            app.UseAuthentication();
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/Swagger/v1/Swagger.json", "API v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(CorsPolicy);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
