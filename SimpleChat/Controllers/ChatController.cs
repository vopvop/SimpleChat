namespace SimpleChat.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;

	using SimpleChat.Models;
	using SimpleChat.Services;

	/// <summary>
	/// Chat service controller
	/// </summary>
	[Route("api/[controller]")]
	public sealed class ChatController: Controller
	{
		private readonly IChatService _chatService;

		/// <summary>
		/// Chat service controller default constructor
		/// </summary>
		/// <param name="chatService">Chat messaging service</param>
		public ChatController(IChatService chatService)
		{
			_chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
		}

		/// <summary>
		/// Delete chat message
		/// </summary>
		/// <param name="id">Chat message UID</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id) => throw new NotImplementedException();

		/// <summary>
		/// Get all chat messages
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IEnumerable<ChatMessageModel>> Get() => await _chatService.Get();

		/// <summary>
		/// Get chat message
		/// </summary>
		/// <param name="id">Chat message UID</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ChatMessageModel> Get(Guid id) => await _chatService.Get(id);

		/// <summary>
		/// Post new chat message
		/// </summary>
		/// <param name="chatMessage">Chat message text</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ChatMessageModel> Post([FromBody] ChatNewMessageModel chatMessage) =>
			await _chatService.Send(chatMessage.Message);

		/// <summary>
		/// Update chat message
		/// </summary>
		/// <param name="id">Chat message UID</param>
		/// <param name="value">Chat message text</param>
		[HttpPut("{id}")]
		public void Put(Guid id, [FromBody] string value) => throw new NotImplementedException();
	}
}