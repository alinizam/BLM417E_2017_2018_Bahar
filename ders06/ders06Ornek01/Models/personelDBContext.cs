using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ders06Ornek01.Models
{
    public partial class personelDBContext : DbContext
    {
        public virtual DbSet<Personel> Personel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
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
        }
    }
}
