using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Models
{
    public class ToDoItem
    {
        [BsonId]
        public Guid Id { get; set; }

        public bool IdDone { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTimeOffset DueAt { get; set; }
    }
}