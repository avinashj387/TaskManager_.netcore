using TaskManager.Models;

namespace TaskManager.Interfaces
{
    // Interfaces/ITaskService.cs

    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task<bool> UpdateTaskAsync(TaskItem task);
     
        Task<bool> DeleteTaskAsync(int id);


    }

}
