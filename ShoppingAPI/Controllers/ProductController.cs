using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Models;
using ShoppingAPI.Business.Services;
using ShoppingAPI.Models;
using ShoppingAPI.ExceptionFilter;
using AutoMapper;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET api/<ProductController>/EAN1
        [HttpGet("{productCode}")]
        public Product GetByProductCode(string productCode)
        {
            return _productService.GetProductByProductCode(productCode);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] UpdateProductRequest product)
        {
            _productService.AddProduct(_mapper.Map<Product>(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{productCode}")]
        public void PutProductPriceByProductCode(string productCode, [FromQuery] decimal newPrice)
        {
            _productService.UpdateProductPriceByProductCode(productCode, newPrice);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
