using Chat.Data;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChatContext _context;

        public MessageService(ChatContext context)
        {
            _context = context;
        }

        public async Task<Message> Create(Message message)
        {
            message.Date = DateTime.UtcNow;

            var createdMessage = await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return createdMessage.Entity;
        }

        public Message Delete(Message message)
        {
            var messageDeleted = _context.Remove(message);
            _context.SaveChanges();
            return messageDeleted.Entity;
        }

        public async Task<List<Message>> GetByChatId(long chatId)
        {
            return await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
        }

        public async Task<List<Message>> GetByChatIdAndUserId(long chatId, long userId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId && m.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Message>> GetByChatIdAndUserIdInDateRange(long chatId, long userId, DateTime startDate, DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date.AddDays(1);

            return await _context.Messages
                .Where(m => m.ChatId == chatId && m.UserId == userId && 
                    m.Date >= startDate && m.Date < endDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetByChatIdInDateRange(long chatId, DateTime startDate, DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date.AddDays(1);

            return await _context.Messages
                .Where(m => m.ChatId == chatId && m.Date >= startDate && m.Date < endDate)
                .ToListAsync();
        }

        public async Task<Message> GetById(long id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<List<Message>> GetByUserId(long userId)
        {
            return await _context.Messages.Where(m => m.UserId == userId).ToListAsync();
        }

        public async Task<List<Message>> GetByUserIdInDateRange(long userId, DateTime startDate, DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date.AddDays(1);

            return await _context.Messages
                .Where(m => m.UserId == userId && m.Date >= startDate && m.Date < endDate)
                .ToListAsync();
        }

        public async Task<Message> Update(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return message;
        }
    }
}
