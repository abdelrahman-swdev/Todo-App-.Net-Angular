using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepo;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<jsonResponse> GetAllTodosAsync()
        {
            IEnumerable<Todo> todos = await _todoRepo.GetAllTodosAsync();
            IEnumerable<TodoDTO> dtos = _mapper.Map<IEnumerable<TodoDTO>>(todos);

            return new jsonResponse
            {
                Data = dtos,
                Success = true,
                Error = string.Empty,
            };
        }

        [HttpGet("{id:int}")]
        public async Task<jsonResponse> GetByIdAsync([FromRoute] int id)
        {
            Todo todo = await _todoRepo.GetByIdAsync(id);
            if (todo is null) return new jsonResponse() { Error = "item not found" };
            TodoDTO dto = _mapper.Map<TodoDTO>(todo);

            return new jsonResponse
            {
                Data = dto,
                Success = true,
                Error = string.Empty,
            };
        }

        [HttpPost]
        public async Task<jsonResponse> AddTodoAsync([FromBody] TodoDTO dto)
        {
            if (ModelState.IsValid)
            {
                Todo todo = _mapper.Map<Todo>(dto);
                var result = await _todoRepo.AddTodoAsync(todo);
                if (result is null) return new jsonResponse() { Error = "item didn't added, some thing went wrong" };
                return new jsonResponse
                {
                    Data = result,
                    Success = true,
                    Error = string.Empty
                };
            }

            return new jsonResponse
            {
                Error = "item didn't added, data didn't sent in valid format"
            };
        }

        [HttpDelete("{id:int}")]
        public async Task<jsonResponse> DeleteTodoAsync([FromRoute]int id)
        {
            bool result = await _todoRepo.DeleteTodoAsync(id);
            if (!result) return new jsonResponse { Error ="item already deleted or something went wrong" };
            return new jsonResponse
            {
                Data = id,
                Success = true,
                Error = string.Empty
            };
        }

        [HttpPut("{id:int}")]
        public jsonResponse UpdateTodoAsync([FromRoute]int id, [FromBody] TodoDTO dto)
        {
            if (id != dto.Id)
            {
                return new jsonResponse { Error = "item not found" };
            }

            Todo todo = _mapper.Map<Todo>(dto);
            var result = _todoRepo.UpdateTodo(todo);
            if (result is null) return new jsonResponse { Error = "something went wrong" };
            return new jsonResponse
            {
                Data = result,
                Success = true,
                Error = string.Empty
            };
        }
    }
}
