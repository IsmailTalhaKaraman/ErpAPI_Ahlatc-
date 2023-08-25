using AutoMapper;
using ErpAPI.EEntity.DTO.PositionDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.PositionMap
{
    public class PositionResponseDTOMapper:Profile
    {
        public PositionResponseDTOMapper()
        {
            CreateMap<Position, PositionResponseDTO>()
               .ForMember(dest => dest.Görev,
               opt =>
               {
                   opt.MapFrom(src => src.Duty);
               });
        }
    }
}
