using Microsoft.AspNetCore.Identity;

namespace PROG7311_ST10375622_part2.Services
{
    public class RoleSeeder
    {

            public static async Task SeedRoles(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Employee", "Farmer" };

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        

    }
}
