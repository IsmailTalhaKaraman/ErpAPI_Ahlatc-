using AutoMapper;
using ErpAPI.EEntity.DTO.SaleDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.SaleMap
{
    public class SaleResponseDTOMapper:Profile
    {
        public SaleResponseDTOMapper()
        {
            CreateMap<Sale,SaleResponseDTO>()
                .ForMember(dest => dest.SatisNo,
                opt =>
                {
                    opt.MapFrom(src => src.SaleCode);
                })
                .ForMember(dest => dest.SatısFiyati,
                opt =>
                {
                    opt.MapFrom(src => src.SalePrice);
                })
                .ForMember(dest => dest.MusteriID,
                opt =>
                {
                    opt.MapFrom(src => src.CustomerID);
                })
                .ForMember(dest => dest.SiparisID,
                opt =>
                {
                    opt.MapFrom(src => src.OrderID);
                })
                .ForMember(dest => dest.KullaniciID,
                opt =>
                {
                    opt.MapFrom(src => src.UserID);
                }).ReverseMap();



        }
    }
}
