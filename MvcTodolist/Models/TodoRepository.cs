using System;
using System.Collections.Generic;
using System.Linq;
using MvcTodolist.Models;
using MvcTodolist.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcTodolist.Models
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public void AddTodo(Todo todo)
        {
            _context.Add(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            _context.Todo.Remove(todo);
        }

        public void EditTodo(Todo todo)
        {
            _context.Update(todo);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todo.ToListAsync();
        }

        public async Task<Todo> GetTodoById(int id)
        {
            return await _context.Todo.FirstOrDefaultAsync(todo => todo.Id == id);
        }

        public async Task<IEnumerable<Todo>> SearchTodo(string searchString)
        {
            var todos = from todo in _context.Todo select todo;
            todos = todos.Where(todo => todo.Description.Contains(searchString));

            return await todos.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public bool TodoExists(int id)
        {
            return _context.Todo.Any(todo => todo.Id == id);
        }
    }
}

