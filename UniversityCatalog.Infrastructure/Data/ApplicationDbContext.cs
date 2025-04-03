using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }
    public DbSet<CourseTeacher> CourseTeachers { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Role>().HasData(
             new Role { Id = 1, Name = "Assistant"},
             new Role { Id = 2, Name = "Lecturer"}
         );
         modelBuilder.Entity<Student>().HasData(
             new Student
             {
                 Id = 1,
                 FirstName = "John",
                 LastName = "Doe",
                 Email = "john.doe@gmail.com",
                 PhoneNumber = "1234567890",
                 CurrentYear = 3
             },
             new Student
             {
                 Id = 2,
                 FirstName = "Andrei",
                 LastName = "Popescu",
                 Email = "andrei.popescu@gmail.com",
                 PhoneNumber = "0123456789",
                 CurrentYear = 2
             }
         );
         modelBuilder.Entity<Teacher>().HasData(
             new Teacher
             {
                 Id = 1,
                 FirstName = "Andrei",
                 LastName = "Marcu",
                 Email = "andrei.marcu@gmail.com",
                 PhoneNumber = "012341111111",
                 RoleId = 2
             }
         );
         modelBuilder.Entity<Course>().HasData(
             new Course
             {
                 Id = 1,
                 Name = "Matematica",
                 LecturerId = 1
             }
         );
         
        modelBuilder.Entity<Attendance>().HasKey(a => new { a.StudentId, a.CourseId });
        modelBuilder.Entity<CourseTeacher>().HasKey(ct => new { ct.CourseId, ct.TeacherId });
        modelBuilder.Entity<CourseStudent>().HasKey(cs => new { cs.CourseId, cs.StudentId });
        modelBuilder.Entity<Grade>().HasKey(g => new { g.CourseId, g.StudentId });
        modelBuilder.Entity<Teacher>().HasKey(t => t.Id);
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        modelBuilder.Entity<Course>().HasKey(c => c.Id);
        modelBuilder.Entity<Role>().HasKey(r => r.Id);
        
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(a => a.Attendances)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Course)
            .WithMany(a => a.Attendances)
            .HasForeignKey(a => a.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Role)
            .WithMany(r => r.Teachers)
            .HasForeignKey(t => t.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // modelBuilder.Entity<Course>()
        //     .HasOne(c => c.Lecturer)
        //     .WithMany(ct => ct.CourseTeachers)
        //     .HasForeignKey(c => c.LecturerId)
        //     .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<CourseTeacher>()
            .HasOne(ct => ct.Course)
            .WithMany(c => c.CourseTeachers)
            .HasForeignKey(ct => ct.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CourseTeacher>()
            .HasOne(ct => ct.Teacher)
            .WithMany(t => t.CourseTeachers)
            .HasForeignKey(ct => ct.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<CourseStudent>()
            .HasOne(cs => cs.Course)
            .WithMany(c => c.CourseStudents)
            .HasForeignKey(cs => cs.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CourseStudent>()
            .HasOne(cs => cs.Student)
            .WithMany(s => s.CourseStudents)
            .HasForeignKey(cs => cs.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();
        modelBuilder.Entity<Teacher>().HasIndex(t => t.Email).IsUnique();
        
        modelBuilder.Entity<Grade>()
            .Property(g => g.GradeType)
            .HasConversion<string>();
        modelBuilder.Entity<Grade>()
            .Property(g => g.Value)
            .HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Grade>().HasIndex(g => g.StudentId);
        modelBuilder.Entity<Grade>().HasIndex(g => g.CourseId);
        modelBuilder.Entity<Teacher>().HasIndex(t => t.RoleId);
        modelBuilder.Entity<Course>().HasIndex(c => c.LecturerId);
        modelBuilder.Entity<Attendance>().HasIndex(a => new { a.StudentId, a.CourseId });
        modelBuilder.Entity<CourseStudent>().HasIndex(cs => cs.StudentId);
        modelBuilder.Entity<CourseTeacher>().HasIndex(ct => new { ct.CourseId, ct.TeacherId });
    }

}