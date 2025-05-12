using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Interfaces;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class CommentsController : Controller
    {

        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ICommentRepository commentRepository, UserManager<IdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int postId, string content)
        {
            var userId = _userManager.GetUserId(User);
            var farmer = await _commentRepository.GetFarmerByUserIdAsync(userId);

            var comment = new Comments
            {
                Content = content,
                CreatedAt = DateTime.Now, //current date
                PostId = postId,
                FarmerId = farmer.FarmerId
            };

            await _commentRepository.AddCommentAsync(comment);

            return RedirectToAction("Details", "Posts", new {id = postId});
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
