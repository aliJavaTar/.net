using ali.models;

namespace ali.repository;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User> Modify(int id, User user);
    Task<User> FindById(int userId);

    Task<List<User>> FindAll();
}