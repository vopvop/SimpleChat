using System.ComponentModel.DataAnnotations;

namespace SimpleChat.Models
{
	/// <summary>
	/// New chat message
	/// </summary>
	public sealed class ChatNewMessageModel
	{
		/// <summary>
		/// Chat message text
		/// </summary>
		[Required]
		public string Message { get; set; }
	}
}