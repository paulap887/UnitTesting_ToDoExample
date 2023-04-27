using System;
using Todo.Data;
using Todo.models;

namespace Todo.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task AddTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoItem(int id, TodoItem item)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new Exception("Todo item not found");
            }

            todoItem.Name = item.Name;
            todoItem.IsComplete = item.IsComplete;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new Exception("Todo item not found");
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }
    }

}

