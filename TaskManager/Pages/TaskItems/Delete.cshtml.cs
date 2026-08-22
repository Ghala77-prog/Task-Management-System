using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Pages.TaskItems
{
    public class DeleteModel : PageModel
    {
        private readonly TaskManager.Data.ApplicationDbContext _context;

        public DeleteModel(TaskManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (TaskItem.UserId != userId) return Forbid();

            }

            TaskItem = await _context.TaskItems.FirstOrDefaultAsync(m => m.Id == id);

            if (TaskItem == null)
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

            TaskItem = await _context.TaskItems.FindAsync(id);

            if (TaskItem != null)
            {
                _context.TaskItems.Remove(TaskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");

        }
    }
}
