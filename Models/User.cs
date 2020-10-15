using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoLister.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}