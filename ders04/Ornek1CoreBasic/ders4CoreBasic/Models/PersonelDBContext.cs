using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ders4CoreBasic.Models
{
    public partial class PersonelDBContext : DbContext
    {
        public PersonelDBContext()
        {
        }

        public PersonelDBContext(DbContextOptions<PersonelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonelDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid)
                    .HasColumnName("PId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasMaxLength(10);

                entity.Property(e => e.Soyadi)
                    .HasColumnName("soyadi")
                    .HasMaxLength(10);

                entity.Property(e => e.UnvanId)
                     .HasColumnName("unvan_id");
            });

            modelBuilder.Entity<Unvan>(entity =>
            {
                entity.Property(e => e.UnvanId).ValueGeneratedNever();

                entity.Property(e => e.UnvanAdi).HasMaxLength(10);
            });

            modelBuilder.Entity<Personel>().HasOne(x => x.Unvan).WithMany(x => x.Personels).HasForeignKey(x => x.UnvanId);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
