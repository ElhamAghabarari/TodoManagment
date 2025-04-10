using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

namespace TodoManagment.Core.Services
{
    internal class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoTask> _repository;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TodoTask>();
        }
        public async Task AddTask(TodoTask item)
        {
            await _repository.Add(item);
            await _unitOfWork.Save();
        }

        public async Task DeleteTask(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<TodoTask> GetTask(int id)
        {
            var item = await _repository.Get(id);
            return item;
        }

        public async Task<List<TodoTask>> GetTasks(int user_id)
        {
            var list = await _repository.GetList(x => x.UserId == user_id);
            return list;
        }

        public async Task UpdateTask(TodoTask item)
        {
            var item2 = await _repository.Get(item.Id);

            if (item2 == null)
            {
                // Handle the case where the user is not found
                throw new Exception("Task not found.");
            }

            // Manually update the properties of item2 with values from item
            item2.Title = item.Title;
            item2.Description = item.Description;
            item2.Status = item.Status;

            await _repository.Update(item2);
            await _unitOfWork.Save();
        }
        public async Task UpdateTaskStatus(int id, int status)
        {
            var task = await _repository.Get(id);

            if (task == null)
            {
                throw new Exception("task id not fornd");
            }
            task.Status = (TaskStatusEnum)status;

            await _repository.Update(task);
            await _unitOfWork.Save();
        }
    }
}
