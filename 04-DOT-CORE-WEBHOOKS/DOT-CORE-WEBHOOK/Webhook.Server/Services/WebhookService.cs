namespace Webhook.Server.Services
{

    public record Subscription(string Topic, string Callback);
    record PublishRequest(string Topic, object Message);
    public class WebhookService
    {
        private readonly List<Subscription> _subscriptions = new();
        private readonly HttpClient _httpClient = new();

        public void Subscribe(Subscription subscription)
        {
            _subscriptions.Add(subscription);
        }

        public async Task PublishMessage(string topic, object message)
        {
            var subscribedWebhooks = _subscriptions.Where(w => w.Topic == topic);

            foreach (var webhook in subscribedWebhooks)
            {
                await _httpClient.PostAsJsonAsync(webhook.Callback, message);
                Console.WriteLine("Posted message");
            }
        }
    }
}