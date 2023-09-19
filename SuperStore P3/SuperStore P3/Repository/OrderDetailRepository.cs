using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderDetailsId == id);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return GetAll().ToList();
        }

        public void Create(OrderDetail entity)
        {
            Create(entity);
        }

        public void Delete(OrderDetail entity)
        {
            Delete(entity);
        }
    }
}
