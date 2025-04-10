using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Domain;

namespace TodoManagment.Core.Interfaces
{
    public interface ITaskService
    {
        Task<List<TodoTask>> GetTasks(int user_id);
        Task<TodoTask> GetTask(int id);
        Task AddTask(TodoTask item);
        Task UpdateTask(TodoTask item);
        Task UpdateTaskStatus(int id, int status);
        Task DeleteTask(int id);
    }
}
