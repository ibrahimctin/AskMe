using AskMe.Domain.Entities.IdentityEntities;
using AskMe.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AskMe.Infrastructure.Identity.IdentityContext
{
    public class IdentityEfDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public IdentityEfDbContext(DbContextOptions<IdentityEfDbContext>options):base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }
    }
}
