using ali.controller.dto;
using ali.models;
using ali.repository;
using AutoMapper;

namespace ali.service;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<UserDTO> Create(UserDTO dto)
    {
        var user = mapper.Map<User>(dto);
        await userRepository.CreateUserAsync(user);
        return mapper.Map<UserDTO>(user);
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
        var result = await userRepository.FindAll();

        return mapper.Map<List<UserDTO>>(result);
    }
}