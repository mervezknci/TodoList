using BLL.Repositories.Interface;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected TodoContext _context;
        protected readonly IDbSet<T> _dbset;

        public Repository(TodoContext Context)
        {
            _context = Context;
            _dbset = _context.Set<T>();
        }

        public void Delete(int EntityId)
        {
            T entityDel = _dbset.Find(EntityId);
            if (_context.Entry(entityDel).State == EntityState.Detached)
            {
                _dbset.Attach(entityDel);
            }
            _dbset.Remove(entityDel);
        }
        public virtual void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached) 
            {
                _dbset.Attach(Entity);
            }
            _dbset.Remove(Entity);
        }

        //public List<T> GetAll()
        //{
        //    return _dbset.GetA
        //}

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public virtual T GetById(object EntityId)
        {
            return _dbset.Find(EntityId);
        } 
        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbset.Where(Filter);
            }
            return _dbset;
        }
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public  virtual void Add(T Entity)
        {
            _dbset.Add(Entity);
        }
    }
}
