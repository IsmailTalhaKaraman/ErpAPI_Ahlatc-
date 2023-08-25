using AutoMapper;
using ErpAPI.EEntity.DTO.CustomerDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.CustomerMap
{
    public class CustomerResponseDTOMapper:Profile
    {
        public CustomerResponseDTOMapper()
        {
            CreateMap<Customer, CustomerResponseDTO>()
                .ForMember(dest => dest.SatısNo,
                opt =>
                {
                    opt.MapFrom(src => src.SaleID);
                })
                .ForMember(dest => dest.MusterTelefon,
                opt =>
                {
                    opt.MapFrom(src => src.CustomerTelephone);
                })
                .ForMember(dest => dest.MusteriAdres,
                opt =>
                {
                    opt.MapFrom(src => src.CustomerAdress);
                })
                .ForMember(dest => dest.MusteriAdi,
                opt =>
                {
                    opt.MapFrom(src => src.CustomerName);
                })
                .ForMember(dest => dest.MusterEposta,
                opt =>
                {
                    opt.MapFrom(src => src.CustomerEmail);
                }).ReverseMap();

        }       
    }
}
