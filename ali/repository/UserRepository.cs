using ali.data;
using ali.models;
using Microsoft.EntityFrameworkCore;

namespace ali.repository;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentException("User is null");
        }

        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public Task<User> Modify(int id, User user)
    {
        throw new NotImplementedException();
    }


    public async Task<User> FindById(int userId)
    {
        return await dbContext.Users.FindAsync(userId) ?? throw new AggregateException("User not found");
    }
}