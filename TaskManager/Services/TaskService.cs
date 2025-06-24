// Services/TaskService.cs
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services

{
    
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TaskItem>> GetAllTasksAsync() => _repository.GetAllAsync();

        public Task<TaskItem?> GetTaskByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<TaskItem> CreateTaskAsync(TaskItem task) => _repository.AddAsync(task);

        public Task<bool> UpdateTaskAsync(TaskItem task) => _repository.UpdateAsync(task);

        public Task<bool> DeleteTaskAsync(int id) => _repository.DeleteAsync(id);
    }

}
