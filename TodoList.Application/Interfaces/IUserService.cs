using TodoList.Application.DTOs;

namespace TodoList.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(string email, string username);
}