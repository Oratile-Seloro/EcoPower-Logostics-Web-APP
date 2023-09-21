using Models;
using EcoPower_Logistics.Repository;
using Azure.Identity;
using Data;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository//Implements the method in ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context) 
        { 
        }

        public Customer GetCustomerById(int id)
        {
            return GetAll().FirstOrDefault(x => x.CustomerId == id);//Gets a specfic id in the database based on the id inputted
        }

        
    }
}
