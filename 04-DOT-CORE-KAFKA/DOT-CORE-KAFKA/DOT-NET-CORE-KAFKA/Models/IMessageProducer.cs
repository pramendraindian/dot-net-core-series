namespace DOT_NET_CORE_KAFKA.Models
{
    public interface IMessageProducer 
    {
        public void SendMessage<T > (string topicName, string key, T message) where T : class;//where T : class

    }
   
}
