using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Quartz;
using Serilog;
using System.Reflection;

namespace WellMonitor.WebApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureLogger(this IServiceCollection services,
            ILoggingBuilder loggingBuilder,
            IConfiguration configuration)
            
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(logger);
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WellMonitor",
                    Version = "v1",
                    Description = "An ASP.NET Core Web API for monitoring wells"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddVersioning(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });
        }

        public static void AddJobAndTrigger<T>(
        this IServiceCollectionQuartzConfigurator quartz)
        where T : IJob
        {
            string jobName = typeof(T).Name;

            var jobKey = new JobKey(jobName);

            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithDailyTimeIntervalSchedule(
                s => s.WithIntervalInHours(24)
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(00, 00))));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-simple-trigger")
                .WithSimpleSchedule()
                .StartNow());
        }
    }
}
