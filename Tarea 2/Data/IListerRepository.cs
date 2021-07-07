using System.Collections.Generic;
using System.Threading.Tasks;
using TodoLister.Dtos;
using ToDoLister.Dtos;
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
        Task<IEnumerable<Item>> GetAllItemsAsync(string email = null);
        Task<Item> GetItemByIdAsync(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);

        //Users
        Task<User> AuthenticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        //Task<int> GetUserID(string email);
    }
}