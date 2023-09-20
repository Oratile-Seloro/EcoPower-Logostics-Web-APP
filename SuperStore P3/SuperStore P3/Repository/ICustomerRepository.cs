using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {

        Customer GetCustomerById(int id);

    }
}
