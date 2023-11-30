using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Smkas.Core.Settings;

namespace Smkas.Data
{
    public class BaseDbContext : DbContext 
    {
        private readonly string _configurationFolder;
        private AppSettings _appSettings { get; set; }

        public BaseDbContext(AppSettings appSettings, string configurationFolder)
        {
            _appSettings = appSettings;
            _configurationFolder = configurationFolder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.NoAction;

            var executingAssembly = Assembly.GetExecutingAssembly();
            var filter = $"{executingAssembly.GetName().Name}.Configurations.{_configurationFolder}";

            modelBuilder.ApplyConfigurationsFromAssembly(
                executingAssembly,
                x => x.Namespace.Equals(filter)
            );
        }
    }
}
