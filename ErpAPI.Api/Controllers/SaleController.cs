using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.CustomerDTO;
using ErpAPI.EEntity.DTO.SaleDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class SaleController : Controller
    {
       private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;
       private readonly IMapper _mapper;

        public SaleController(ISaleService saleService, IMapper mapper, ICustomerService customerService)
        {
            _saleService = saleService;
            _mapper = mapper;
            _customerService = customerService;
        }
       

        [HttpGet("/Sales")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetSales()
        {
            var sales = await _saleService.GetAllAsync(q => q.IsActive == true && q.IsDelete == false, "Sale");
            
            if (sales != null)
            {
                List<SaleResponseDTO> saleResponseDTOList = new();

                foreach (var sale in sales) 
                {
                    saleResponseDTOList.Add(_mapper.Map<SaleResponseDTO>(sale));
                }
                return Ok(Sonuc<List<SaleResponseDTO>>.SuccesWithData(saleResponseDTOList));
            }
            else
            {
                return NotFound(Sonuc<List<CustomerResponseDTO>>.SuccesNoDataFound());
            }
        }
       

        [HttpGet("/Sale/{saleGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetSale(Guid saleGUID)
        {
            var sale = await _saleService.GetAsync(q => q.Guid == saleGUID, "Sale");
          
            if (sale != null)
            {
                SaleResponseDTO saleResponseDTO = _mapper.Map<SaleResponseDTO>(sale);

                return Ok(Sonuc<SaleResponseDTO>.SuccesWithData(saleResponseDTO));
            }
            else
            {
                return NotFound(Sonuc<SaleResponseDTO>.SuccesNoDataFound());
            }
        }
     

        [HttpPost("/AddSale")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> AddSale([FromBody] SaleRequestDTO saleDTO)
        {
            Customer customer = await _customerService.GetAsync(q => q.Guid == saleDTO.CustomerGUID);

            Sale sale = _mapper.Map<Sale>(saleDTO);

            sale.Customer = customer; 
           

            await _saleService.AddAsync(sale);

            return Ok(Sonuc<bool>.SuccesWithData(true));
        }

        [HttpPost("/UpdateSale")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSale([FromBody] SaleRequestDTO saleDTO)
        {
            Sale sale = await _saleService.GetAsync(q => q.Guid == saleDTO.Guid);

            Customer customer = await _customerService.GetAsync(q => q.Guid == saleDTO.CustomerGUID);


            sale.Customer = customer;
            sale.SaleCode = saleDTO.SatisNo;
            sale.SalePrice = saleDTO.SatısFiyati;
            

            await _saleService.UpdateAsync(sale);

            return Ok(Sonuc<bool>.SuccesWithData(true));
        }
       
        [HttpPost("/RemoveSale")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveProduct([FromBody] SaleRequestDTO saleDTO)
        {
            Sale sale = await _saleService.GetAsync(q => q.Guid == saleDTO.Guid);

            sale.IsActive = false;
            sale.IsDelete = true;
            await _saleService.UpdateAsync(sale);
            return Ok(Sonuc<bool>.SuccesWithData(true));
        }

    }


}
