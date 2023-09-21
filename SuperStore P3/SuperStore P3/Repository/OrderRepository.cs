using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository//Implements the methods in IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public Order GetOrderById(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderId == id);//Gets a specfic id in the database based on the id inputted
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll().ToList();
        }
    }
}
