using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Create
        
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

            if (farmer == null)
                return Unauthorized();

            ViewBag.FarmerName = farmer.Name;
            ViewBag.Categories = new List<string> { "Fruits", "Vegetables", "Grains", "Dairy", "Livestock", "Other" };

            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Product product)
        {
            Console.WriteLine("Create POST hit");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

            if (farmer == null) 
                return Unauthorized();

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {


                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                ViewBag.FarmerName = farmer.Name;
                ViewBag.Categories = new List<string> { "Fruits", "Vegetables", "Grains", "Dairy", "Livestock", "Other" };
                return View(product);
            }

            product.FarmerId = farmer.FarmerId;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, string ProductName, string Category, string Description)
        {
            var productsQuery = _context.Products
       .Include(p => p.Farmer)
       .AsQueryable();
            if (startDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate >= startDate.Value);
            if (endDate.HasValue)
                productsQuery = productsQuery.Where(p => p.ProductionDate <= endDate.Value);

            if (!string.IsNullOrEmpty(ProductName))
                productsQuery = productsQuery.Where(p => p.ProductName.Contains(ProductName));

            if (!string.IsNullOrEmpty(Category))
                productsQuery = productsQuery.Where(p => p.Category.Contains(Category));

            if (!string.IsNullOrEmpty(Description))
                productsQuery = productsQuery.Where(p => p.Description.Contains(Description));

            var grouped = await productsQuery
       .GroupBy(p => p.Farmer)
       .ToListAsync();

            return View(grouped);
        }
    }
}
