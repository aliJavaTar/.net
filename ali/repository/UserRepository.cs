using ali.data;
using ali.models;

namespace ali.repository;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<bool> SaveChangesAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

    public async Task CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        await context.Users.AddAsync(user);
    }
}