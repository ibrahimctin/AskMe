using AskMe.Domain.Application.DTOs.Authentications.ResponseDtos;
using MediatR;

namespace AskMe.Domain.Application.Features.Identity.Authentication.Login.Requests
{
    public class LoginCommand:IRequest<AuthResponse>
    {
       
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
