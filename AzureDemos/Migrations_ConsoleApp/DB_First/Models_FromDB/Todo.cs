using System;
using System.Collections.Generic;

namespace Migrations_ConsoleApp.Models_FromDB
{
    public partial class Todo
    {
        public Guid Id { get; set; }
        public string TaskDescription { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
