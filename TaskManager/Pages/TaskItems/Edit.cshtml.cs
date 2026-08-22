using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Pages.TaskItems
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            TaskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (TaskItem == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (TaskItem.UserId != userId) return Forbid();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dbTask = await _context.TaskItems.AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == TaskItem.Id);

            if (dbTask == null) return NotFound();
            if (dbTask.UserId != userId) return Forbid();

            TaskItem.UserId = dbTask.UserId;
            TaskItem.CreatedAt = dbTask.CreatedAt;

            _context.Attach(TaskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");

        }
    }
}
