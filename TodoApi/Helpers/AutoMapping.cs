using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Todo, TodoDTO>().ReverseMap();
        }
    }
}
