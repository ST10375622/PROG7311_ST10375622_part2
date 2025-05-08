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

        //Prepopulating data for demonstartion purposes
        //Referencing
        //Microsoft Learn (2025).
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Farmer>().HasData(
                new Farmer
                {
                    FarmerId = 7,
                    Name = "John Doe",
                    Description = "Hello, I am looking to engage with other farmers",
                    Email = "john@gmail.com",
                    Location = "Newcastle",
                    Phone = "0871234653",
                    TypeOfFarmer = "Dairy Farmer",
                    UserId = "demoUser1"
                }
                );

            builder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 3,
                   Name = "Jane Doe",
                   Email = "jane@employee.com",
                   Phone = "0871234653",
                   Role = "Manager",
                   UserId = "demoUser1"
               }
               );

            builder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 5,
                    ProductName = "oranges",
                    Category = "Fruits",
                    Description = "The best oranges in the area",
                    ProductionDate = new DateTime(2025, 02, 01),
                    FarmerId = 7
                }
                );
        }
    }
}
