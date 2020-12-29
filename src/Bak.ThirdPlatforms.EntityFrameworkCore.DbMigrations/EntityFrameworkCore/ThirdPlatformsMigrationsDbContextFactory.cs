using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ThirdPlatformsMigrationsDbContextFactory : IDesignTimeDbContextFactory<ThirdPlatformsMigrationsDbContext>
    {
        public ThirdPlatformsMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ThirdPlatformsMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ThirdPlatformsMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
