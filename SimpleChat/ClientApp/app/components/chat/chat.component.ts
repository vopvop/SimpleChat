import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { HubConnection, TransportType  } from "@aspnet/signalr";

import { ChatMessageModel } from '../../models/ChatMessageModel';
import { CreateChatMessageModel } from '../../models/CreateChatMessageModel';

@Component({
	selector: 'chat',
	templateUrl: './chat.component.html'
})
export class ChatComponent {

	public currentMessage: string = "";

	public chatMessages: ChatMessageModel[];

	private chatHub: HubConnection;

	private http: Http;

	private originUrl: string;

	public connected: boolean = false;

	constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
		this.http = http;
		this.originUrl = originUrl;

		this.chatHub = new HubConnection(
			originUrl + "/chathub",
			{
				transport: TransportType.WebSockets | TransportType.LongPolling
			});

		this.chatHub.on(
			"Send",
			data => this.receiveMessage(data));

		this.chatHub
			.start()
			.catch(error => console.log(error));

		this.connected = true;
	}

	private receiveMessage(data: any) {
		if (this.chatMessages == null)
			this.chatMessages = [];

		const chatMessage = data as ChatMessageModel;

		this.chatMessages.push(chatMessage);
	}

	sendMessage() {
		if (this.connected === false) {
			alert("Please, wait...");

			return;
		}

		if (this.currentMessage === "") {
			alert("Please, enter your message");

			return;
		}

		const newMessage = new CreateChatMessageModel();

		newMessage.message = this.currentMessage;

		const url = this.originUrl + "/api/chat";

		const header = new Headers({ 'Content-Type': 'application/json' });

		const options = new RequestOptions({ headers: header });

		this.http.post(url, newMessage, options)
			.subscribe(data => {
				this.currentMessage = "";
			}, error => {
				console.log(JSON.stringify(error.json()));
			});
	}
}