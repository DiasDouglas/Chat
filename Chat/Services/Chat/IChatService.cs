using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services
{
    public interface IChatService
    {
        Task<Models.Chat> GetById(long id);
        Task<List<Models.Chat>> GetByUserId(long userId);
        Task<Models.Chat> Create(Models.Chat chat);
        Task<Models.Chat> Update(Models.Chat chat);
    }
}
