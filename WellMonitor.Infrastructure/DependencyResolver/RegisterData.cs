using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WellMonitor.Core.Entities;
using WellMonitor.Core.Interfaces;
using WellMonitor.Infrastructure.Helpers;
using WellMonitor.Infrastructure.Repositories;

namespace WellMonitor.Infrastructure.DependencyResolver
{
    public static class RegisterData
    {
        public static void RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var appDbConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(appDbConnectionString));
            services.AddScoped<IRepositoryBase<WellEntity>, WellRepository>();
            services.AddScoped<IRepositoryBase<CompanyEntity>, CompanyRepository>();
            services.AddScoped<IRepositoryBase<TelemetryEntity>, TelemetryRepository>();
            services.AddScoped<IRepositoryBase<WellActivityDeadlineEntity>, WellActivityDeadlineRepository>();
            services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
            services.AddTransient<DbInitializer>();
        }
    }
}
