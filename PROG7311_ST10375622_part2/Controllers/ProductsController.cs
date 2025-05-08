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
            //sets the userId to the currently logged in users Id
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
            //sets the userId to the currently logged in users Id
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

        //Filters the products that will be dispalyed
        
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, string ProductName, string Category, string Description)
        {
            //Reference:
            //Microsoft Learn (2024)
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

            //Grouped by farmer's name
            //Reference:
            //Microsoft Learn (2024)
            var grouped = await productsQuery
       .GroupBy(p => p.Farmer)
       .ToListAsync();

            return View(grouped);
        }
    }
}
