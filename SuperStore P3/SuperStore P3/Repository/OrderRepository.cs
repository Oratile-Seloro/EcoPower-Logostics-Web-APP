using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public Order GetOrderById(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderId == id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll().ToList();
        }

        public void Create(Order entity)
        {
            Create(entity);
        }

        public void Delete(Order entity)
        {
            Delete(entity);
        }
    }
}
