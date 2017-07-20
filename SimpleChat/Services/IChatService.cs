namespace SimpleChat.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	public interface IChatService
	{
		Task<IEnumerable<ChatMessageModel>> Get();

		Task<ChatMessageModel> Send(string message);
	}
}