using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Models
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> ListToDoItems();
        Task<ToDoItem> GetToDoItem(string id);
        Task UpdateToDoItem(ToDoItem toDoItem);
        Task AddToDoItems(ToDoItem toDoItem);
    }
}