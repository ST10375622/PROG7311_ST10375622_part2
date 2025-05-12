using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Interfaces;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Repositories
{
    //Reference:
    //Microsoft Learn (2022).
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        // Constructor that takes an ApplicationDbContext as a parameter
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get filtered products based on various criteria
        public async Task<IEnumerable<IGrouping<Farmer, Product>>> GetFilteredProductsAsync(
            DateTime? startDate,
            DateTime? endDate,
            string productName,
            string category,
            string description)
        {
            var query = _context.Products
                .Include(p => p.Farmer) // Include the Farmer navigation property
                .AsQueryable();

            // Apply filters based on the provided parameters
            //Reference:
            //Microsoft Learn (2024)
            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate.Value);
            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate.Value);
            if (!string.IsNullOrEmpty(productName))
                query = query.Where(p => p.ProductName.Contains(productName));
            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);
            if (!string.IsNullOrEmpty(description))
                query = query.Where(p => p.Description.Contains(description));

            // Group the results by Farmer
            //Reference:
            //Microsoft Learn (2024)
            return await query.Include(p => p.Farmer).GroupBy(p => p.Farmer).ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
