using ali.controller.dto;
using ali.models;
using ali.repository;
using AutoMapper;

namespace ali.service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public async Task<UserDTO> crate(UserDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        await _userRepository.CreateUserAsync(user);
        await _userRepository.SaveChangesAsync();
        
        return _mapper.Map<UserDTO>(user);

    }
}