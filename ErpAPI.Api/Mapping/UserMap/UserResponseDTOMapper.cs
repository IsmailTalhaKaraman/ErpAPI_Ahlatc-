using AutoMapper;
using ErpAPI.EEntity.DTO.UserDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.UserMap
{
    public class UserResponseDTOMapper:Profile
    {
        public UserResponseDTOMapper()
        {
            CreateMap<User, UserResponseDTO>()
                .ForMember(dest => dest.Adi,
                opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                })
                .ForMember(dest => dest.Soyadi,
                opt =>
                {
                    opt.MapFrom(src => src.LastName);
                })
                .ForMember(dest => dest.Eposta,
                opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.Telefon,
                opt =>
                {
                    opt.MapFrom(src => src.Phone);
                })
                .ForMember(dest => dest.Sifre,
                opt =>
                {
                    opt.MapFrom(src => src.Pasword);
                })
                .ForMember(dest => dest.Görev,
                opt =>
                {
                    opt.MapFrom(src => src.PositionID);
                })
                .ForMember(dest => dest.KullaniciAdi,
                opt =>
                {
                    opt.MapFrom(src => src.UserName);
                });
        }
    }
}
