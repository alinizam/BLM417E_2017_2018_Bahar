using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class bioContext : DbContext
    {
        public virtual DbSet<CoursesNotes> CoursesNotes { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        public bioContext(DbContextOptions<bioContext> o) : base(o)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoursesNotes>(entity =>
            {
                entity.HasKey(e => e.CourseNoteId);

                entity.Property(e => e.CourseNoteId).ValueGeneratedNever();

                entity.Property(e => e.ExamName)
                    .HasColumnName("examName")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.StudentCourse)
                    .WithMany(p => p.CoursesNotes)
                    .HasForeignKey(d => d.StudentCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursesNo__Stude__286302EC");
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(e => e.StudentCourseId);

                entity.Property(e => e.StudentCourseId).ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .HasColumnName("Course_name")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__Stude__25869641");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("nchar(50)");
            });
        }
    }
}
