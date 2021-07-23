using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Utilities
{
    public class DialogType
    {
        enum Dialog {
            Broadcast,
            GroupChat,
            PrivateChat,
            PublicChat
        }
    }
}
