using Models;
using EcoPower_Logistics.Repository;
using Azure.Identity;
using Data;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context) 
        { 
        }

        public Customer GetCustomerById(int id)
        {
            return GetAll().FirstOrDefault(x => x.CustomerId == id);
        }

        
    }
}
