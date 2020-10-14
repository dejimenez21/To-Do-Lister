using Microsoft.EntityFrameworkCore;

namespace ToDoLister.Models
{
    public class ToDoListerContext : DbContext
    {
        public ToDoListerContext(DbContextOptions<ToDoListerContext> opt) : base(opt)
        {
            
        }

        public DbSet<Item> Items  { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

