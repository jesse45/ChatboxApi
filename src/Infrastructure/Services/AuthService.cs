using AutoMapper;
using ChatboxApi.ApplicationCore.Common.Interfaces;
using ChatboxApi.ApplicationCore.Services;
using ChatboxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatboxApi.Infrastructure.Services
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
        public async Task<object> SignUpUser(UserModel user)
        {
            //call api here
            UserModel newUSer = new UserModel();
            ConnectyCubeUtils connectyCube = new ConnectyCubeUtils();
            ExpandoObject session = await connectyCube.GenerateSessionParams(newUSer);

            
            /*string signSession = connectyCube.SignParams(session); */
            /*Console.WriteLine(JsonSerializer.Serialize(session));*/

            CreateSessionObj createSession = await _connectyCubeApi.CreateSession(session);
            

            var signupResponse = await _connectyCubeApi.SignUpUser(createSession.session.token, user);
            
            return signupResponse;
        }

        public async Task<object> CreateSessionWithUserAuth(UserModel user)
        {
            ConnectyCubeUtils connectyCube = new ConnectyCubeUtils();
            ExpandoObject session = await connectyCube.GenerateSessionParams(user);
            var createSessionWithUserAuth = await _connectyCubeApi.CreateSessionWithUserAuth(session);

            return createSessionWithUserAuth;
        }
        
     
    }
}
