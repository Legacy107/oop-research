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
    public class DetailsModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public DetailsModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

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
    }
}
