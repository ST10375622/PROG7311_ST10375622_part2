using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG7311_ST10375622_part2.Models;

namespace PROG7311_ST10375622_part2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; } = default!;

        public DbSet<Employee> Employees { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;
    }
}
