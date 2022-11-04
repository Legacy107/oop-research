using Microsoft.EntityFrameworkCore;
using MvcTodolist.Models;
using System;

namespace MvcTodolist.Data
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
