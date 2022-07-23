namespace DomainLayer.ToDo
{
    public interface IToDoRepository
    {
        IEnumerable<TodoEf> GetToDos();
        TodoEf GetToDoByID();
        Task CreateToDoAsync(TodoEf todoEf);
        Task UpdateToDoAsync(string id, string taskDesc);
        void DeleteToDo(TodoEf todoEf);
    }
}