using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Threading.Tasks;
using System.Dynamic;
using ChatboxApi.ApplicationCore.Common;
using ChatboxApi.ApplicationCore.Common.Interfaces;
using ChatboxApi.Domain.Models;

namespace ChatboxApi.Infrastructure.ClientApi
{
    public class ConnectyCubeApi : IConnectyCubeApi
    {
        private readonly HttpClient _httpClient;

        public ConnectyCubeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<dynamic> CreateSessionWithUserAuth(ExpandoObject session)
        {
            Console.WriteLine("CreatSessionWithUsrAuth");
            Console.WriteLine(JsonSerializer.Serialize(session));
            CreatSessionWithUserAuthorizationModel responseStream = new CreatSessionWithUserAuthorizationModel();
            /*var request = new HttpRequestMessage(HttpMethod.Post, "https://api.connectycube.com/session");*/
            var httpBody = new StringContent(JsonSerializer.Serialize(session), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await _httpClient.PostAsync("/session", httpBody))
            {
                try
                {
                    response.EnsureSuccessStatusCode();

                    //error prone when creating a new user handle exception for las_updated_at
                    responseStream = await response.Content.ReadFromJsonAsync<CreatSessionWithUserAuthorizationModel>();
                    Console.WriteLine(responseStream.session.token);
                    IConnectyCubeApi.ApiKey = responseStream.session.token;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Data);
                }
                
            }
           
            Console.WriteLine(JsonSerializer.Serialize(responseStream));
            //check if responese stream is null
            return responseStream;
        }

        public async Task<dynamic> CreateSession(ExpandoObject session)
        {
            /*Console.WriteLine("In the createsession");
            Console.WriteLine(JsonSerializer.Serialize(session));*/
            var httpBody = new StringContent(JsonSerializer.Serialize(session), Encoding.UTF8, "application/json");
           /* dynamic myObj = new ExpandoObject();*/
            CreateSessionObj myObj = new CreateSessionObj();
            using (HttpResponseMessage response = await _httpClient.PostAsync("/session", httpBody))
            {
                try
                {
                    response.EnsureSuccessStatusCode();

                    myObj = await response.Content.ReadFromJsonAsync<CreateSessionObj>();

                    /*if(response.IsSuccessStatusCode)
                    {
                        responseStream = await response.Content.ReadFromJsonAsync<CreatSessionWithUserAuthorizationModel>();

                    }
                    else
                    {
                        using var content = response.Content.ReadAsStringAsync();


                    }*/
                    /* Console.WriteLine(myObj);*/

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    using var content = response.Content.ReadAsStringAsync();

                    return content;

                }
            }
           
            return myObj;
        }

        public async Task<SignUpUser> SignUpUser(string token, UserModel _user)
        {
            Console.WriteLine(JsonSerializer.Serialize(_user));
            Console.WriteLine("Token: " + token);

            dynamic user = new ExpandoObject();

            user.user = new
            {
                login = _user.Login,
                password = _user.Password,
                email = _user.Email,
                full_name = _user.Full_Name,
                phone = _user.Phone,
                website = _user.Website
            };

            var httpBody = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "/users");
            request.Headers.Add("CB-Token", token);
            request.Content = httpBody;
            SignUpUser signUpUser = default;
            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();

                    signUpUser = await response.Content.ReadFromJsonAsync<SignUpUser>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    using var content = response.Content.ReadAsStringAsync();

                }
            }

            /* using var content = request.Content.ReadAsStringAsync();*/

            Console.WriteLine(JsonSerializer.Serialize(signUpUser));
            return signUpUser;
        }
    }
}
