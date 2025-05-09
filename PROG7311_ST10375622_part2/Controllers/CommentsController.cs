using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class CommentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int postId, string content)
        {
            var userId = _userManager.GetUserId(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

            var comment = new Comments
            {
                
                Content = content,
                CreatedAt = DateTime.Now, //current date
                PostId = postId,
                FarmerId = farmer.FarmerId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Posts", new {id = postId});
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
