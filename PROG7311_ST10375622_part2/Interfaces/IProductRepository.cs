using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Interfaces
{
    public interface IProductRepository
    {
        /// Get all products
        Task<IEnumerable<IGrouping<Farmer, Product>>> GetFilteredProductsAsync(
            DateTime? startDate,
            DateTime? endDate,
            string productName,
            string category,
            string description);

        Task AddProductAsync(Product product);

    }
}
