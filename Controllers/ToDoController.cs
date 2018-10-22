using Microsoft.AspNetCore.Mvc;
using Lunch.Services;
using System.Threading.Tasks;
using Lunch.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace Lunch.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemsService _todoItemsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoController(
            ITodoItemsService todoItemsService,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _todoItemsService = todoItemsService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var items = await _todoItemsService.GetIncompleteItemsAsync();

            var model = new ToDoViewModel()
            {
                Items = items
            };

            return View(model);
        }

        //public async Task<IActionResult> AddFakeData()
        //{
        //    await _todoItemsService.GenerateFakeData();

        //    return Ok();
        //}

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(ToDoItem newItem)
        {
            newItem.Id = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _todoItemsService.AddItem(newItem);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(string id)
        {
            if (id == Guid.Empty.ToString())
            {
                return RedirectToAction("Index");
            }

            await _todoItemsService.MarkDoneAsync(id);

            return RedirectToAction("Index");
        }
    }
}
