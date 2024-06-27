using WebAPI.Product.Data;
using WebAPI.Product.Model;

namespace WebAPI.Product.Repository
{
    public class ProductRepository : IProductRepository
    {

        private ProductDBContext dbContext;

        public ProductRepository(ProductDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(ProductModel product)
        {
            dbContext.Add(product);
        }

        public List<ProductModel> GetAll()
        {
            return dbContext.Product.ToList();
        }
    }
}
