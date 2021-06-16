using ChatboxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Services.UserService
{
    public interface IUserService
    {
        void PrintUser();
        UserModel SetUser();

    }
}
