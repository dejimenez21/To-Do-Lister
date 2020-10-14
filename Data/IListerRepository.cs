using System.Collections.Generic;
using ToDoLister.Models;

namespace ToDoLister.Data
{
    public interface IListerRepository
    {
        IEnumerable<Item> GetAllItems();
    }
}