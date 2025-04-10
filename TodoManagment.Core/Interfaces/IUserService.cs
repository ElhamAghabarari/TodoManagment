using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Domain;

namespace TodoManagment.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task AddUser(User item);
        Task UpdateUser(User item);
        Task DeleteUser(int id);
    }
}
