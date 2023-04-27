using System;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.models;
using Todo.Repository;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            return await _repository.GetTodoItem(id);
        } 

        public async Task CreateTodoItem(TodoItem item)
        {
            await _repository.AddTodoItem(item);
        }

        public async Task UpdateTodoItem(int id, TodoItem item)
        {
            await _repository.UpdateTodoItem(id, item);
        }

        public async Task DeleteTodoItem(int id)
        {
            await _repository.DeleteTodoItem(id);
        } 
    }

}

