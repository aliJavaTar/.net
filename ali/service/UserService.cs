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

        await userRepository.Modify(id, user);

        return mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> GetById(int userId)
    {
        var userEntity = await userRepository.FindById(userId);
        return mapper.Map<UserDTO>(userEntity);
    }
}