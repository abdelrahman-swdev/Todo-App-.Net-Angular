using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            todo.AddedOn = DateTime.Now;
            todo.CompletedOn = DateTime.Now;
            todo.Completed = false;
            await _context.Todos.AddAsync(todo);
            int result = await _context.SaveChangesAsync();
            return result > 0 ? todo : null;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo is null) return false;
            _context.Todos.Remove(todo);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public Todo UpdateTodo(Todo todo)
        {
            _context.Update(todo);
            var result = _context.SaveChanges();
            return result > 0 ? todo : null;
        }
    }
}
