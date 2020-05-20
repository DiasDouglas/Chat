using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Services
{
    public interface IMessageService
    {
        Task<Message> Create(Message message);
        Task<Message> GetById(long id);
        Task<List<Message>> GetByUserId(long userId);
        Task<List<Message>> GetByChatId(long chatId);
        Task<List<Message>> GetByUserIdInDateRange(long userId, DateTime startDate, DateTime endDate);
        Task<List<Message>> GetByChatIdInDateRange(long chatId, DateTime startDate, DateTime endDate);
        Task<List<Message>> GetByChatIdAndUserId(long chatId, long userId);
        Task<List<Message>> GetByChatIdAndUserIdInDateRange(long chatId, long userId, DateTime startDate, DateTime endDate);
        Task<Message> Update(Message message);
        Message Delete(Message message);

    }
}
