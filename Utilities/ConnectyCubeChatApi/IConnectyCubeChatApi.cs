using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Utilities.ConnectyCubeChatApi
{
    public interface IConnectyCubeChatApi
    {
        Task<ExpandoObject> CreateDialog();
    }
}
