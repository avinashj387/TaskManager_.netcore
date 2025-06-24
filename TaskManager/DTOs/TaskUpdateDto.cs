// DTOs/TaskUpdateDto.cs
using System.ComponentModel.DataAnnotations;
namespace TaskManager.DTOs
{
    public class TaskUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}