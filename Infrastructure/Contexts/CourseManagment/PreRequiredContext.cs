using Domain.Entites.CourseManagment;
using Domain.Enums;
using Infrastructure.Mappings.CourseManagment;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.CourseManagment
{
    public class PreRequiredContext : DbContext
    {
        public DbSet<PreRequired> PreRequireds { get; set; }

        public PreRequiredContext(DbContextOptions<PreRequiredContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PreRequiredMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<PreRequired>().HasQueryFilter(x => x.State == ObjectStateEnum.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
