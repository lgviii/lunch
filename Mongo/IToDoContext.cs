using Lunch.Models;
using MongoDB.Driver;

namespace Lunch.Mongo
{
    public interface IToDoContext
    {
        IMongoCollection<ToDoItem> ToDoItems();
    }
}
