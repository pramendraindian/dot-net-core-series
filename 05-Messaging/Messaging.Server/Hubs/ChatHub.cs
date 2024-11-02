using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Messaging.Server.Hubs
{
    public class ChatHub:Hub
    {
        
        public override async Task OnConnectedAsync()
        {

        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

        }
        public async Task BroadcastMessage(string user, string message)
        {
            await Clients.All.SendAsync("GlobalMessageTopic", user, message);
        }
    }
    
}
