using AutoMapper;
using Koko.Server.Domain;
using Koko.Shared;


namespace Koko.Server.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, UserAccountDto>();
            CreateMap<AppUserLogin, UserLoginDto>()
                .ForMember(dest => dest.DisplayName, opts =>
                {
                    opts.MapFrom(src => src.User.DisplayName);
                });
        }
    }
}
