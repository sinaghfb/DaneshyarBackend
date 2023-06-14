using Domain.Entites.TermManagment;
using Domain.Enums;
using Infrastructure.Mappings.TermManagment;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.TermManagment
{
    public class TermCourseContext:DbContext
    {
        public DbSet<TermCourse> TermCourses { get; set; }

        public TermCourseContext(DbContextOptions<TermCourseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(TermCourseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<TermCourse>().HasQueryFilter(x => x.State == ObjectStateEnum.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
