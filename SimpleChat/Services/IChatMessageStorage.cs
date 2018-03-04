using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleChat.Models;

namespace SimpleChat.Services
{
	internal interface IChatMessageStorage
	{
		Task<ChatMessageModel> GetAsync(Guid messageUid);

		Task<IReadOnlyCollection<ChatMessageModel>> GetAllAsync();

		Task PushAsync(ChatMessageModel chatMessage);
	}
}