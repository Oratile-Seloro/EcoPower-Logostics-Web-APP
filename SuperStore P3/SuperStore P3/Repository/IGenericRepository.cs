using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IGenericRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        public void Update(T entity);

        T GetById(int id);
    }

}
