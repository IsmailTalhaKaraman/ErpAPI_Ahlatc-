using AutoMapper;
using ErpAPI.EEntity.DTO.OrdetDTO;
//using ErpAPI.EEntity.DTO.OrderDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.OrderMap
{
    public class OrderRequestDTOMapper:Profile
    {
        public OrderRequestDTOMapper()
        {
            CreateMap<Order, OrderRequestDTO>()
                .ForMember(dest => dest.SatısID,
                opt =>
                {
                    opt.MapFrom(src => src.SaleID);
                })
                .ForMember(dest => dest.SatisSiparisKodu,
                opt =>
                {
                    opt.MapFrom(src => src.OrderSalesCode);
                })
                .ForMember(dest => dest.SiparisKodu,
                opt =>
                {
                    opt.MapFrom(src => src.OrderCode);
                })
                .ForMember(dest => dest.ToplamFiyat,
                opt =>
                {
                    opt.MapFrom(src => src.TotalPrice);
                })
                .ForMember(dest => dest.KullanıcıID,
                opt =>
                {
                    opt.MapFrom(src => src.UserID);
                })
                .ForMember(dest => dest.Urun,
                opt =>
                {
                    opt.MapFrom(src => src.Product);
                })
                .ForMember(dest => dest.SiparisAciklamasi,
                opt =>
                {
                    opt.MapFrom(src => src.Quantity);
                }).ReverseMap();
        }
    }
}
