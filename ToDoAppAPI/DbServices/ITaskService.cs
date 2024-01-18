using ToDoAppAPI.Models;

namespace ToDoAppAPI.DbServices
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(Guid id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task);
        Task<TaskModel> DeleteTask(Guid id);

    }
}
