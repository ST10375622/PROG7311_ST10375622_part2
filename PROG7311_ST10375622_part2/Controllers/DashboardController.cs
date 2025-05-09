using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext context,  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
            var posts = await _context.Posts
                //.Where(p => p.CreatedAt)
                .ToListAsync();

            var viewModel = new FarmerDashboardViewModel
            {
                Farmer = farmer,
                Posts = posts
            };

            return View(viewModel);
        }
    }
}
