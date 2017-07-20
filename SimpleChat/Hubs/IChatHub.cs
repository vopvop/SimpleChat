namespace SimpleChat.Hubs
{
	using System.Threading.Tasks;

	using SimpleChat.Models;

	public interface IChatHub
	{
		Task Send(ChatMessageModel chatMessage);
	}
}