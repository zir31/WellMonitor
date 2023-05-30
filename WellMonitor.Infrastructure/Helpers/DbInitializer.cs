using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Helpers
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationDbContext context,
            ILogger<DbInitializer> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InitializeAsync()
        {
            try
            {
                _context.Database.EnsureDeleted();
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!_context.t_company.Any())
            {
                _context.t_company.AddRange(
                    new CompanyEntity
                    {
                        Id = 1,
                        Name = "First Company"
                    },
                    new CompanyEntity
                    {
                        Id = 2,
                        Name = "Second Company"
                    }
                    );

                await _context.SaveChangesAsync();
            }

            if (!_context.t_well.Any())
            {
                _context.t_well.AddRange(
                    new WellEntity
                    {
                    Id = 1,
                    Name = "First Well",
                    Id_company = 1,
                    Active = true
                    },
                    new WellEntity
                    {
                        Id = 2,
                        Name = "Second Well",
                        Id_company = 1,
                        Active = true
                    },
                    new WellEntity
                    {
                        Id = 3,
                        Name = "Third Well",
                        Id_company = 2,
                        Active = false
                    }
                    );

                await _context.SaveChangesAsync();
            }

            if (!_context.t_telemetry.Any())
            {
                _context.t_telemetry.AddRange(
                    new TelemetryEntity
                    {
                        Id = 1,
                        WellId = 1,
                        Date_time = DateTime.UtcNow.AddDays(-7),
                        Depth = 100
                    },
                    new TelemetryEntity
                    {
                        Id = 2,
                        WellId = 1,
                        Date_time = DateTime.UtcNow.AddDays(-3),
                        Depth = 150
                    },
                    new TelemetryEntity
                    {
                        Id = 3,
                        WellId = 1,
                        Date_time = DateTime.UtcNow.AddDays(-1),
                        Depth = 175
                    },
                    new TelemetryEntity
                    {
                        Id = 4,
                        WellId = 2,
                        Date_time = DateTime.UtcNow.AddDays(-2),
                        Depth = 440
                    }
                    );

                await _context.SaveChangesAsync();
            }
        }
    }
}