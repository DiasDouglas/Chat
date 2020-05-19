using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Services
{
    public interface IMessageService
    {
        Task<ActionResult<Message>> Create(Message message);
        Task<ActionResult<Message>> GetById(long id);
        Task<ActionResult<List<Message>>> GetByUserId(long userId);
        Task<ActionResult<List<Message>>> GetByChatId(long chatId);
        Task<ActionResult<List<Message>>> GetByUserIdInDateRange(long userId, DateTime startDate, DateTime endDate);
        Task<ActionResult<List<Message>>> GetByChatIdInDateRange(long chatId, DateTime startDate, DateTime endDate);
        Task<ActionResult<List<Message>>> GetByChatIdAndUserId(long chatId, long userId);
        Task<ActionResult<List<Message>>> GetByChatIdAndUserIdInDateRange(long chatId, long userId, DateTime startDate, DateTime endDate);
        Task<ActionResult<Message>> Update(Message message);
        ActionResult<Message> Delete(Message message);

    }
}
