using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.DbServices;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await taskService.GetAllTasks();
            return StatusCode(StatusCodes.Status200OK, tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask(TaskModel task)
        {
            var dbTask = await taskService.AddTask(task);
            return StatusCode(StatusCodes.Status200OK, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, TaskModel task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            try
            {
                await taskService.UpdateTask(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating task.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            try
            {
                await taskService.DeleteTask(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting task.");
            }

            return NoContent();
        }



    }
}
