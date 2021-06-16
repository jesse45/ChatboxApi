using ChatboxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<CreatSessionWithUserAuthorizationModel> CreateSession(UserModel user);
    }
}
