using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.AuthorityDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class AuthorityController : Controller
    {
        private readonly IAuthorityService _authorityService;
        private readonly IMapper _mapper;

        public AuthorityController(IAuthorityService authorityService, IMapper mapper)
        {
            _authorityService = authorityService;
            _mapper = mapper;
        }


        [HttpPost("/AddAuthority")]
        [ValidationFilter(typeof(AuthorityValidator))]
        public async Task<IActionResult> AddCustomer(AuthorityRequestDTO authorityRequestDTO)
        {

            Authority authority = _mapper.Map<Authority>(authorityRequestDTO);

            await _authorityService.AddAsync(authority);



            AuthorityResponseDTO authorityResponseDTO = _mapper.Map<AuthorityResponseDTO>(authority);

            return Ok(Sonuc<AuthorityResponseDTO>.SuccesWithData(authorityResponseDTO));


        }


        [HttpGet("/Authority/{ID}")]
        [ProducesResponseType(typeof(Sonuc<List<AuthorityResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuthority(int ID)
        {
            var authority = await _authorityService.GetAsync(q => q.ID == ID);

            if (authority != null)
            {


                AuthorityResponseDTO authorityDTO = _mapper.Map<AuthorityResponseDTO>(authority);
                return Ok(Sonuc<AuthorityResponseDTO>.SuccesWithData(authorityDTO));
            }
            return NotFound(Sonuc<AuthorityResponseDTO>.SuccesNoDataFound());

        }

        [HttpGet("/Authorities")]
        [ProducesResponseType(typeof(Sonuc<List<AuthorityResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuthorities()
        {
            var authorities = await _authorityService.GetAllAsync();
            List<AuthorityResponseDTO> authorityDTOList = new();
            foreach (var authority in authorities)
            {

                authorityDTOList.Add(_mapper.Map<AuthorityResponseDTO>(authority));
            }
            return Ok(Sonuc<List<AuthorityResponseDTO>>.SuccesWithData(authorityDTOList));
        }
    }
}
