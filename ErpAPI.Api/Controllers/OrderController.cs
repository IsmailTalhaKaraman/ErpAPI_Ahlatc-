using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.OrdetDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet("/Orders")]
        [ProducesResponseType(typeof(Sonuc<List<OrderResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllAsync();
            List<OrderResponseDTO> orderDTOList = new();
            foreach (var order in orders)
            {
               
                orderDTOList.Add(_mapper.Map<OrderResponseDTO>(order));
            }
            return Ok(Sonuc<List<OrderResponseDTO>>.SuccesWithData(orderDTOList));
        }

        [HttpGet("/Order/{ID}")]
        [ProducesResponseType(typeof(Sonuc<List<OrderResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrder(int ID)
        {
            var order = await _orderService.GetAsync(q => q.ID == ID);

            if (order != null)
            {
              
                OrderResponseDTO orderDTO = _mapper.Map<OrderResponseDTO>(order);
                return Ok(Sonuc<OrderResponseDTO>.SuccesWithData(orderDTO));
            }
            return NotFound(Sonuc<OrderResponseDTO>.SuccesNoDataFound());

        }

        [HttpPost("/AddOrder")]
        [ValidationFilter(typeof(UserValidator))]
        
        public async Task<IActionResult> AddOrder(OrderRequestDTO orderRequestDTO)
        {
                Order order = _mapper.Map<Order>(orderRequestDTO);

                await _orderService.AddAsync(order);

                OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
               

                return Ok(Sonuc<OrderResponseDTO>.SuccesWithData(orderResponseDTO));


        }

    }
}
