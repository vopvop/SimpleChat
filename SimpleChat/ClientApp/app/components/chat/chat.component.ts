import { Component } from '@angular/core';

@Component({
	selector: 'chat',
	templateUrl: './chat.component.html'
})
export class ChatComponent {

	chatMessage: ChatMessage = new ChatMessage();

	sendMessage()
	{
		alert(this.chatMessage.message);
	}
}

export class ChatMessage {
	id: string = "-1";
	message: string = "new message";
}