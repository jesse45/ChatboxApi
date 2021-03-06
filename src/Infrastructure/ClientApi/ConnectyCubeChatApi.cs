using ChatboxApi.ApplicationCore.Common;
using ChatboxApi.ApplicationCore.Common.Interfaces;
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

namespace ChatboxApi.Infrastructure.ClientApi
{
    public class ConnectyCubeChatApi : IConnectyCubeChatApi
    {
        private readonly HttpClient _httpClient;
        private string APIKEY;
        
        

        public ConnectyCubeChatApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ExpandoObject> CreateDialog(DialogParams dialogParams)
        {
            
            var httpBody = new StringContent(JsonSerializer.Serialize(dialogParams), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/chat/Dialog");
            
            if(IConnectyCubeApi.ApiKey == "")
            {

            }
            request.Headers.Add("CB-Token", IConnectyCubeApi.ApiKey);
            var chat = new ExpandoObject();
            using(HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    chat = await response.Content.ReadFromJsonAsync<ExpandoObject>();
                }
                catch(Exception ex)
                {

                }
            }
            return chat;
        }
    }
}
