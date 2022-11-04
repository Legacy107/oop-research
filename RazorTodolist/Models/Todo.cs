using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorTodolist.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }

        public Todo()
        {
        }
    }
}

