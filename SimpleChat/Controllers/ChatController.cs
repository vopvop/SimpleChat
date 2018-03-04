using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SimpleChat.Models;
using SimpleChat.Services;

namespace SimpleChat.Controllers
{
	/// <summary>
	///     Chat service controller
	/// </summary>
	[Authorize]
	[Route("api/[controller]")]
	public sealed class ChatController : Controller
	{
		private readonly IChatService _chatService;

		/// <summary>
		///     Chat service controller default constructor
		/// </summary>
		/// <param name="chatService">Chat messaging service</param>
		public ChatController(IChatService chatService)
		{
			_chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
		}

		/// <summary>
		///     Get all chat messages
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(ChatMessageModel[]), 200)]
		public async Task<IActionResult> Get()
		{
			return Ok(await _chatService.GetAllAsync());
		}

		/// <summary>
		///     Get chat message
		/// </summary>
		/// <param name="id">Chat message UID</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(ChatMessageModel), 200)]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(await _chatService.GetAsync(id));
		}

		/// <summary>
		///     Post new chat message
		/// </summary>
		/// <param name="chatMessage">Chat message text</param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(typeof(ChatMessageModel), 200)]
		public async Task<IActionResult> Post([FromBody] ChatNewMessageModel chatMessage)
		{
			if (chatMessage == null)
				return BadRequest();

			return Ok(await _chatService.SendAsync(chatMessage.Message));
		}
	}
}