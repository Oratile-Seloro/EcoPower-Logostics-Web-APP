using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Create(Product customer);

        Product GetProductById(int id);

        public IEnumerable<Product> GetAllProducts();

        public void Delete(Product entity);
    }
}
