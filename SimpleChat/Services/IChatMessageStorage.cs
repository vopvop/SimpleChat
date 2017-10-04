namespace SimpleChat.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	internal interface IChatMessageStorage
	{
		Task<IEnumerable<ChatMessageModel>> GetAll();

		Task<ChatMessageModel> Get(Guid messageUid);

		Task Push(ChatMessageModel chatMessage);
	}
}