using ChatboxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatboxApi.Utilities.ConnectyCubeApi
{
    public class ConnectyCubeApi : IConnectyCubeApi
    {
        private readonly HttpClient _httpClient;

        public ConnectyCubeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreatSessionWithUserAuthorizationModel> CreateSessionWithUserAuth(SessionObject session)
        {
            CreatSessionWithUserAuthorizationModel responseStream = new CreatSessionWithUserAuthorizationModel();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.connectycube.com/session");
            var httpBody = new StringContent(JsonSerializer.Serialize(session), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("/session", httpBody);
                response.EnsureSuccessStatusCode();

                responseStream = await response.Content.ReadFromJsonAsync<CreatSessionWithUserAuthorizationModel>();

                /*if(response.IsSuccessStatusCode)
                {
                    responseStream = await response.Content.ReadFromJsonAsync<CreatSessionWithUserAuthorizationModel>();
                    
                }
                else
                {
                    using var content = response.Content.ReadAsStringAsync();
                    
                    
                }*/
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Data);
                /*using var content = response.Content.ReadAsStringAsync();*/

            }
            return responseStream;
        }
    }
}
