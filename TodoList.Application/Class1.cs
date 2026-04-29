using TodoList.Application.DTOs;

namespace TodoList.Application.Interfaces;

public interface ITodoItemService
{
    // Получить все задачи пользователя
    Task<List<TodoItemDto>> GetAllByUserIdAsync(int userId);

    // Получить задачу по ID
    Task<TodoItemDto?> GetByIdAsync(int id, int userId);

    // Создать задачу
    Task<TodoItemDto> CreateAsync(int userId, CreateTodoItemDto dto);

    // Обновить задачу
    Task<TodoItemDto?> UpdateAsync(int id, int userId, UpdateTodoItemDto dto);

    // Удалить задачу
    Task<bool> DeleteAsync(int id, int userId);

    // Отметить как выполнено
    Task<TodoItemDto?> ToggleCompleteAsync(int id, int userId);

    // Получить задачи по категории
    Task<List<TodoItemDto>> GetByCategoryAsync(int categoryId, int userId);

    // Фильтровать по приоритету
    Task<List<TodoItemDto>> GetByPriorityAsync(int priority, int userId);
}