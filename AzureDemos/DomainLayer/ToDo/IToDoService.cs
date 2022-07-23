using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ToDo
{
    public interface IToDoService
    {
        IEnumerable<TodoEf> GetToDos();
        TodoEf GetToDoByID();
        void CreateToDo(TodoEf todoEf);
        void UpdateToDo(string id, string taskDesc);
        void DeleteToDo(TodoEf todoEf);
    }
}
