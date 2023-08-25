using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.ProductDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ProductController : Controller
    {
      

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("/Products")]
        [ProducesResponseType(typeof(Sonuc<List<ProductResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            List<ProductResponseDTO> productDTOList = new();
            foreach (var product in products)
            {
                productDTOList.Add(_mapper.Map<ProductResponseDTO>(product));
            }
            return Ok(Sonuc<List<ProductResponseDTO>>.SuccesWithData(productDTOList));

        }

        [HttpGet("/Product/{ID}")]
        [ProducesResponseType(typeof(Sonuc<List<ProductResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProduct(int ID)
        {
            var product = await _productService.GetAsync(q => q.ID == ID);

            if (product != null)
            {
              
                ProductResponseDTO productDTO = _mapper.Map<ProductResponseDTO>(product);
                return Ok(Sonuc<ProductResponseDTO>.SuccesWithData(productDTO));
            }
            return NotFound(Sonuc<ProductResponseDTO>.SuccesNoDataFound());

        }

        [HttpPost("/AddProduct")]
        [ValidationFilter(typeof(ProductValidator))]
        
        public async Task<IActionResult> AddProduct(ProductRequestDTO productRequestDTO)
        {
            
              
                Product product = _mapper.Map<Product>(productRequestDTO);

                await _productService.AddAsync(product);

                ProductResponseDTO productResponseDTO = _mapper.Map<ProductResponseDTO>(product);

               return Ok(Sonuc<ProductResponseDTO>.SuccesWithData(productResponseDTO));


        }


    }
}
