using Domain.Entites.CourseManagment;
using Domain.Enums;
using Infrastructure.Mappings.CourseManagment;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.CourseManagment
{
    public class CourseContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CourseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<Course>().HasQueryFilter(x => x.State == ObjectStateEnum.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
