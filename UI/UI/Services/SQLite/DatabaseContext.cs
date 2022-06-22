using Microsoft.EntityFrameworkCore;

namespace UI.Services.SQLite
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogItem> CatalogItems { get; set; } = null!;
        public virtual DbSet<MainCat> MainCats { get; set; } = null!;
        public virtual DbSet<SubCat> SubCats { get; set; } = null!;
        public static string? DataSource { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite($"Data Source={DataSource}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("cid");

                entity.Property(e => e.Isdiscount)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("isdiscount");

                entity.Property(e => e.Isinstock)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("isinstock");

                entity.Property(e => e.Link)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("name");

                entity.Property(e => e.Oldprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("oldprice");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("price");

                entity.Property(e => e.Props).HasColumnName("props");

                entity.Property(e => e.Psid).HasColumnName("psid");

                entity.HasOne(d => d.Ps)
                    .WithMany(p => p.CatalogItems)
                    .HasForeignKey(d => d.Psid)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MainCat>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.ToTable("MainCat");

                entity.Property(e => e.Mid)
                    .ValueGeneratedNever()
                    .HasColumnName("mid");

                entity.Property(e => e.Link)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SubCat>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("SubCat");

                entity.Property(e => e.Sid)
                    .ValueGeneratedNever()
                    .HasColumnName("sid");

                entity.Property(e => e.Link)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("link");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Pmid).HasColumnName("pmid");

                entity.Property(e => e.Title)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("title");

                entity.HasOne(d => d.Pm)
                    .WithMany(p => p.SubCats)
                    .HasForeignKey(d => d.Pmid)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
