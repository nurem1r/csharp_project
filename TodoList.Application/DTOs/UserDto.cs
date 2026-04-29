namespace TodoList.Application.DTOs;

public record UserDto
{
    public int Id { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
}