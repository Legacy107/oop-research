using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTodolist.Data;
using RazorTodolist.Models;

namespace RazorTodolist.Pages.Todolist
{
    public class IndexModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public IndexModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<Todo> Todo { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            if (!String.IsNullOrEmpty(SearchString))
                Todo = (List<Todo>)await _todoRepository.SearchTodo(SearchString);
            else
                Todo = (List<Todo>)await _todoRepository.GetAllTodos();
        }
    }
}
