using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
var factory = new ConnectionFactory
{
    HostName = "localhost"
};
//Create the RabbitMQ connection 
var connection = factory.CreateConnection();
//create channel 
using (var channel = connection.CreateModel())
{
    //declare the queue
    channel.QueueDeclare("product-queue", exclusive: false);
    //Configure the consumer
    var consumer = new EventingBasicConsumer(channel);
    //Add event handler
    consumer.Received += (model, eventArgs) =>
    {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"Product message received: {message}");
    };
    //read the message
    channel.BasicConsume(queue: "product-queue", autoAck: true, consumer: consumer);
    Console.ReadKey();
}
