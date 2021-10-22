using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedOn { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
