using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Todo.Controllers;
using Todo.models;
using Todo.Services;

namespace Todo.Test
{
    public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _mockService;
        private readonly TodoController _controller;

        public TodoControllerTests()
        {
            _mockService = new Mock<ITodoService>();
            _controller = new TodoController(_mockService.Object);
        }

        [Fact]
        public async Task GetTodoItem_ReturnsOkResult_WhenItemExists()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Name = "Todo Item 1", IsComplete = false };
            _mockService.Setup(s => s.GetTodoItem(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TodoItem>(okResult.Value);
            Assert.Equal(todoItem.Id, model.Id);
            Assert.Equal(todoItem.Name, model.Name);
            Assert.Equal(todoItem.IsComplete, model.IsComplete);
        }

        [Fact]
        public async Task GetTodoItem_ReturnsNotFoundResult_WhenItemDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetTodoItem(1)).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

}


