using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using MvcTodolist.Data;
using MvcTodolist.Models;

namespace MvcTodolist.Models
{
    public interface ITodoRepository
    {
        public Task<IEnumerable<Todo>> SearchTodo(string searchString);

        public Task<IEnumerable<Todo>> GetAllTodos();

        public Task<Todo> GetTodoById(int id);

        public void AddTodo(Todo todo);

        public void DeleteTodo(Todo todo);

        public void EditTodo(Todo todo);

        public Task SaveChanges();

        public bool TodoExists(int id);
    }
}
