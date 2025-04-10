using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Domain;

namespace TodoManagment.Core.Interfaces
{
   
    public interface IRepository<T> where T : DbEntity
    {
        Task<T> Get(int id);

        Task<T> Get(int id, Expression< Func<T,object>> includedProps);

        Task<T> Get(Expression<Func<T, object>> includedProps, Expression<Func<T, bool>> condition);

        Task< List<T>> GetList();

        Task<List<T>> GetList(Expression<Func<T, bool>> condition);

        Task Add(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
