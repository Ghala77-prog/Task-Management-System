using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public enum TaskStatus
    {
        New,
        InProgress,
        Done
    }

    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string Description { get; set; } = "";


        public TaskStatus Status { get; set; } = TaskStatus.New;

        [Range(1, 5)]
        public int Priority { get; set; } = 3;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
    }
}
