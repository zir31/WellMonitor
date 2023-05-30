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

        //public void Run()
        //{
        //    if (_options.Value.EnsureDeleted)
        //    {
        //        _context.Database.EnsureDeleted();
        //        _logger.LogInformation("The {1} database has been deleted", _context.Database.ProviderName);
        //    }

        //    if (_options.Value.Migrate)
        //    {
        //        if (_context.Database.GetMigrations().Any())
        //        {
        //            _context.Database.Migrate();
        //        }
        //        else
        //        {
        //            _context.Database.EnsureCreated();
        //        }
        //    }

        //    if (_options.Value.Seed)
        //    {
        //        var demoDataDbSeeder = new LocalFilesDbSeeder(_context, _dbSeederNamespaceOptions.Value);

        //        demoDataDbSeeder.SeedIfDbNotEmpty = false;
        //        demoDataDbSeeder.SeedLocal(_options.Value.RelativePathToDemoData);
        //    }
        //}

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
            if (!_context.t_well.Any())
            {
                _context.t_well.AddRange(
                    new WellEntity
                    {
                    Id = 1,
                    Name = "First Well",
                    Id_company = 1,
                    Id_telemetry = 1,
                    Active = 0
                    },
                    new WellEntity
                    {
                        Id = 2,
                        Name = "Second Well",
                        Id_company = 1,
                        Id_telemetry = 2,
                        Active = 0
                    },
                    new WellEntity
                    {
                        Id = 3,
                        Name = "Third Well",
                        Id_company = 2,
                        Id_telemetry = 3,
                    }
                    ); ;

                await _context.SaveChangesAsync();
            }
        }
    }
}