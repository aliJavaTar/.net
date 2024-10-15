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

        await dbContext.Users.AddAsync(user);

        if (await IsNotCommit())
        {
            throw new ApplicationException("User is not created");
        }

        return user;
    }

    public async Task<User> Modify(int id, User user)
    {
        var userFound = FindById(id).Result;

        userFound.Username = user.Username;
        userFound.Email = user.Email;

        if (await IsNotCommit())
        {
            throw new ApplicationException("User not found");
        }

        return userFound;
    }

    public async Task<User> FindByUsername(string username)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        return user ?? throw new ApplicationException("$User not found{ username }");

    }

    public async Task<User> FindById(int userId)
    {
        return await dbContext.Users.FindAsync(userId) ?? throw new AggregateException("User not found");
    }

    public async Task<List<User>> FindAll()
    {
        return await dbContext.Users.ToListAsync() ?? throw new AggregateException("Users not found");
    }

    private async Task<bool> IsNotCommit()
    {
        return await dbContext.SaveChangesAsync() == 0;
    }
}