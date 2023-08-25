using AutoMapper;
using ErpAPI.EEntity.DTO.PositionDTO;
using ErpAPI.EEntity.Poco;

namespace ErpAPI.Api.Mapping.PositionMap
{
    public class PositionRequestDTOMapper:Profile   
    {
        public PositionRequestDTOMapper()
        {
            CreateMap<Position, PositionRequestDTO>()
                .ForMember(dest => dest.Görev,
                opt =>
                {
                    opt.MapFrom(src => src.Duty);
                });

        }
    }
}
