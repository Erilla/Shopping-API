using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Models;
using ShoppingAPI.Business.Services;
using ShoppingAPI.Models;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISpecificPriceService _specificPriceService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ISpecificPriceService specificPriceService, IMapper mapper)
        {
            _productService = productService;
            _specificPriceService = specificPriceService;
            _mapper = mapper;
        }

        // GET api/<ProductController>/EAN1
        [HttpGet("{productCode}")]
        public Product GetByProductCode(string productCode) => _productService.GetProductByProductCode(productCode);

        // GET api/<ProductController>/EAN1/price
        [HttpGet("{productCode}/price")]
        public GetProductPriceResponse GetPriceByProductCode(string productCode) => _mapper.Map<GetProductPriceResponse>(_productService.GetProductByProductCode(productCode));

        // GET api/<ProductController>/EAN1/customer/1/price
        [HttpGet("{productCode}/customer/{customerId}/price")]
        public GetProductPriceResponse GetPriceByCustomerIdAndProductCode(int customerId, string productCode) => _mapper.Map<GetProductPriceResponse>(_productService.GetProductPriceByCustomerIdAndProductCode(customerId, productCode));

        // GET api/<ProductController>/EAN1/customer/john/price
        [HttpGet("{productCode}/customer/name/{customerName}/price")]
        public GetProductPriceResponse GetPriceByCustomerIdAndProductCode(string customerName, string productCode) => _mapper.Map<GetProductPriceResponse>(_productService.GetProductPriceByCustomerNameAndProductCode(customerName, productCode));


        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] UpdateProductRequest request) => _productService.AddProduct(_mapper.Map<Product>(request));

        // POST api/<ProductController>/EAN1/customer/1
        [HttpPost("{productCode}/customer/{customerId}")]
        public void PostSpecificPrice(string productCode, int customerId, [FromBody] CreateSpecificPriceRequest request) => _specificPriceService.CreateSpecificPriceByCustomerIdAndProductCode(customerId, productCode, request.Price);

        // POST api/<ProductController>/EAN1/customer/john
        [HttpPost("{productCode}/customer/name/{customerName}")]
        public void PostSpecificPrice(string productCode, string customerName, [FromBody] CreateSpecificPriceRequest request) => _specificPriceService.CreateSpecificPriceByCustomerNameAndProductCode(customerName, productCode, request.Price);


        // PUT api/<ProductController>/5
        [HttpPut("{productCode}")]
        public void PutProductPriceByProductCode(string productCode, [FromQuery] decimal newPrice) => _productService.UpdateProductPriceByProductCode(productCode, newPrice);

        // POST api/<ProductController>/EAN1/customer/1
        [HttpPut("{productCode}/customer/{customerId}/price")]
        public void PutSpecificPrice(string productCode, int customerId, [FromQuery] decimal newPrice) => _specificPriceService.UpdateSpecificPriceByCustomerIdAndProductCode(customerId, productCode, newPrice);

        // POST api/<ProductController>/EAN1/customer/john
        [HttpPut("{productCode}/customer/name/{customerName}/price")]
        public void PutSpecificPrice(string productCode, string customerName, [FromQuery] decimal newPrice) => _specificPriceService.UpdateSpecificPriceByCustomerNameAndProductCode(customerName, productCode, newPrice);


        // DELETE api/<ProductController>/EAN1/customer/1
        [HttpDelete("{productCode}/customer/{customerId}")]
        public void DeleteSpecificPrice(string productCode, int customerId) => _specificPriceService.DeleteSpecificPriceByCustomerIdAndProductCode(customerId, productCode);

        // DELETE api/<ProductController>/EAN1/customer/john
        [HttpDelete("{productCode}/customer/name/{customerName}")]
        public void DeleteSpecificPrice(string productCode, string customerName) => _specificPriceService.DeleteSpecificPriceByCustomerNameAndProductCode(customerName, productCode);
    }
}
