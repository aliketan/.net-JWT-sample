using AutoMapper;

namespace API.Persistence.AutoMapper.Profiles
{
    using Model.Dtos.User;
    using Model.Entities;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(m => m.Email))
                .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(m => m.Email.ToUpper()))
                .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(m => m.Email.ToUpper()));

            CreateMap<ChangePasswordDto, User>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<User, UserResponseDto>();
        }
    }
}
