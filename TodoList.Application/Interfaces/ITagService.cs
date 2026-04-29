using TodoList.Application.DTOs;

namespace TodoList.Application.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAllAsync();
    Task<TagDto?> GetByIdAsync(int id);
    Task<TagDto> CreateAsync(string name);
    Task<TagDto?> UpdateAsync(int id, string name);
    Task<bool> DeleteAsync(int id);
}