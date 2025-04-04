import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class ChatService {
  public hubConnection: signalR.HubConnection;
  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7247/chat-hub',
        {
           skipNegotiation: true //Important configuration
          ,transport: signalR.HttpTransportType.WebSockets //Important configuration
        })
      .build();
    this.hubConnection.start()
      .catch(err => console.error(err));
  }
  broadcastMessage(user: string, message: string): void {
    this.hubConnection.invoke('BroadcastMessage', user, message)
      .catch(err => console.error(err));
  }

  sendPrivateMessage(toConnectionId:string,user: string, message: string): void {
    this.hubConnection.invoke('SendPrivateMessage',toConnectionId, user, message)
      .catch(err => console.error(err));
  }
}
