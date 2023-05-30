using WellMonitor.Infrastructure.Helpers;

namespace WellMonitor.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public async static void InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var initializer = services.GetRequiredService<DbInitializer>();

            await initializer.InitializeAsync();
            await initializer.SeedAsync();
        }
    }
}
