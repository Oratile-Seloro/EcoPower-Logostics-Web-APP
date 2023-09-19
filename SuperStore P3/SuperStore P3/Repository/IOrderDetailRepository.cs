using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        void Create(OrderDetail order);

        OrderDetail GetOrderDetailById(int id);

        public IEnumerable<OrderDetail> GetAllOrderDetails();

        public void Delete(OrderDetail entity);
    }
}
