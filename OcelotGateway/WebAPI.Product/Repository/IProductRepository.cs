using WebAPI.Product.Model;

namespace WebAPI.Product.Repository
{
    public interface IProductRepository
    {
        public void Add(ProductModel product);
    }
}
