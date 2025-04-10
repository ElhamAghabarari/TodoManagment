using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

namespace TodoManagment.Infrastructure.Repositoty
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly Context _context;
        private readonly Dictionary<Type,object> _repositories;
        public UnitOfWork(Context context) { 
            _context = context;
            _repositories = new Dictionary<Type,object>();
        }

        public IRepository<T> GetRepository<T>() where T : DbEntity {
        
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }
            var repo=new Repository<T>(_context);
            _repositories.Add(typeof(T), repo); 
            return repo;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
