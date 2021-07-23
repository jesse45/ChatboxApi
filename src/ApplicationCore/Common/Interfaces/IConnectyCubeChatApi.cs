using ChatboxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.ApplicationCore.Common
{
    public interface IConnectyCubeChatApi
    {
        Task<ExpandoObject> CreateDialog(DialogParams dialogParams);
    }
}
