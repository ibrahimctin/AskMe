using AskMe.Domain.Application.DTOs.Authentications.RequestDtos;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AskMe.Domain.Application.Features.Identity.Authentication.Register.Requests
{
    public class RegisterCommand:IRequest<IdentityResult>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
