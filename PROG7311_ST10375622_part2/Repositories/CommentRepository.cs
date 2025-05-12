using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Interfaces;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Repositories
{
    //Reference:
    //Microsoft Learn (2022).
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Reference:
        //Microsoft Learn (2022).
        //This method adds a comment to the database.
        public async Task AddCommentAsync(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<Farmer> GetFarmerByUserIdAsync(string userId)
        {
            return await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
        }
    }
}
