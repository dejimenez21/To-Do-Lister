using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoLister.Models;

namespace ToDoLister.Data
{
    public interface IListerRepository
    {
        Task<bool> SaveChangesAsync();

        void CreateEntity<T> (T entity) where T : class;
        void UpdateEntity<T> (T entity) where T : class;
        void DeleteEntity<T> (T entity) where T : class;

        // void CreateItemAsync(Item item);
        // void UpdateItem(int id, Item item);
        // void DeleteItem(int id);

        //Items
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);

        //Users
        
        
    }
}