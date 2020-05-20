using Chat.Data;
using Chat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatContext _context;

        public ChatService(ChatContext context)
        {
            _context = context;
        }

        public async Task<Models.Chat> Create(Models.Chat chat)
        {
            var createdChat = await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
            return createdChat.Entity;
        }

        public async Task<Models.Chat> GetById(long id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task<List<Models.Chat>> GetByUserId(long userId)
        {
            return await _context.Chats
                .Where(c => c.ChatUsers.Select(chatUser => chatUser.UserId)
                .Contains(userId))
                .ToListAsync();
        }

        public async Task<Models.Chat> Update(Models.Chat chat)
        {
            _context.Entry(chat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return chat;
        }
    }
}
