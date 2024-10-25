using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Lesson> Lessons { get; set; }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.LessonConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.StudentConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ExamConfiguration());
        }
    }
}