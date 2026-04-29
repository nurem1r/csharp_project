using TodoList.Application.DTOs;

namespace TodoList.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<CategoryDto> CreateAsync(string name, string color);
    Task<CategoryDto?> UpdateAsync(int id, string name, string color);
    Task<bool> DeleteAsync(int id);
}