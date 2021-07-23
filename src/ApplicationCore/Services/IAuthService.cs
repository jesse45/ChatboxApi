using ChatboxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.ApplicationCore.Services
{
    public interface IAuthService
    {
        
        Task<object> SignUpUser(UserModel user);
        Task<object> CreateSessionWithUserAuth(UserModel user);
    }
}
