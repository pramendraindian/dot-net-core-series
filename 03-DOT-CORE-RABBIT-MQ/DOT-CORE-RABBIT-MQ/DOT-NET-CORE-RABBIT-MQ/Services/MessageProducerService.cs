using DOT_NET_CORE_RABBIT_MQ.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
namespace DOT_NET_CORE_RABBIT_MQ.Services
{
    public class MessageProducerService : IMessageProducer
    {
        public void SendMessageToQueue<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection 
            var connection = factory.CreateConnection();
            
            //Create channel 
            using (var channel = connection.CreateModel())
            {
                //declare the queue 
                channel.QueueDeclare("product-queue", exclusive: false);
                
                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);
                //Push Data to queue
                channel.BasicPublish(exchange: "", routingKey: "product-queue", body: body);
            }
        }
    }
}

