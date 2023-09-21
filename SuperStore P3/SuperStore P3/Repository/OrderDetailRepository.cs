using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository//Implements the method in IOrderDetailRepository
    {
        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return GetAll().ToList();
        }


    }
}
