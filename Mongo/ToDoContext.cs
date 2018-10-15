using Lunch.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Lunch.Mongo
{
    public class ToDoContext : IToDoContext
    {
        private readonly IMongoDatabase _db;

        public ToDoContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<ToDoItem> ToDoItems() => _db.GetCollection<ToDoItem>("ToDoItem");
    }
}
