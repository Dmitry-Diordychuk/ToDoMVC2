using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoMVC2.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoMVC2.Pages.TodoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [TempData]
        public string Message { get; set; }

        public IEnumerable<Todo> Todos { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            _db.Todos.Where(item => DateTime.Now > item.EndTime && !item.IsFailed).ToList().ForEach(item => item.IsFailed = true);
            await _db.SaveChangesAsync();
            Todos = await _db.Todos.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();

            Message = "Task deleted succesfully";

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDone(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            todo.IsDone = true;
            await _db.SaveChangesAsync();

            Message = "Task has been done";

            return RedirectToPage("Index");

        }
    }
}