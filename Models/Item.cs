using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoLister.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string TaskName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Owner")]
        public int UserId { get; set; }
        
        public User Owner { get; set; }

        [DefaultValue(false)]
        public bool IsDone { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

    }

    //public enum StatusOptions {Pending, Completed}
}

    