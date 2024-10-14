using ali.data;
using ali.models;
using Microsoft.EntityFrameworkCore;

namespace ali.repository;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    async Task<bool> IUserRepository.SaveChangesAsync()
    {
        return (await dbContext.SaveChangesAsync()) > 0;
    }

    public async Task CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentException("User is null");
        }

        await dbContext.Users.AddAsync(user);
    }

    public async Task<User> Modify(int id, User user)
    {
        var userFound = await dbContext.Users.FindAsync(id);

        if (userFound == null)
        {
            throw new ArgumentException($"User with id {id} not found.");
        }

        User entity = dbContext.Users.Update(user).Entity;

        await dbContext.SaveChangesAsync();

        return entity;
    }
}