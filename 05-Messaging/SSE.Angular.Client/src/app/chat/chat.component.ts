import { Component } from '@angular/core';
import { ChatService } from '../Services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  user = '';
  message = '';
  messages: string[] = [];
  constructor(private chatService: ChatService) {}
  broadcastMessage(): void {
    this.chatService.broadcastMessage(this.user, this.message);
    this.messages.push(`You: ${this.message}`);
    this.message = '';
  }
}
