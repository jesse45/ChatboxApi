using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatboxApi.Domain.Models;

namespace ChatboxApi.ApplicationCore.Services
{   
    public interface IUserService
    {
        void PrintUser();
        UserModel SetUser();

    }
}
