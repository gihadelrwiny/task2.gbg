using Microsoft.EntityFrameworkCore;

public class SystemContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Grade> Grades { get; set; }


    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted);

    }
}