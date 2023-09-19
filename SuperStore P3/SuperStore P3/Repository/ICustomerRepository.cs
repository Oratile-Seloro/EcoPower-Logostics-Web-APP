using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        void Create(Customer customer);

        Customer GetCustomerById(int id);

        public IEnumerable<Customer> GetAllCustomers();

        public void Delete(Customer entity);
    }
}
