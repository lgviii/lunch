using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Models
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> ListToDoItems();
        Task AddToDoItems(ToDoItem toDoItem);
    }
}