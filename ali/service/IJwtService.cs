using ali.models;

namespace ali.service;

public interface IJwtService
{
    string GenerateToken(User user);
}