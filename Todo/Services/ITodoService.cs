using Todo.models;

namespace Todo.Services
{
    public interface ITodoService
    {
        Task<TodoItem> GetTodoItem(int id);
        Task CreateTodoItem(TodoItem item);
        Task UpdateTodoItem(int id, TodoItem item);
        Task DeleteTodoItem(int id);
    }

}