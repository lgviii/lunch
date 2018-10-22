using Lunch.Models;
using System;
using System.Threading.Tasks;

namespace Lunch.Services
{
    public interface ITodoItemsService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync();
        //Task GenerateFakeData();
        Task AddItem(ToDoItem toDoItem);
        Task MarkDoneAsync(string id);
    }
}
