using AskMe.Domain.Entities.IdentityEntities;
using System.IdentityModel.Tokens.Jwt;

namespace AskMe.Domain.Application.Contracts.Identity
{
    public interface IGenerateJwtToken
    {
        Task<JwtSecurityToken> GenerateToken(AppUser user);
    }
}
