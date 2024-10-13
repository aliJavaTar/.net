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
        await userRepository.SaveChangesAsync();

        return mapper.Map<UserDTO>(user);
    }
}