namespace TodoList.Application.DTOs;

public record UpdateTodoItemDto
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public int Priority { get; init; } = 1;
    public DateTime DueDate { get; init; }
    public int? CategoryId { get; init; }
    public List<int> TagIds { get; init; } = new();
}