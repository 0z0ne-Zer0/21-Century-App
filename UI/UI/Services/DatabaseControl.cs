using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Services
{
    public class DatabaseControl : DbContext
    {
#pragma warning disable CS8618

        public DatabaseControl(string host)
        {
            Host = host;
        }

#pragma warning restore CS8618

        public DbSet<MainWebPage> MainCat { get; set; }
        public DbSet<SubWebPage> SubCat { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public string Host { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={Host};Port=5432;Database=mydb;Username=def;Password=mypass");
        }
    }
}