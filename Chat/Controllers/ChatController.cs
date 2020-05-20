using Chat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Models.Chat>> GetById(long id)
        {
            var chat = await _chatService.GetById(id);

            if (chat == null)
                return NotFound();

            return chat;
        }

        [HttpGet]
        [Route("get-by-user")]
        public async Task<List<Models.Chat>> GetByUserId(long id)
        {
            return await _chatService.GetByUserId(id);
        }

        [HttpPost]
        public async Task<Models.Chat> Create(Models.Chat chat)
        {
            return await _chatService.Create(chat);
        }

        [HttpPut]
        public async Task<Models.Chat> Update(Models.Chat chat)
        {
            return await _chatService.Update(chat);
        }
    }
}
