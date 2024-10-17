using UserService.Entities;

namespace UserService.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(int id);
}