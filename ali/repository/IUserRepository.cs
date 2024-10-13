using ali.models;

namespace ali.repository;

public interface IUserRepository
{
    Task<bool> SaveChangesAsync();
    Task CreateUserAsync(User user);
}