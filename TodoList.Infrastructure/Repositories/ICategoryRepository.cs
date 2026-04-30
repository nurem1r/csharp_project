using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category?> GetByNameAsync(string name);
}