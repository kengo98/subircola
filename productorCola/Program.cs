using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace cola1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string ServiceBusConnectionString = "Endpoint=sb://computacionmovil.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+xyuzmOBvcYcw22+hIyF87FcoNWGr+hkVBJMdLbB9SY=";
            string QueueName = "qprueba";
            IQueueClient queueClient;

            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            try
            {
                string messageBody = $"hola esto es un mensaje";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                await queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await queueClient.CloseAsync();

        }
    }

}


