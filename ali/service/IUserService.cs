using ali.controller.dto;
using ali.models;

namespace ali.service;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO dto);
    Task<UserDTO> Update(int id, UserDTO dto);
    Task<User> GetById(int userId);
    Task<List<UserDTO>> GetAllUsers();
}