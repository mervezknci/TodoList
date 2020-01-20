using BLL.Repositories;
using BLL.Repositories.Interface;
using BLL.UnitofWork.Interface;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitofWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private TodoContext _context = new TodoContext();
        private bool _disposed = false;
        public Dictionary<Type, dynamic> repositories = new Dictionary<Type, dynamic>();


        public void Save()
        {
           _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.ContainsKey(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            var repoType = typeof(Repository<>);
            repositories.Add(typeof(T), Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), this._context));

            return repositories[typeof(T)];
        }
    }
}
