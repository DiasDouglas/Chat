using Chat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services.User
{
    public class UserService : IUserService
    {
        private readonly ChatContext _context;

        public UserService(ChatContext context)
        {
            _context = context;
        }

        public async Task<Models.User> Create(Models.User user)
        {
            user.Password = Security.HashPassword(user.Password);
            var createdUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return createdUser.Entity;
        }

        public async Task<Models.User> Delete(Models.User user)
        {
            var removedUser = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return removedUser.Entity;
        }

        public async Task<Models.User> GetByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Models.User> GetById(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public List<Models.User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<Models.User> Update(Models.User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
