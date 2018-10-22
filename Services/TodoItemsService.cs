using System;
using System.Linq;
using System.Threading.Tasks;
using Lunch.Data;
using Lunch.Models;
using Microsoft.EntityFrameworkCore;

namespace Lunch.Services
{
    public class TodoItemsService : ITodoItemsService
    {

        private readonly IToDoRepository _toDoRepo;

        public TodoItemsService(IToDoRepository toDoRep)
        {
            _toDoRepo = toDoRep;
        }

        public async Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            //return await _context.Items.Where(a => a.IdDone == false).ToArrayAsync();
            var result = await _toDoRepo.ListToDoItems();
            return result.ToArray();
        }

        public async Task AddItem(ToDoItem toDoItem)
        {
            await _toDoRepo.AddToDoItems(toDoItem);
        }

        //public async Task GenerateFakeData()
        //{
        //    var item1 = new ToDoItem
        //    {
        //        Id = new System.Guid(),
        //        DueAt = new System.DateTimeOffset(),
        //        Title = "item 1",
        //        IdDone = false
        //    };

        //    var item2 = new ToDoItem
        //    {
        //        Id = new System.Guid(),
        //        DueAt = new System.DateTimeOffset(),
        //        Title = "item 2",
        //        IdDone = true
        //    };

        //    await _toDoRepo.AddToDoItems(item1);
        //    await _toDoRepo.AddToDoItems(item2);

        //    //await _context.Items.Where(a => a.IdDone == false).ToArrayAsync();
        //}

        public async Task MarkDoneAsync(string id)
        {
            var item = await _toDoRepo.GetToDoItem(id);

            if (item == null) return;

            item.IdDone = !item.IdDone;

            await _toDoRepo.UpdateToDoItem(item);
        }
    }
}