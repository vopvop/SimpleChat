namespace SimpleChat.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	public interface IChatService
	{
		Task<IEnumerable<ChatMessageModel>> Get();

		Task<ChatMessageModel> Get(Guid messgeUid);

		Task<ChatMessageModel> Send(string message);
	}
}