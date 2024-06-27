using WebAPI.Product.Model;
using WebAPI.Product.Repository;

namespace WebAPI.Product.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        { 
            _productRepository = productRepository;
        }

        public string Add(ProductModel product)
        {
            product.Id = Guid.NewGuid();
            _productRepository.Add(product);
            return "OK";
        }
    }
}
