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

        public async Task<IEnumerable<ToDoItem>> ListToDoItems() {
            return (await _context.ToDoItems().FindAsync(a => true)).ToList();
        }
    }
}