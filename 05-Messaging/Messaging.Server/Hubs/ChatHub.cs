using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Messaging.Server.Hubs
{
    public class UserConnection
    {
        public string ConnectionId { get; set; }
        public string UserId { get; set; }
    }
    public class ChatHub:Hub
    {
        private List<UserConnection> chatConnections = new List<UserConnection>();
        public override async Task OnConnectedAsync()
        {
           if(!this.chatConnections.Any(item=>item.ConnectionId== Context.ConnectionId))
            {
                chatConnections.Add(new UserConnection() { ConnectionId = Context.ConnectionId });
            }
            await this.Clients.Caller.SendAsync("onChatInit", Context.ConnectionId,chatConnections);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var itemToRemove = this.chatConnections.SingleOrDefault(item => item.ConnectionId == Context.ConnectionId);
            if (itemToRemove != null)
            {
                chatConnections.Remove(itemToRemove);
            }
            await this.Clients.All.SendAsync("onChatDestroy", this.Context.ConnectionId,this.chatConnections);


        }
        public async Task BroadcastMessage(string user, string message)
        {
            await Clients.All.SendAsync("GlobalMessageTopic", Context.ConnectionId,user, message,this.chatConnections);
            
        }
        public async Task SendToSpecificUser(string connectionId,string userName, string message)
        {

            string fromUserId = Context.ConnectionId;
           
             await   Clients.Client(connectionId).SendAsync(userName,message);

                // send to caller user
             await Clients.Caller.SendAsync(userName, message);
            

        }
    }
    
}
