using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorTodolist.Data;
using RazorTodolist.Models;

namespace RazorTodolist.Pages.Todolist
{
    public class CreateModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public CreateModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _todoRepository.AddTodo(Todo);
            await _todoRepository.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
