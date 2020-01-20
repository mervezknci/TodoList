using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        //List<T> GetAll();
        IEnumerable<T> GetAll();
        T GetById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(int EntityId);
        void Delete(T Entity);
    }
}
