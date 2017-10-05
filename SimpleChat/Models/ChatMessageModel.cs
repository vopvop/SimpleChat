namespace SimpleChat.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// Chat message
	/// </summary>
	public sealed class ChatMessageModel
	{
		/// <summary>
		/// Chat message UID
		/// </summary>
		[Required]
		public Guid Id { get; set; }

		/// <summary>
		/// Chat message text
		/// </summary>
		[Required]
		public string Message { get; set; }

		/// <summary>
		/// Chat message received time UTC
		/// </summary>
		[Required]
		public DateTime ReceviedUtc { get; set; }

		[Required]
		public UserInfoModel User { get; set; }

		public ChatMessageModel(string message, DateTime receivedUtc, UserInfoModel user)
		{
			Message = message ?? throw new ArgumentNullException(nameof(message));
			ReceviedUtc = receivedUtc;
			User = user;
		}
	}
}