using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Models;
namespace ToDoAppAPI.DbServices
{
    public class TaskService: ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _appDbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(Guid id)
        {
            return await _appDbContext.Tasks.FindAsync(id);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            _appDbContext.Tasks.Add(task);
            await _appDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            var existingTask = await _appDbContext.Tasks.FindAsync(task.TaskId);
            if (existingTask == null)
            {
                throw new ArgumentException("No task found with the given ID");
            }
            _appDbContext.Entry(existingTask).CurrentValues.SetValues(task);
            await _appDbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<TaskModel> DeleteTask(Guid id)
        {
            var taskToRemove = await _appDbContext.Tasks.FindAsync(id);
            if (taskToRemove == null)
            {
                throw new ArgumentException("No task found with the given ID");
            }
            _appDbContext.Tasks.Remove(taskToRemove);
            await _appDbContext.SaveChangesAsync();
            return taskToRemove;
        }



    }
}
