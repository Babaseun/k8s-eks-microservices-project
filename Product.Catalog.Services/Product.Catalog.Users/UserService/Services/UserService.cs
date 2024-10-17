using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Entities;

namespace UserService.Services;

public class UserService(AppDbContext ctx) : IUserService
{
    public async Task<IEnumerable<User>> GetUsers()
        => await ctx.Users.ToListAsync();

    public async Task<User?> GetUserById(int id)
        => await ctx.Users.FirstOrDefaultAsync(p => p.Id == id);
}