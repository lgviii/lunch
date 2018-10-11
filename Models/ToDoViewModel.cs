using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Models
{
    public class ToDoViewModel
    {
        public ToDoItem[] Items { get; set; }
    }
}