
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace Messaging.Server
{
    public class MessageInterceptor : BackgroundService
    {
        public  MessageInterceptor()
        {
           var connection = new HubConnectionBuilder().WithUrl("https://localhost:7247/message-hub", options => {
                options.Transports = HttpTransportType.WebSockets;
            }).WithAutomaticReconnect().Build();

            if (connection.State != HubConnectionState.Connected)
            {
                 connection.StartAsync();
                    connection.On<object>("onClientConnect", (message) => {
                    Console.WriteLine(message); //write in the debug console
                    //string newMessage1;
                    //var newMessage = JsonConvert.DeserializeObject<dynamic>(message.ToString());
                    //newMessage1 = $"{newMessage.chainTip}";
                });

                connection.On<object>("onClientDisconnection", (message) => {
                    Console.WriteLine(message); //write in the debug console
                });
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => 
            {
                _ =this.InterceptMessageAsync(stoppingToken);
            },stoppingToken);
        }

        public async Task InterceptMessageAsync (CancellationToken stoppingToken) 
        {
            
            while (!stoppingToken.IsCancellationRequested) 
            {
                // Be careful while writing something, it goes into infine loop
            }
        }
    }
}
