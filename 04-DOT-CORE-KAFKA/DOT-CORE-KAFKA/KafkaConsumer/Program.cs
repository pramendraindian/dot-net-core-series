using Confluent.Kafka;
using System;
var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "any-group-id-will-work",
    AutoOffsetReset = AutoOffsetReset.Earliest,//It will pick the messages from begining
    //AutoOffsetReset.Latest will pick the messages from beginning
    EnableAutoCommit = false,
    StatisticsIntervalMs = 5000,
    SessionTimeoutMs = 6000,
    EnablePartitionEof = true,
    PartitionAssignmentStrategy = PartitionAssignmentStrategy.CooperativeSticky
};
using (var consumer = new ConsumerBuilder<string, string>(config).Build())
{
    List<string> topics = new List<string>();
    topics.Add("product-topic");
    consumer.Subscribe(topics);
    try
    {
        while (true)
        {
            var result = consumer.Consume();// wait for 5 seconds to timeout
            if (result != null && result.Message != null)
                Console.WriteLine($"Message received from {result.TopicPartitionOffset}: {result.Message.Value}");
        }
    }
    catch (OperationCanceledException)
    {
        // The consumer was stopped via cancellation token.
    }
    finally
    {
        consumer.Close();
    }
    Console.ReadLine();
}