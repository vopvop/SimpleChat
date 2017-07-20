namespace SimpleChat.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	internal interface IChatMessageStorage
	{
		Task<IEnumerable<ChatMessageModel>> Pull();

		Task Push(ChatMessageModel chatMessage);
	}
}