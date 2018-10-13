﻿using Microsoft.AspNetCore.Mvc;
using Lunch.Services;
using System.Threading.Tasks;
using Lunch.Models;

namespace Lunch.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemsService _todoItemsService;

        public ToDoController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _todoItemsService.GetIncompleteItemAsync();

            var model = new ToDoViewModel()
            {
                Items = items
            };

            return View(model);
        }
    }
}
