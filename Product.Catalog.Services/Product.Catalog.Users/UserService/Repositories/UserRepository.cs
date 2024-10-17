using UserService.Data;
using UserService.Entities;

namespace UserService.Repositories;

public class UserRepository(AppDbContext ctx) : BaseRepository<User>(ctx), IUserRepository;