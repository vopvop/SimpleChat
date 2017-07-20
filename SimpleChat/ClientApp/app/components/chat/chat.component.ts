import { Component } from '@angular/core';

@Component({
	selector: 'chat',
	templateUrl: './chat.component.html'
})
export class ChatComponent {
	public currentMessage: ChatMessage;

	constructor() {
		this.currentMessage = new ChatMessage();

		this.currentMessage.id = "message Id";
		this.currentMessage.message = "chat messae";
	}
}

export class ChatMessage {
	id: string;
	message: string;
}