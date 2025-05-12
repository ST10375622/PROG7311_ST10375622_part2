using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Interfaces
{
    public interface ICommentRepository
    {
        /// Get all comments for a specific post
        Task AddCommentAsync(Comments comment);
        Task<Farmer> GetFarmerByUserIdAsync(string userId);

    }
}
