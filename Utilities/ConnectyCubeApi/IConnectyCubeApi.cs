using ChatboxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Utilities.ConnectyCubeApi
{
    public interface IConnectyCubeApi
    {
        Task<CreatSessionWithUserAuthorizationModel> CreateSessionWithUserAuth(SessionObject session);
    }
}
