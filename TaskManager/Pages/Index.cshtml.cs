using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalTasks { get; set; }

        public int NewTasks { get; set; }

        public int InProgressTasks { get; set; }

        public int DoneTasks { get; set; }

        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var tasks = _context.TaskItems
                .Where(t => t.UserId == userId);

            TotalTasks = tasks.Count();

            NewTasks = tasks.Count(t => t.Status == TaskStatus.New);

            InProgressTasks = tasks.Count(t => t.Status == TaskStatus.InProgress);

            DoneTasks = tasks.Count(t => t.Status == TaskStatus.Done);
        }
    }
}