using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Domain;

namespace TodoManagment.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<T> GetRepository<T>() where T : DbEntity;

        public Task Save();
    }
}
