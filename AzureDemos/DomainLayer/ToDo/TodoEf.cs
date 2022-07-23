using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ToDo
{
    public class TodoEf
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
}
