namespace TodoList.Application.DTOs;

public record TodoItemDto
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public int Priority { get; init; }
    public DateTime DueDate { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public UserDto User { get; init; } = null!;
    public CategoryDto? Category { get; init; }
    public List<TagDto> Tags { get; init; } = new();
}