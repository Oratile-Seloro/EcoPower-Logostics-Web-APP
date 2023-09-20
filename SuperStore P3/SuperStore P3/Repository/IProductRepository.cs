using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        public IEnumerable<Product> GetAllProducts();

        public Product GetProductById(int id);

    }
}
