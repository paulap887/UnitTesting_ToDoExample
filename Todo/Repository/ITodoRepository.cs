using System;
using Todo.models;

namespace Todo.Repository
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetTodoItem(int id);
        Task AddTodoItem(TodoItem item);
        Task UpdateTodoItem(int id, TodoItem item);
        Task DeleteTodoItem(int id);
    }
}

