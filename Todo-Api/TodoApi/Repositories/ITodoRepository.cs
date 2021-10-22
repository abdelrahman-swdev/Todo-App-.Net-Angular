using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<Todo> AddTodoAsync(Todo todo);
        Todo UpdateTodo(Todo todo);
        Task<bool> DeleteTodoAsync(int id);
    }
}
