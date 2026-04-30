using Microsoft.EntityFrameworkCore;
using TodoList.Application.Entities;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    private readonly TodoListDbContext _context;

    public TagRepository(TodoListDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        return await _context.Tags
            .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());
    }

    public async Task<List<Tag>> GetByIdsAsync(List<int> ids)
    {
        return await _context.Tags
            .Where(t => ids.Contains(t.Id))
            .ToListAsync();
    }
}