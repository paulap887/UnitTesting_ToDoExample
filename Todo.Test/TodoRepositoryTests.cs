using System;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.models;
using Todo.Repository;

namespace Todo.Test
{
    public class TodoRepositoryTests
    {
        private readonly TodoContext _context;
        private readonly ITodoRepository _repository;

        public TodoRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TodoList")
                .Options;

            _context = new TodoContext(options);
            _repository = new TodoRepository(_context);
        }

        [Fact]
        public async Task GetTodoItem_ReturnsTodoItem_WhenItemExists()
        {
            // Arrange
            var todoItem = new TodoItem { Name = "Todo Item 1", IsComplete = false };
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();

            // Act
            var result = await _repository.GetTodoItem(todoItem.Id);

            // Assert
            Assert.Equal(todoItem, result);
        }

        [Fact]
        public async Task AddTodoItem_AddsItemToDatabase()
        {
            // Arrange
            var todoItem = new TodoItem { Name = "Todo Item 1", IsComplete = false };

            // Act
            await _repository.AddTodoItem(todoItem);

            // Assert
            Assert.Contains(todoItem, _context.TodoItems);
        }

    }

}

