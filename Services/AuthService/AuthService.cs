using AutoMapper;
using ChatboxApi.Dtos;
using ChatboxApi.Models;
using ChatboxApi.Utilities;
using ChatboxApi.Utilities.ConnectyCubeApi;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatboxApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConnectyCubeApi _connectyCubeApi;

        public AuthService(IMapper mapper, IHttpClientFactory clientFactory, IConnectyCubeApi connectyCubeApi)
        {
            _mapper = mapper;
            _clientFactory = clientFactory;
            _connectyCubeApi = connectyCubeApi;

        }
        public async Task<CreatSessionWithUserAuthorizationModel> CreateSession(UserModel user)
        {

            
            //call api here
            string signature = "";
            string errorString;
            
            ConnectyCubeUtils connectyCube = new ConnectyCubeUtils();
            SessionObject session = await connectyCube.GenerateSessionParams(user);

            /*var response = _mapper.Map<SessionDto>(session);*/
            /*string signSession = connectyCube.SignParams(session); */
            Console.WriteLine(JsonSerializer.Serialize(session));


            var createSession = _connectyCubeApi.CreateSessionWithUserAuth(session);

            return await createSession;
        }

    }
}
