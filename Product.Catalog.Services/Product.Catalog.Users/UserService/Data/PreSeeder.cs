using UserService.Entities;
using UserService.Repositories;

namespace UserService.Data;

public static class PreSeeder
{
    public static async Task Seeder(AppDbContext ctx, IUserRepository userRepository)
    {
        var listOfUsers = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 5, 14),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsAdmin = false,
                Status = "Active",
                PhoneNumber = "555-1234"
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1985, 8, 22),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsAdmin = true,
                Status = "Active",
                PhoneNumber = "555-5678"
            },
            new User
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                DateOfBirth = new DateTime(1992, 3, 10),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsAdmin = false,
                Status = "Inactive",
                PhoneNumber = "555-8765"
            }
        };


        if (!ctx.Users.Any())
        {
            foreach (var product in listOfUsers)
            {
                ctx.Users.Add(product);
            }
            await ctx.SaveChangesAsync();
        }
    }
}