using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Repositories;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetByNameAsync(string name);
    Task<List<Tag>> GetByIdsAsync(List<int> ids);
}