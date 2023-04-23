using Application.Dependencies.Auth;
using Application.Dependencies.BaseInfo;
using Application.Dependencies.CourseManagmanet;
using Application.Implementation.Auth;
using Application.Implementation.BaseInfo;
using Application.Implementation.CourseManagment;
using Domain.Contracts.Auth;
using Domain.Contracts.BaseInfo;
using Domain.Contracts.CourseManagment;
using Infrastructure.Contexts.Auth;
using Infrastructure.Contexts.BaseInfo;
using Infrastructure.Contexts.CourseManagment;
using Infrastructure.Repositories.Auth;
using Infrastructure.Repositories.BaseInfo;
using Infrastructure.Repositories.CourseManagment;
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
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IPreRequiredRepository, PreRequiredRepository>();


            services.AddTransient<IAuthApplication, AuthApplication>();
            services.AddTransient<IBaseInfoApplication, BaseInfoApplication>();
            services.AddTransient<ICourseManagment, CourseManagmentApplication>();


            services.AddDbContext<PersonContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30))
            .EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<RoleContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).
            EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<UserContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).
            EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<CourseContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).
            EnableDetailedErrors().UseSqlServer(connectionString));
            services.AddDbContext<PreRequiredContext>(x => x.UseLazyLoadingProxies().EnableDetailedErrors().ConfigureLoggingCacheTime(TimeSpan.FromMinutes(30)).
            EnableDetailedErrors().UseSqlServer(connectionString));


        }
    }
}
