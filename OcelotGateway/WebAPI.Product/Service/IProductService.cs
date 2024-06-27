using WebAPI.Product.Model;

namespace WebAPI.Product.Service
{
    public interface IProductService
    {
        public string Add(ProductModel product);
    }
}
