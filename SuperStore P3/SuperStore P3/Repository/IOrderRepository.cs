using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {

        Order GetOrderById(int id);

        public IEnumerable<Order> GetAllOrders();

    }
}
