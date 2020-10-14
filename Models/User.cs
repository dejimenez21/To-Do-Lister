using System.ComponentModel.DataAnnotations;

namespace ToDoLister.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Handle { get; set; }
    }
}