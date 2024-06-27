using WebAPI.Product.Model;

namespace WebAPI.Product.Service
{
    public interface IProductService
    {
        public ProductModel Add(ProductModel product);
    }
}
