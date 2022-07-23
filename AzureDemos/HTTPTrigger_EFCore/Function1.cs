using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DomainLayer.Prdct;
using DomainLayer.ToDo;
using System.Linq;

namespace HTTPTrigger_EFCore
{
    public  class EFCore_Demo
    {
        private readonly IToDoService _toDoService;


        public EFCore_Demo(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [FunctionName("Function1")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log
           //IProductService productService,
           // IToDoService toDoService
            )
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            log.LogInformation("Creating a new todo list item");

            //var input = JsonConvert.DeserializeObject<TodoEf>(requestBody);
            var todo = new TodoEf { TaskDescription = name }; 
            _toDoService.CreateToDo(todo);

            _toDoService
                .GetToDos()?
                .ToList()
                .ForEach(todo => Console.WriteLine(todo.TaskDescription));

            return new OkObjectResult(responseMessage);
        }
    }
}
