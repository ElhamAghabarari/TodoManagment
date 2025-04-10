using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

namespace TodoManagment.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<User>();
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _repository.Get(id);

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var list = await _repository.GetList();

            return list;
        }

        public async Task AddUser(User item)
        {
            await _repository.Add(item);
            await _unitOfWork.Save();
        }

        public async Task UpdateUser(User item)
        {
            var item2 = await _repository.Get(item.Id);

            if (item2 == null)
            {
                // Handle the case where the user is not found
                throw new Exception("User not found.");
            }

            // Manually update the properties of item2 with values from item
            item2.FirstName = item.FirstName;
            item2.LastName = item.LastName;
            item2.Email = item.Email;

            await _repository.Update(item2);
            await _unitOfWork.Save();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _repository.Get(x => x.Tasks, x => x.Id == id);

            if (user?.Tasks.Count == 0)
            {
                await _repository.Delete(id);
                await _unitOfWork.Save();
            }
            
        }
    }
}
