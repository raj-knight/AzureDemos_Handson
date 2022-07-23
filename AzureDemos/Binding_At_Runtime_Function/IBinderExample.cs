using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Binding_At_Runtime_Function
{
    public static class IBinderExample
    {

        // Azure Blob storage output binding for Azure Functions

        //  imperative binding pattern, as opposed to the declarative 

        [FunctionName("Function1")]
        public static async Task Run(
            [EventHubTrigger("samples-workitems", Connection = "")] EventData[] events,
            
            // declarative binding - output
            // [Blob("sample-images-sm/{name}", FileAccess.Write)] Stream imageSmall,

            // Imperative binding (runtime) - output
             IBinder binder,
             ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    var myQueueItem = "sampleblob";

                    // Single attribute
                    using (var writer = binder.Bind<TextWriter>(new BlobAttribute(
                    $"samples-output/{myQueueItem}", FileAccess.Write)))
                    {
                        writer.Write("Hello World!");
                    };

                    // Multiple attribute
                    var attributes = new Attribute[]
                    {
                    new BlobAttribute($"samples-output/{myQueueItem}", FileAccess.Write),
                    new StorageAccountAttribute("MyStorageAccount")
                    };
                    using (var writer = await binder.BindAsync<TextWriter>(attributes[0]))
                    {
                        await writer.WriteAsync("Hello World!!");
                    }

                    // Replace these two lines with your processing logic.
                    log.LogInformation($"C# Event Hub trigger function processed a message: {eventData.EventBody}");
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}
