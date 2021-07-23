using ChatboxApi.ApplicationCore.Common;
using ChatboxApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Controllers
{
    [ApiController]
    [Route("chat")]
    public class ChatController : ControllerBase
    {
        private readonly IConnectyCubeChatApi _connectyCubeChatApi;

        public ChatController(IConnectyCubeChatApi connectyCubeChatApi) => _connectyCubeChatApi = connectyCubeChatApi; 

        [HttpPost("dialog")]
        public async Task<ActionResult> CreateDialog([FromBody] DialogParams dialogParams)
        {

            return Ok();
        }
    }
}
