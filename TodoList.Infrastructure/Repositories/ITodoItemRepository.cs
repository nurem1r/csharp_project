using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Repositories;

public interface ITodoItemRepository : IGenericRepository<TodoItem>
{
    Task<List<TodoItem>> GetByUserIdAsync(int userId);
    Task<List<TodoItem>> GetByCategoryAsync(int categoryId, int userId);
    Task<List<TodoItem>> GetByPriorityAsync(int priority, int userId);
    Task<List<TodoItem>> GetOverdueAsync(int userId);
    Task<List<TodoItem>> GetCompletedAsync(int userId);
}