using AskMe.Domain.Application.Contracts.Identity;
using AskMe.Domain.Entities.IdentityEntities;
using AskMe.Infrastructure.Extensions;
using AskMe.Infrastructure.Identity.IdentityContext;
using AskMe.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AskMe.Infrastructure.Identity.Registrations
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {



            services.TryAddScoped<IGenerateJwtToken, GenerateJwtToken>();
            services.TryAddTransient<ICurrentUserService, CurrentUserService>();
            services.AddDbContext<IdentityEfDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("AskMeConnectionString"),
              b => b.MigrationsAssembly(typeof(IdentityEfDbContext).Assembly.FullName)));


            return services;
        }

     

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddRoleManager<RoleManager<IdentityRole>>()
             .AddEntityFrameworkStores<IdentityEfDbContext>()
          .AddDefaultTokenProviders();
        }
    }
}
