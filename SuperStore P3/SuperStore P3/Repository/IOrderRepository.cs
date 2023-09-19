using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        void Create(Order order);

        Order GetOrderById(int id);

        public IEnumerable<Order> GetAllOrders();

        public void Delete(Order entity);
    }
}
