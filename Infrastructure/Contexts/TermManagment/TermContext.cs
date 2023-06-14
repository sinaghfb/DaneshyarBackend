using Domain.Entites.TermManagment;
using Domain.Enums;
using Infrastructure.Mappings.TermManagment;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.TermManagment
{
    public class TermContext:DbContext
    {
        public DbSet<Term> Terms { get; set; }

        public TermContext(DbContextOptions<TermContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(TermMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<Term>().HasQueryFilter(x => x.State == ObjectStateEnum.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
