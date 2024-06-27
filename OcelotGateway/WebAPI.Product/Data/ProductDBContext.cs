using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Product.Model;

namespace WebAPI.Product.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {

        }
        public ProductDBContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<ProductModel>  Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var appSetting = JsonConvert.DeserializeObject<AppSetting>(File.ReadAllText("appsettings.json"));
                optionsBuilder.UseSqlServer(appSetting.ConnectionString);
            }


        }

    }
}
