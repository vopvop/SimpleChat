import { Component } from '@angular/core';

@Component({
	selector: 'chat',
	templateUrl: './chat.component.html'
})
export class ChatComponent {
	public currentMessage: IChatMessage;

	constructor() {
		this.currentMessage.id = "message Id";
		this.currentMessage.messae = "chat messae";
	}
}

interface IChatMessage {
	id: string;
	messae: string;
}