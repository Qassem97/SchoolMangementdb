using Microsoft.EntityFrameworkCore;
using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Data
{
    public class SchoolContextdb : DbContext
    {
        public SchoolContextdb(DbContextOptions<SchoolContextdb> options)
        : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure optional relationship where each course has one teacher and each teacher has many courses
            modelBuilder.Entity<Course>()
                        .HasOne<Teacher>(c => c.Teacher)
                        .WithMany(t => t.Courses)
                        .HasForeignKey(c => c.TeacherId)
                        .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

            // Configure each student has many coures and each course has many students
            modelBuilder.Entity<StudentsCourses>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentsCourses>()
                        .HasOne<Student>(sc => sc.Student)
                        .WithMany(s => s.StudentsCourses)
                        .HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<StudentsCourses>()
                        .HasOne<Course>(sc => sc.Course)
                        .WithMany(s => s.StudentsCourses)
                        .HasForeignKey(sc => sc.CourseId);
        }
    }
}