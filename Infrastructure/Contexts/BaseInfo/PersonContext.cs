using Domain.Entites.BaseInfo;
using Domain.Enums;
using Infrastructure.Mappings.BaseInfo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.BaseInfo
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PersonMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<Person>().HasQueryFilter(x => x.State == ObjectState.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
