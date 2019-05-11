using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoMVC2.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDone { get; set; }
        public bool IsFailed { get; set; }
        public int Priority { get; set; }
    }
}
