using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bot.StrategyCatalog
{

    public class StrategyConfigContext : DbContext
    {
        public DbSet<StrategyConfig> configs { get; set; }
        public string DbPath { get; }

        public StrategyConfigContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    // Persisted Configs
    public class StrategyConfig
    {
        public int StrategyConfigId { get; set; }

        public string? AccountId { get; set; }

        public string? Password { get; set; }

        public string? StrategyId { get; set; }

    }

}
