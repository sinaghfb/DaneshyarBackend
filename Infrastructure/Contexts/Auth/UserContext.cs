using Domain.Entites.Auth;
using Domain.Entites.BaseInfo;
using Domain.Enums;
using Infrastructure.Mappings.Auth;
using Infrastructure.Mappings.BaseInfo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.Auth
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.State == ObjectStateEnum.Active);
            base.OnModelCreating(modelBuilder);
        }
    }
}
