using Data;
using Models;
using EcoPower_Logistics.Repository;
using Azure.Identity;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SuperStoreContext context) : base(context)
        {
        }

        public Product GetProductById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public void Create(Product entity)
        {
            Create(entity);
        }

        public void Delete(Product entity)
        {
            Delete(entity);
        }

    }
}
