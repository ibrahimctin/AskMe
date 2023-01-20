using AskMe.Domain.Application.DTOs.AppUsers.ResponseDtos;
using AskMe.Domain.Application.DTOs.Authentications.RequestDtos;
using AskMe.Domain.Entities.IdentityEntities;
using AutoMapper;


namespace AskMe.Domain.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           
            CreateMap<AppUser,RegisterRequest>().ReverseMap();  
            CreateMap<AppUser,AppUserDetailResponse>().ReverseMap();
            
        }
    }
}
