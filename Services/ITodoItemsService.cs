using Lunch.Models;
using System.Threading.Tasks;

namespace Lunch.Services
{
    public interface ITodoItemsService
    {
        Task<ToDoItem[]> GetIncompleteItemAsync();
    }
}
