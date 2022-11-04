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
    public class DeleteModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public DeleteModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [BindProperty]
        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _todoRepository.GetTodoById((int)id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _todoRepository.GetTodoById((int)id);

            if (Todo != null)
            {
                _todoRepository.DeleteTodo(Todo);
                await _todoRepository.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
