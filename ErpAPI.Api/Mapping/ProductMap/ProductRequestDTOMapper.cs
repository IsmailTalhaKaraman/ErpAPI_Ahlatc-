using AutoMapper;
using ErpAPI.EEntity.DTO.ProductDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.ProductMap
{
    public class ProductRequestDTOMapper:Profile
    {
        public ProductRequestDTOMapper()
        {
            CreateMap<Product, ProductRequestDTO>()
                .ForMember(dest => dest.UrunKodu,
                opt =>
                {
                    opt.MapFrom(src => src.ProductCode);
                })
                .ForMember(dest => dest.BirimFiyat,
                opt =>
                {
                    opt.MapFrom(src => src.UnitPrice);
                })
                .ForMember(dest => dest.UrunAdi,
                opt =>
                {
                    opt.MapFrom(src => src.Name);
                }).ReverseMap();
        }
    }
}
