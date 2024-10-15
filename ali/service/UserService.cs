using ali.controller.dto;
using ali.models;
using ali.repository;
using AutoMapper;

namespace ali.service;

public class UserService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService) : IUserService
{
    public async Task<UserDTO> Register(UserDTO dto)
    {
        // var user = mapper.Map<User>(dto);

        CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var userHashed = new User()
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
        };

        await userRepository.CreateUserAsync(userHashed);

        return mapper.Map<UserDTO>(userHashed);
    }

    public async Task<UserResponse> Login(string username, string password)
    {
        var userFound = await userRepository.FindByUsername(username);
        VerifyPassword(password, userFound.PasswordHash, userFound.PasswordSalt);
        string token = jwtService.GenerateToken(userFound);
        
        return new UserResponse()
        {
            Username = userFound.Username,
            Email = userFound.Email,
            Token = token
        };
    }

    public async Task<UserDTO> Update(int id, UserDTO dto)
    {
        var user = mapper.Map<User>(dto);

        var updatedUser = await userRepository.Modify(id, user);

        return mapper.Map<UserDTO>(updatedUser);
    }

    public async Task<User> GetById(int userId)
    {
        return await userRepository.FindById(userId);
    }

    public async Task<List<UserDTO>> GetAllUsers()
    {
        List<User> users = await userRepository.FindAll();
        return mapper.Map<List<UserDTO>>(users);
    }


    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private void VerifyPassword(string password, byte[] storedHash, byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
        byte[] computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        bool isEqual = computeHash.SequenceEqual(storedHash);
        if (!isEqual)
        {
            throw new System.Exception("Hash doesn't match");
        }
    }
}