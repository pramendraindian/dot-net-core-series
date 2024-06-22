namespace DOT_NET_CORE_RABBIT_MQ.Models
{
    public interface IMessageProducer
    {
        public void SendMessageToQueue<T>(T message);

    }
   
}
