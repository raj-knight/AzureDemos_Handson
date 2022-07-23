using DomainLayer.ToDo;

namespace DataAccessLayer.ToDo
{

    public class SqlToDoRepository : IToDoRepository
    {
        private readonly TodoContext context;

        public SqlToDoRepository(TodoContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }

        public async Task CreateToDoAsync(TodoEf todoEf)
        {
            await context.Todos.AddAsync(todoEf);
            await context.SaveChangesAsync();
        }

        public void DeleteToDo(TodoEf todoEf)
        {
            throw new NotImplementedException();
        }

        public TodoEf GetToDoByID()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoEf> GetToDos()
        {
            return
                    from todo in context.Todos
                    select todo;

        }

        public async Task UpdateToDoAsync(string id, string taskDesc)
        {
            var todo = await context.Todos.FindAsync(Guid.Parse(id));
                       
             todo.TaskDescription = taskDesc;
            
            await context.SaveChangesAsync();
        }
    }

}