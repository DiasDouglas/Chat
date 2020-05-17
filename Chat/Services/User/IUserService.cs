using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Chat.Services
{
    public interface IUserService
    {
        List<Models.User> GetUsers();
        Task<Models.User> GetById(long id);
        Task<Models.User> Create(Models.User user);
        Task<Models.User> Update(Models.User user);
        Task<Models.User> Delete(Models.User user);
    }
}
