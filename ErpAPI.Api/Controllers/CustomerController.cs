using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.CustomerDTO;
using ErpAPI.EEntity.DTO.SaleDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpPost("/AddCustomer")]
        [ValidationFilter(typeof(CustomerValidator))]
        public async Task<IActionResult> AddCustomer(CustomerRequestDTO customerRequestDTO)
        {
           
                Customer customer = _mapper.Map<Customer>(customerRequestDTO);

                await _customerService.AddAsync(customer);


                
                CustomerResponseDTO customerResponeDTO = _mapper.Map<CustomerResponseDTO>(customer);

                return Ok(Sonuc<CustomerResponseDTO>.SuccesWithData(customerResponeDTO));
           

        }

        [HttpGet("/Customer/{customerGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomer(Guid customerGUID)
        {
            var customer = await _customerService.GetAsync(q => q.Guid == customerGUID );

            if (customer != null)
            {
                CustomerResponseDTO customerResponseDTO = new();

                customerResponseDTO = _mapper.Map<CustomerResponseDTO>(customer);
                return Ok(Sonuc<CustomerResponseDTO>.SuccesWithData(customerResponseDTO));
            }
            else
            {
                return NotFound(Sonuc<List<CustomerResponseDTO>>.SuccesNoDataFound());
            }

        }


        [HttpGet("/Customers")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers != null)
            {
                List<CustomerResponseDTO> customerResponseDTOList = new();
                foreach (var customer in customers)
                {
                    customerResponseDTOList.Add(_mapper.Map<CustomerResponseDTO>(customer));
                }
                return Ok(Sonuc<List<CustomerResponseDTO>>.SuccesWithData(customerResponseDTOList));
            }
            else
            {
                return NotFound(Sonuc<List<CustomerResponseDTO>>.SuccesWithoutData());
            }

        }

        [HttpGet("/ActiveCustomers")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetCustomers_Active()
        {
            var customers = await _customerService.GetAllAsync(q => q.IsActive == true && q.IsDelete == false);
            
            if (customers != null)
            {
                List<CustomerResponseDTO> customerResponseDTOList = new();

                foreach (var customer in customers)
                {
                    customerResponseDTOList.Add(_mapper.Map<CustomerResponseDTO>(customer));
                }
                return Ok(Sonuc<List<CustomerResponseDTO>>.SuccesWithData(customerResponseDTOList));
            }
            else
            {
                return NotFound(Sonuc<List<CustomerResponseDTO>>.SuccesNoDataFound());
            }
        }

        [HttpPost("/UpdateCustomer")]
        [ValidationFilter(typeof(CustomerValidator))]
        public async Task<IActionResult> UpdateCategory(CustomerRequestDTO customerRequestDTO)
        {
            Customer  customer = await _customerService.GetAsync(q => q.Guid == customerRequestDTO.Guid);

           
            customer.CustomerAdress = customerRequestDTO.MusteriAdres;
            customer.CustomerEmail = customerRequestDTO.MusteriAdres;
            customer.CustomerName = customerRequestDTO.MusteriAdi;
            customer.CustomerTelephone = customerRequestDTO.MusterTelefon;
            await _customerService.UpdateAsync(customer);
            return Ok(Sonuc<bool>.SuccesWithData(true));
        }

        [HttpPost("/RemoveCustomer")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveCategory(CustomerRequestDTO customerRequestDTO)
        {
            Customer customer = await _customerService.GetAsync(q => q.Guid == customerRequestDTO.Guid);
            customer.IsActive = false;
            customer.IsDelete = true;
            await _customerService.UpdateAsync(customer);
            return Ok(Sonuc<bool>.SuccesWithData(true));
        }
    }
}
