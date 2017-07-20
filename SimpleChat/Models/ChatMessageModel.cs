namespace SimpleChat.Models
{
	using System;

	public sealed class ChatMessageModel
	{
		public Guid Id { get; set; }

		public string Message { get; set; }

		public DateTime ReceviedUtc { get; set; }

		public ChatMessageModel(string message, DateTime receivedUtc)
		{
			Message = message ?? throw new ArgumentNullException(nameof(message));
			ReceviedUtc = receivedUtc;
		}
	}
}