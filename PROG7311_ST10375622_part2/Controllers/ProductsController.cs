using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Data;
using PROG7311_ST10375622_part2.Interfaces;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;

        public ProductsController(IProductRepository productRepository, ApplicationDbContext context)
        {
            _productRepository = productRepository;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//current logged in user
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);//finds the farmer by userId

            if (farmer == null) 
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                ViewBag.FarmerName = farmer.Name;
                ViewBag.Categories = new List<string> { "Fruits", "Vegetables", "Grains", "Dairy", "Livestock", "Other" };
                return View(product);
            }

            product.FarmerId = farmer.FarmerId;
            await _productRepository.AddProductAsync(product);

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, string ProductName, string Category, string Description)
        {
         var groupedProducts = await _productRepository.GetFilteredProductsAsync(startDate, endDate, ProductName, Category, Description);

            return View(groupedProducts);
        }
    }
}
