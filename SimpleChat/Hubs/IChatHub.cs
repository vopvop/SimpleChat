using System.Threading.Tasks;

using SimpleChat.Models;

namespace SimpleChat.Hubs
{
	public interface IChatHub
	{
		Task Send(ChatMessageModel chatMessage);
	}
}