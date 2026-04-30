using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<TodoItem>()
            .HasOne(t => t.User)
            .WithMany(u => u.TodoItems)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TodoItem>()
            .HasOne(t => t.Category)
            .WithMany(c => c.TodoItems)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TodoItem>()
            .HasMany(t => t.Tags)
            .WithMany(tag => tag.TodoItems)
            .UsingEntity("TodoItemTag"); 

        var defaultUser = new User
        {
            Id = 1,
            Email = "user@example.com",
            Username = "testuser",
            CreatedAt = DateTime.UtcNow
        };

        var defaultCategory = new Category
        {
            Id = 1,
            Name = "Работа",
            Color = "#FF5733"
        };

        var defaultTag = new Tag
        {
            Id = 1,
            Name = "Срочно"
        };

        modelBuilder.Entity<User>().HasData(defaultUser);
        modelBuilder.Entity<Category>().HasData(defaultCategory);
        modelBuilder.Entity<Tag>().HasData(defaultTag);
    }
}