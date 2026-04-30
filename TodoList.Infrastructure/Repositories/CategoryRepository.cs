using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Entities;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly TodoListDbContext _context;

    public CategoryRepository(TodoListDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }
}