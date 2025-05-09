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

        public DbSet<Post> Posts { get; set; } = default!;

        public DbSet<Comments> Comments { get; set; } = default!;

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

            builder.Entity<Product>().HasData(
               new Product
               {
                   ProductId = 6,
                   ProductName = "Watermelons",
                   Category = "Fruits",
                   Description = "The season is about to end",
                   ProductionDate = new DateTime(2025, 02, 01),
                   FarmerId = 3
               }
               );

            builder.Entity<Product>().HasData(
               new Product
               {
                   ProductId = 7,
                   ProductName = "Pigs",
                   Category = "Livestock",
                   Description = "Sourced out for their meat",
                   ProductionDate = new DateTime(2025, 02, 01),
                   FarmerId = 1
               }
               );

            builder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 7,
                    Title = "Tips for healthy Soil",
                    Contenet = "I use compost and crop rotation to Maintain healthy soil.",
                    CreatedAt = new DateTime(2025, 04, 15),
                    category = "General",
                    FarmerId = 7
                }
                );

            builder.Entity<Comments>().HasData(
                new Comments
                {
                    CommentId = 7,
                    Content = "Thank you for this tip. It was really helpful. I will try it during composting season.",
                    CreatedAt = new DateTime(2025, 04, 17),
                    PostId = 7,
                    FarmerId = 2
                }
                );

            builder.Entity<Comments>()
       .HasOne(c => c.Post)
       .WithMany() 
       .HasForeignKey(c => c.PostId)
       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
