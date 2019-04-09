using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ders8Ornek1.Models
{
    public partial class personelDBContext : DbContext
    {
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }
        public personelDBContext(DbContextOptions<personelDBContext> options) : base(options) {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
    
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=personelDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.Property(e => e.PId)
                    .HasColumnName("pId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unvan>(entity =>
            {
                entity.HasKey(e => e.UId);

                entity.Property(e => e.UId)
                    .HasColumnName("uId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
