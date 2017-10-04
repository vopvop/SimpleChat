import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { HubConnection } from "@aspnet/signalr-client";

import { ChatMessageModel } from '../../models/ChatMessageModel';
import { CreateChatMessageModel } from '../../models/CreateChatMessageModel';

@Component({
	selector: 'chat',
	templateUrl: './chat.component.html'
})
export class ChatComponent {

	public currentMessage: string = "enter your text";

	public chatMessages: ChatMessageModel[];

	private chatHub: HubConnection;

	private http: Http;

	private originUrl: string;

	public connected: boolean = false;

	constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string)
	{
		this.http = http;
		this.originUrl = originUrl;

		this.chatHub = new HubConnection(originUrl + "/chathub");

		this.chatHub.on(
			"Send",
			data => this.receiveMessage(data));

		this.chatHub
			.start()
			.catch(error => console.log(error));

		this.connected = true;
	}

	private receiveMessage(data: any)
	{
		if (this.chatMessages == null)
			this.chatMessages = [];

		let chatMessage = data as ChatMessageModel;

		this.chatMessages.push(chatMessage);
	}

	sendMessage()
	{
		if (this.connected == false)
		{
			alert("Please, wait...");

			return;
		}

		if (this.currentMessage == "")
		{
			alert("Please, enter your message");

			return;
		}

		let newMessage = new CreateChatMessageModel();

		newMessage.Message = this.currentMessage;

		var url = this.originUrl + "/api/chat";

		let header = new Headers({ 'Content-Type': 'application/json' });
		let options = new RequestOptions({ headers: header });

		this.http.post(url, newMessage, options)
			.subscribe(data => {
				this.currentMessage = "";
			}, error => {
				console.log(JSON.stringify(error.json()));
			});
	}
}