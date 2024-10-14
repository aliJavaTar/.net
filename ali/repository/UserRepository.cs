using ali.data;
using ali.models;
using Microsoft.EntityFrameworkCore;

namespace ali.repository;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentException("User is null");
        }

        var userCreated = dbContext.Users.AddAsync(user).GetAwaiter().GetResult().Entity;

        await dbContext.SaveChangesAsync();

        return userCreated;
    }

    public async Task<User> Modify(int id, User user)
    {
        var userFound = FindById(id).Result;

        userFound.Username = user.Username;
        userFound.Email = user.Email;

        await dbContext.SaveChangesAsync();
        return userFound;
    }


    public async Task<User> FindById(int userId)
    {
        return await dbContext.Users.FindAsync(userId) ?? throw new AggregateException("User not found");
    }

    public async Task<List<User>> FindAll()
    {
       return await dbContext.Users.ToListAsync() ?? throw new AggregateException("Users not found");
    }
}