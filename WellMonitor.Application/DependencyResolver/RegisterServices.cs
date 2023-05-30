using Microsoft.Extensions.DependencyInjection;
using WellMonitor.Application.Interfaces;
using WellMonitor.Application.Services;

namespace WellMonitor.Application.DependencyResolver;

public static class RegisterServices
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IWellService, WellService>();

        services.AddScoped<ITelemetryService, TelemetryService>();
    }
}
