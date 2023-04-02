using Application.Dependencies.Auth;
using Application.Dependencies.BaseInfo;
using Application.Implementation.Auth;
using Application.Implementation.BaseInfo;
using Domain.Contracts.Auth;
using Domain.Contracts.BaseInfo;
using Infrastructure.Contexts.Auth;
using Infrastructure.Contexts.BaseInfo;
using Infrastructure.Repositories.Auth;
using Infrastructure.Repositories.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations.BootStrappers
{
    public class InfrastructureBootStrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddTransient<IAuthApplication, AuthApplication>();
            services.AddTransient<IBaseInfoApplication, BaseInfoApplication>();


            services.AddDbContext<PersonContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<RoleContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<UserContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).EnableDetailedErrors().UseSqlServer(connectionString));
        }
    }
}
