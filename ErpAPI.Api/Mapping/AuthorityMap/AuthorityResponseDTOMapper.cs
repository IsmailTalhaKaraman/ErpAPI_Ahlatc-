using AutoMapper;
using ErpAPI.EEntity.DTO.AuthorityDTO;
using ErpAPI.EEntity.Poco;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ErpAPI.Api.Mapping.AuthorityMap
{
    public class AuthorityResponseDTOMapper:Profile
    {
        public AuthorityResponseDTOMapper()
        {

            CreateMap<Authority, AuthorityResponseDTO>()
                .ForMember(dest => dest.Yetki,
                opt =>
                {
                    opt.MapFrom(src => src.Authorization);
                }).ForMember(dest => dest.KullanıcıID,
                opt =>
                {
                    opt.MapFrom(src => src.UserID);
                }).ReverseMap();
        }
    }
}
