using Chat.Data;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services
{
    public class UserService : IUserService
    {
        private readonly ChatContext _context;

        public UserService(ChatContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            user.Password = Security.HashPassword(user.Password);
            user.CreationDate = DateTime.UtcNow;
            var createdUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return createdUser.Entity;
        }

        public async Task< User> Delete( User user)
        {
            var removedUser = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return removedUser.Entity;
        }

        public async Task< User> GetByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task< User> GetById(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public List< User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task< User> Update( User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
