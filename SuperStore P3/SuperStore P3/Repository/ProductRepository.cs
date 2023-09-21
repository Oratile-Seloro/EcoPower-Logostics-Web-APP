using Data;
using Models;
using EcoPower_Logistics.Repository;
using Azure.Identity;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository//Implements the method in IProductRepository
    {
        public ProductRepository(SuperStoreContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ProductId == id);//Gets a specfic id in the database based on the id inputted
        }

    }
}
