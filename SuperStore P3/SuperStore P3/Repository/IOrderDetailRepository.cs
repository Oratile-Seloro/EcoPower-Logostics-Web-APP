using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {

        public IEnumerable<OrderDetail> GetAllOrderDetails();

    }
}
