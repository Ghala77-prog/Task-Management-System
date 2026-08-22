using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Pages.TaskItems
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; } = new TaskItem();


        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            TaskItem.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TaskItem.CreatedAt = DateTime.Now;

            _context.TaskItems.Add(TaskItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");


        }
    }
}
