namespace TodoList.Application.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#FF5733"; 

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}