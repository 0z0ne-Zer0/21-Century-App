using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UI.Services.PostgreSQL
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

        static public string Host { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql($"Host={Host};Port=5432;Database=mydb;Username=def;Password=mypass");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("goods_pkey");

                entity.HasIndex(e => e.Cid, "NEW_INDEX")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasDefaultValueSql("nextval('catalogitems_id_seq'::regclass)");

                entity.Property(e => e.Isdiscount).HasColumnName("isdiscount");

                entity.Property(e => e.Isinstock).HasColumnName("isinstock");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Oldprice).HasColumnName("oldprice");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Props)
                    .HasColumnType("xml")
                    .HasColumnName("props");

                entity.Property(e => e.Psid).HasColumnName("psid");

                entity.HasOne(d => d.Ps)
                    .WithMany(p => p.CatalogItems)
                    .HasForeignKey(d => d.Psid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FO016M82U");
            });

            modelBuilder.Entity<MainCat>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("maincat_pkey");

                entity.ToTable("MainCat");

                entity.Property(e => e.Mid)
                    .HasColumnName("mid")
                    .HasDefaultValueSql("nextval('maincat_id_seq'::regclass)");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<SubCat>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("subcat_pkey");

                entity.ToTable("SubCat");

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasDefaultValueSql("nextval('subcat_id_seq'::regclass)");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Pmid).HasColumnName("pmid");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Pm)
                    .WithMany(p => p.SubCats)
                    .HasForeignKey(d => d.Pmid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VG4BZBM5G");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
