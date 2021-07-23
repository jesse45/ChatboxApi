using ChatboxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.ApplicationCore.Common.Interfaces
{
    public interface IConnectyCubeApi
    {
        public static string ApiKey { get; set; }
        Task<dynamic> CreateSessionWithUserAuth(ExpandoObject session);
        Task<dynamic> CreateSession(ExpandoObject session);
        Task<SignUpUser> SignUpUser(string token, UserModel user);
    }
}
