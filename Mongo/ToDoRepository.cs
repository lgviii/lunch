using Lunch.Mongo;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Models
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IToDoContext _context;

        public ToDoRepository(IToDoContext context)
        {
            _context = context;
        }

        public async Task AddToDoItems(ToDoItem toDoItem)
        {
            await _context.ToDoItems().InsertOneAsync(toDoItem);
        }

        public async Task<ToDoItem> GetToDoItem(string id)
        {
            return (await _context.ToDoItems().FindAsync(a => a.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<ToDoItem>> ListToDoItems() {
            return (await _context.ToDoItems().FindAsync(a => true)).ToList();
        }

        public async Task UpdateToDoItem(ToDoItem toDoItem)
        {
            var filter = Builders<ToDoItem>.Filter.Where(a => a.Id == toDoItem.Id);
            await _context.ToDoItems().ReplaceOneAsync(filter, toDoItem);
        }
    }
}