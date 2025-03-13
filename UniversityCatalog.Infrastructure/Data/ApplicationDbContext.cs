using API.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCatalog.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Student> Students { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>()
            .HasKey(a => new { a.StudentId, a.CourseId });
        modelBuilder.Entity<CourseTeacher>()
            .HasKey(ct => new { ct.CourseId, ct.TeacherId });
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
        
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Lecturer)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.LecturerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CourseTeacher>()
            .HasOne(cl => cl.Course)
            .WithMany(c => c.CourseTeachers)
            .HasForeignKey(cl => cl.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseTeacher>()
            .HasOne(cl => cl.Teacher)
            .WithMany(t => t.CourseTeachers)
            .HasForeignKey(cl => cl.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Teacher>().HasIndex(t => t.RoleId);
        modelBuilder.Entity<Course>().HasIndex(c => c.LecturerId);
        modelBuilder.Entity<Attendance>().HasIndex(a => new { a.StudentId, a.CourseId });
        modelBuilder.Entity<CourseTeacher>().HasIndex(ct => new { ct.CourseId, ct.TeacherId });
    }

}