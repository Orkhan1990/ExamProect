using DataAccessLayer.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ExamDb:DbContext,IExamDb
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=ExamDb;Integrated Security=true;");
        }

        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentExam>? StudentExams { get; set; }
        public DbSet<StudentLesson>? StudentLessons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Exam>()
                .Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Exam>()
                .Property(p => p.ExamDate).IsRequired();
            modelBuilder.Entity<Exam>()
                .Property(p => p.ExamScore).IsRequired();


            modelBuilder.Entity<Student>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Student>()
                .Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Student>()
                .Property(p=>p.Surname).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Student>()
              .Property(p => p.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Student>()
             .Property(p => p.Class).IsRequired();
            modelBuilder.Entity<Student>()
                .Property(p => p.StudentNumber).IsRequired();


            modelBuilder.Entity<Lesson>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Lesson>()
                .Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Lesson>()
                .Property(p => p.NameOfLesson).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Lesson>()
                .Property(p=>p.CodeOfLesson).HasMaxLength(3).IsRequired();
            modelBuilder.Entity<Lesson>()
               .Property(p => p.TeacherName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Lesson>()
             .Property(p => p.TecaherSurname).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Lesson>()
                .Property(p => p.Class).IsRequired();
            modelBuilder.Entity<Lesson>()
                .HasOne(p => p.Exam).WithMany(p => p.Lessons).HasForeignKey(p => p.ExamId).OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<StudentLesson>()
                .HasKey(bc => new { bc.LessonId, bc.StudentId });
            modelBuilder.Entity<StudentLesson>()
                .HasOne(bc => bc.Lesson)
                .WithMany(b => b.StudentLessons)
                .HasForeignKey(bc => bc.LessonId);
            modelBuilder.Entity<StudentLesson>()
                .HasOne(bc => bc.Student)
                .WithMany(c => c.StudentLessons)
                .HasForeignKey(bc => bc.StudentId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<StudentExam>()
                .HasKey(bc => new { bc.ExamId, bc.StudentId });
            modelBuilder.Entity<StudentExam>()
                .HasOne(bc => bc.Exam)
                .WithMany(b => b.StudentExams)
                .HasForeignKey(bc => bc.ExamId);
            modelBuilder.Entity<StudentExam>()
                .HasOne(bc => bc.Student)
                .WithMany(c => c.StudentExams)
                .HasForeignKey(bc => bc.StudentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
