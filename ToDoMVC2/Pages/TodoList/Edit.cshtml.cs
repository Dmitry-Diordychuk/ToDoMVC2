using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoMVC2.Models;

namespace ToDoMVC2.Pages.TodoList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Todo Todo { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Todo = _db.Todos.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TaskFromDb = _db.Todos.Find(Todo.Id);
                TaskFromDb.Description = Todo.Description;
                TaskFromDb.StartTime = Todo.StartTime;
                TaskFromDb.EndTime = Todo.EndTime;

                await _db.SaveChangesAsync();
                Message = "Task has been updated successfully";

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}