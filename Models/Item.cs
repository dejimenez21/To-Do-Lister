using System.ComponentModel.DataAnnotations;
using System;

namespace ToDoLister.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public User Owner { get; set; }

        [Required]
        public StatusOptions Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

    }

    public enum StatusOptions {Pending, Completed}
}

    