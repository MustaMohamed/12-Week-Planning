using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeeksPlanning.Migration.Migrations;

namespace WeeksPlanning.Migration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var items = input?.Split(" ");
            if (items != null)
            {
                string migrationChoice = items[0];
                var serviceProvider = CreateServices();

                // Put the database update into a scope to ensure
                // that all resources will be disposed.
                using (var scope = serviceProvider.CreateScope())
                {
                    DatabaseCreator.EnsureDatabase(Tables.DatabaseName);

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("up"))
                    {
                        UpdateDatabase(scope.ServiceProvider);
                    }

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("down"))
                    {
                        if (items.Length > 1)
                        {
                            var version = Convert.ToInt64(items[1]);
                            if (version > -1)
                            {
                                RollbackDatabase(scope.ServiceProvider, version);
                            }
                        }
                    }
                }
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLServer support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(GetConnectionString())
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(_002_Plan).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }

        private static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(rollbackVersion);
        }

        private static string GetConnectionString()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory
                .Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();
            var connectionString = configuration.GetConnectionString(Tables.DatabaseName);
            return connectionString;
        }
    }
}