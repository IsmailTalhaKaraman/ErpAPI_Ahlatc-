using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.PositionDTO;
using ErpAPI.EEntity.DTO.UserDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpPost("/AddPosition")]
        [ValidationFilter(typeof(PositionValidator))]
        public async Task<IActionResult> AddPosition(PositionRequestDTO positionRequestDTO)
        {
                Position position = _mapper.Map<Position>(positionRequestDTO);

                await _positionService.AddAsync(position);

                
                PositionResponseDTO positionResponseDTO = _mapper.Map<PositionResponseDTO>(position);

                return Ok(Sonuc<PositionResponseDTO>.SuccesWithData(positionResponseDTO));
          

        }

        [HttpGet("/Positions")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPositions()
        {
            var positions = await _positionService.GetAllAsync();
            List<PositionResponseDTO> positionDTOList = new();
            foreach (var position in positions)
            {
                
                positionDTOList.Add(_mapper.Map<PositionResponseDTO>(position));
            }
            return Ok(Sonuc<List<PositionResponseDTO>>.SuccesWithData(positionDTOList));
        }

        [HttpGet("/Position/{ID}")]
        [ProducesResponseType(typeof(Sonuc<List<PositionResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPosition(int ID)
        {
            var position = await _positionService.GetAsync(q => q.ID == ID);

            if (position != null)
            {

                PositionResponseDTO positionDTO = _mapper.Map<PositionResponseDTO>(position);
                return Ok(Sonuc<PositionResponseDTO>.SuccesWithData(positionDTO));
            }
            return NotFound(Sonuc<PositionResponseDTO>.SuccesNoDataFound());

        }
    }
}
