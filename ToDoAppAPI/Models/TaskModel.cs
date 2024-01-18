using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Models
{
    public class TaskModel
    {
        [Key]
        public Guid TaskId { get; set; }
        public string? Name { get; set; }
        public string? Priority { get; set; }
        public string? DueDate { get; set; }
        public Boolean? IsCompleted { get; set; }
    }
}
