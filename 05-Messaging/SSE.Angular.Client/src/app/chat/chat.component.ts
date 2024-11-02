import { Component } from '@angular/core';
import { ChatService } from '../Services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  connectionId=''
  user = '';
  message = '';
  messages: string[] = [];
  constructor(private chatService: ChatService) {
    this.subscribeChatHubEvents();
  }
  broadcastMessage(): void {
    this.chatService.broadcastMessage(this.user, this.message);
    this.message = '';
  }

  subscribeChatHubEvents()
  {
    this.chatService.hubConnection.on('GlobalMessageTopic', (connectionId,user, message,allConnectedIds) => {
      console.log(`Message From ConnectionId: ${connectionId}, User: ${user}, Message: ${message}`);
      console.log(allConnectedIds);
      if(this.connectionId===connectionId){
        this.messages.push(`You pinged: ${message}`);
      }else{
      this.messages.push(`ConnectionId [${connectionId}] pinged : ${message}`);
    }
    });
    this.chatService.hubConnection.on('onChatInit', (connectionId,allConnectedIds) => {
      console.log(`Connection Id: ${connectionId} joined the chat`);
      console.log(allConnectedIds);
      this.connectionId=connectionId;
      //alert(`Connection Id: ${connectionId}`);
    });
    this.chatService.hubConnection.on('onChatDestroy', (connectionId,allConnectedIds) => {
      console.log(`Connection Id: ${connectionId} left the chat !!!`);
      console.log(allConnectedIds);
      this.messages.push(`ConnectionId [${connectionId}] left the chat !!`);
      //alert(`Connection Id: ${connectionId}`);
    });
  }
}
