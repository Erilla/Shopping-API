using AutoMapper;
using ShoppingAPI.Business.Models;
using ShoppingAPI.Business.Repositories;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(Product product) => _productRepository.AddProduct(_mapper.Map<ProductEntity>(product));

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByProductCode(string productCode) => _mapper.Map<Product>(_productRepository.GetProductByProductCode(productCode));

        public void UpdateProductPriceByProductCode(string productCode, decimal newPrice) => _productRepository.UpdateProductPriceByProductCode(productCode, newPrice);
    }
}
