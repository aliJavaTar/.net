using ali.controller.dto;

namespace ali.service;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO dto);
    Task<UserDTO> Update(int id, UserDTO dto);
}