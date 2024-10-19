using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net;

namespace Messaging.Server
{
    public class MessagingHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("onClientConnect", $"Client Id #{this.Context.ConnectionId} connected!!");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await this.Clients.All.SendAsync("onClientDisconnection", $"Client Id #{this.Context.ConnectionId} disconnected!!");
           
        }
    }
    
}
