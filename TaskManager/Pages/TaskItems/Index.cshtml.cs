using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Pages.TaskItems
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get; set; } = new List<TaskItem>();

        public int TotalTasks { get; set; }
        public int NewTasks { get; set; }
        public int InProgressTasks { get; set; }
        public int DoneTasks { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var tasks = _context.TaskItems
                .Where(t => t.UserId == userId);

            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(t => t.Title.Contains(SearchString));
            }

            TaskItem = await tasks
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            TotalTasks = TaskItem.Count;
            NewTasks = TaskItem.Count(t => t.Status.ToString() == "New");
            InProgressTasks = TaskItem.Count(t => t.Status.ToString() == "InProgress");
            DoneTasks = TaskItem.Count(t => t.Status.ToString() == "Done");
        }
    }
}