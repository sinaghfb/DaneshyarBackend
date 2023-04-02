using Domain.Entites.Auth;
using Domain.Entites.BaseInfo;
using Domain.Enums;
using Infrastructure.Mappings.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.Auth
{
    public class RoleContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public RoleContext(DbContextOptions<RoleContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.State == ObjectState.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}


