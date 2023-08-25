using AutoMapper;
using ErpAPI.EEntity.DTO.AuthorityDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.AuthorityMap
{
    public class AuthorityRequestDTOMapper: Profile
    {
        public AuthorityRequestDTOMapper()
        {
            CreateMap<Authority, AuthorityRequestDTO>()
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
