﻿using AskMe.Domain.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AskMe.Infrastructure.Identity.Registrations
{
    public static class AuthenticationExtension
    {
        public static void AddCustomizedAuthentication(this IServiceCollection services, JwtSettings _JwtSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = _JwtSettings.Issuer,
                       ValidAudiences = _JwtSettings.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettings.Key))
                   };
               });

         
        }
    }
}
