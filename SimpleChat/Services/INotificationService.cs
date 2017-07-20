namespace SimpleChat.Services
{
	using System.Threading.Tasks;

	using SimpleChat.Models;

	internal interface INotificationService
	{
		Task Push(ChatMessageModel chatMessage);
	}
}