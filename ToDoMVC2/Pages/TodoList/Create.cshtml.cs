using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoMVC2.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoMVC2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [TempData]
        public string Message { set; get; }

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty] //Автоматический передает как параметр в методы-запросы
        public Todo Todo { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Todos.Add(Todo);
            await _db.SaveChangesAsync();
            Message = "Task has been created successfully!";
            return RedirectToPage("Index");
        }
    }
}