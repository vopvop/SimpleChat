using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleChat.Models;

namespace SimpleChat.Services
{
	public interface IChatService
	{
		Task<IReadOnlyCollection<ChatMessageModel>> GetAllAsync();

		Task<ChatMessageModel> GetAsync(Guid messgeUid);

		Task<ChatMessageModel> SendAsync(string message);
	}
}