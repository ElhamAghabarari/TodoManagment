using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

namespace TodoManagment.Infrastructure.Repositoty
{
    
    internal class Repository<T> : IRepository<T> where T : DbEntity
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public async Task Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
            }
        }

        public async Task<T> Get(int id)
        {
            var item = await _context.Set<T>().SingleOrDefaultAsync(x=> x.Id == id);
            return item;
        }

        public async Task<T> Get(int id,Expression< Func<T,object>> includedProps)
        {
            var item = await _context.Set<T>().Include(includedProps).SingleOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<T> Get(Expression<Func<T, object>> includedProps, Expression<Func<T,bool>> condition)
        {
            var item = await _context.Set<T>().Include(includedProps).SingleOrDefaultAsync(condition);
            return item;
        }

        public async Task<List<T>> GetList()
        {
            var items = await _context.Set<T>().ToListAsync();
            return items;
        }

        public async Task<List<T>> GetList(Expression< Func<T,bool>> condition)
        {
            var items = await _context.Set<T>().Where(condition).ToListAsync();
            return items;
        }

        public async Task Update(T item)
        {
            _context.Set<T>().Update(item);
            await Task.CompletedTask;
        }
    }
}
