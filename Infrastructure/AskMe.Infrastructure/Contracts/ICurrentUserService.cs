using AskMe.Domain.Entities.IdentityEntities;

namespace AskMe.Infrastructure.Extensions
{
    public interface ICurrentUserService
    {
        Task<AppUser> GetCurrentUser();

        Task<string> GetCurrentUserIdAsync();

        Task<string> GetCurrentUserNameAsync();
    }
}
