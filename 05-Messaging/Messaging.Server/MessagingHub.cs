using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Messaging.Server
{
    public class MessagingHub:Hub
    {
        
        public override async Task OnConnectedAsync()
        {
            //Broadcast the message to all the connected consumers
            await this.Clients.All.SendAsync("onClientConnect", $"Client Id #{this.Context.ConnectionId} connected!! User Info : {this.Context?.User?.Identity?.Name}");

            //Send message to the consumer in context
            await this.Clients.Caller.SendAsync("onClientConnect", "Welcome he man");



        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await this.Clients.All.SendAsync("onClientDisconnection", $"Client Id #{this.Context.ConnectionId} disconnected!!");
           
        }
        public async Task BroadcastMessage(string user, string message)
        {
            await Clients.All.SendAsync("GlobalMessageTopic", user, message);
        }
    }
    
}
