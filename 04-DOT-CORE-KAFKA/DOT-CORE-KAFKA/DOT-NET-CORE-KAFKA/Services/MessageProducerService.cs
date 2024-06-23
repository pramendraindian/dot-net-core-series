using DOT_NET_CORE_KAFKA.Models;
using Confluent.Kafka;
using System.Text.Json;
namespace DOT_NET_CORE_KAFKA.Services
{
    public class MessageProducerService: IMessageProducer 
    {
        public async void SendMessage<T>(string topicName, string key, T message) where T : class
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "my-app",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var packet = new Message<string, string>
                {
                    Key = key,
                    Value = JsonSerializer.Serialize(message)
                };
                var deliveryReport = await producer.ProduceAsync(topicName, packet);
                Console.WriteLine($"Message delivered to {deliveryReport.TopicPartitionOffset}");
            }
        }

    }
}

