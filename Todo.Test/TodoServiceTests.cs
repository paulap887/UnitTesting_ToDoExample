using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Todo.Data;
using Todo.models;
using Todo.Repository;
using Todo.Services;

namespace Todo.Test
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _mockRepository;
        private readonly ITodoService _service;
        private readonly Mock<TodoContext> _context;

        public TodoServiceTests()
        { 
            _mockRepository = new Mock<ITodoRepository>(); 

            _service = new TodoService(_mockRepository.Object);
        }

        [Fact]
        public async Task CreateTodoItem_CallsAddMethodOnRepository_WhenValidItemIsProvided()
        {
            // Arrange
            var todoItem = new TodoItem { Name = "Todo Item 1", IsComplete = false };

            // Act
            await _service.CreateTodoItem(todoItem);

            // Assert
            _mockRepository.Verify(r => r.AddTodoItem(todoItem), Times.Once);
         }
    }

}

