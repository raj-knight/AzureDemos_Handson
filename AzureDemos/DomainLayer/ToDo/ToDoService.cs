using DomainLayer.Prdct;
using DomainLayer.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ToDo
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository repository; 

        //CONSTRUCTOR INJECTION
        public ToDoService(IToDoRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
          
            this.repository = repository;
        }
      
        IEnumerable<TodoEf> IToDoService.GetToDos()
        {
            return
                from todo in this.repository.GetToDos()
                select todo;
        }

        void IToDoService.CreateToDo(TodoEf todoEf)
        {

            repository.CreateToDoAsync(todoEf);
        }

        void IToDoService.DeleteToDo(TodoEf todoEf)
        {
            throw new NotImplementedException();
        }

        TodoEf IToDoService.GetToDoByID()
        {
            throw new NotImplementedException();
        }

       

        void IToDoService.UpdateToDo(string id, string taskDesc)
        {
            repository.UpdateToDoAsync( id,  taskDesc);
        }
    }
}
