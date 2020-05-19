using Chat.Models;
using Chat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Create(Message message)
        {
            return await _messageService.Create(message);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Message>> GetById(long id)
        {
            var message = await _messageService.GetById(id);

            if (message == null)
                return NotFound();

            return message;
        }

        [HttpGet]
        [Route("get-by-user")]
        public async Task<ActionResult<List<Message>>> GetByUserId(long userId)
        {
            var messages = await _messageService.GetByUserId(userId);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet]
        [Route("get-by-user-in-date-range")]
        public async Task<ActionResult<List<Message>>> GetByUserIdInDateRange(long userId, DateTime startDate, DateTime endDate)
        {
            var messages = await _messageService.GetByUserIdInDateRange(userId, startDate, endDate);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet]
        [Route("get-by-chat-in-date-range")]
        public async Task<ActionResult<List<Message>>> GetByChatIdInDateRange(long chatId, DateTime startDate, DateTime endDate)
        {
            var messages = await _messageService.GetByChatIdInDateRange(chatId, startDate, endDate);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet]
        [Route("get-by-chat-and-user")]
        public async Task<ActionResult<List<Message>>> GetByChatIdAndUserId(long chatId, long userId)
        {
            var messages = await _messageService.GetByChatIdAndUserId(chatId, userId);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet]
        [Route("get-by-chat-and-user-in-date-range")]
        public async Task<ActionResult<List<Message>>> GetByChatIdAndUserIdInDateRange(long chatId, long userId, DateTime startDate, DateTime endDate)
        {
            var messages = await _messageService.GetByChatIdAndUserIdInDateRange(chatId, userId, startDate, endDate);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet]
        [Route("get-by-chat")]
        public async Task<ActionResult<List<Message>>> GetByChatId(long chatId)
        {
            var messages = await _messageService.GetByChatId(chatId);

            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpPut]
        public async Task<ActionResult<Message>> Update(Message message)
        {
            return await _messageService.Update(message);

        }

        [HttpDelete]
        public ActionResult<Message> Delete(Message message)
        {
            return _messageService.Delete(message);
        }
    }
}
