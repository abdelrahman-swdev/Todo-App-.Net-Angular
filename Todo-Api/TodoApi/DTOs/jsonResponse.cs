using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DTOs
{
    public class jsonResponse
    {
        public object Data { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
