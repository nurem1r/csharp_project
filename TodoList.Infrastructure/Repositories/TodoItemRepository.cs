using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoList.Infrastructure.Entities;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories;

public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
{
    private readonly TodoListDbContext _context;

    public TodoItemRepository(TodoListDbContext context) : base(context)
    {
        _context = context;
    }

   
    private IQueryable<TodoItem> GetWithIncludes()
    {
        return _context.TodoItems
            .Include(t => t.User)
            .Include(t => t.Category)
            .Include(t => t.Tags);
    }

    public async Task<List<TodoItem>> GetByUserIdAsync(int userId)
    {
        return await GetWithIncludes()
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Priority)
            .ThenBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoItem>> GetByCategoryAsync(int categoryId, int userId)
    {
        return await GetWithIncludes()
            .Where(t => t.CategoryId == categoryId && t.UserId == userId)
            .OrderByDescending(t => t.Priority)
            .ToListAsync();
    }

    public async Task<List<TodoItem>> GetByPriorityAsync(int priority, int userId)
    {
        return await GetWithIncludes()
            .Where(t => t.Priority == priority && t.UserId == userId)
            .OrderBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoItem>> GetOverdueAsync(int userId)
    {
        return await GetWithIncludes()
            .Where(t => t.UserId == userId && t.DueDate < DateTime.UtcNow && !t.IsCompleted)
            .OrderBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoItem>> GetCompletedAsync(int userId)
    {
        return await GetWithIncludes()
            .Where(t => t.UserId == userId && t.IsCompleted)
            .OrderByDescending(t => t.UpdatedAt)
            .ToListAsync();
    }
}