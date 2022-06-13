using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Services
{
    public partial class PostDatabaseControl : DbContext
    {
        public PostDatabaseControl()
        {
        }

        public PostDatabaseControl(DbContextOptions<PostDatabaseControl> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogItem> CatalogItems { get; set; } = null!;
        public virtual DbSet<MainCat> MainCats { get; set; } = null!;
        public virtual DbSet<SubCat> SubCats { get; set; } = null!;

        static public string Host { get; set; } = String.Empty;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql($"Host={Host};Port=5432;Database=mydb;Username=def;Password=mypass");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Isdiscount).HasColumnName("isdiscount");

                entity.Property(e => e.Isinstock).HasColumnName("isinstock");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Oldprice).HasColumnName("oldprice");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Props)
                    .HasColumnType("xml")
                    .HasColumnName("props");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.CatalogItems)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BQDCJ45MM");
            });

            modelBuilder.Entity<MainCat>(entity =>
            {
                entity.ToTable("MainCat");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<SubCat>(entity =>
            {
                entity.ToTable("SubCat");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.SubCats)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_LTOW651TA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}