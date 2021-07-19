using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using ChatboxApi.Models;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using AutoMapper;
using System.Dynamic;

namespace ChatboxApi.Utilities
{
    public class Config
    {
        public Cred cred { get; set; }
        public Urls urls { get; set; }
        public Pathnames pathNames { get; set; }
    }

    public class Cred
    {
        public int appId { get; set; }
        public string authKey { get; set; }
        public string authSecret { get; set; }
    }

    public class Urls
    {
        public string api_endpoint { get; set; }
    }

    public class Pathnames
    {
        public string users { get; set; }
        public string session { get; set; }
    }

    public class SessionObject
    {
        public int application_id { get; set; }
        public string auth_key { get; set; }
        public double nonce { get; set; }
        public double timestamp { get; set; }
        public string signature { get; set; }
        public dynamic user { get; set; }
        /*public Dictionary<string, string> user = new Dictionary<string, string>();*/
    }

    public class ConnectyCubeUtils
    {
        private readonly IMapper _mapper;

        public ConnectyCubeUtils() { }
        public ConnectyCubeUtils(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ExpandoObject> GenerateSessionParams(UserModel user)
        {
            string filename = "config.json";
            using FileStream openStream = File.OpenRead(filename);
            Config config = await JsonSerializer.DeserializeAsync<Config>(openStream);


            /*SessionObject session = new SessionObject();*/
            dynamic session = new ExpandoObject();
            double nonce = this.RandomNonce();
            double timestamp = this.GetTimeStamp();
            SortedDictionary<string, string> sessionPairs = new SortedDictionary<string, string>();

            session.application_id = config.cred.appId; 
            session.auth_key = config.cred.authKey;
            session.nonce = nonce;
            session.timestamp = timestamp;

            sessionPairs.Add("application_id", session.application_id.ToString());
            sessionPairs.Add("auth_key", session.auth_key.ToString());
            sessionPairs.Add("nonce", session.nonce.ToString());
            sessionPairs.Add("timestamp", session.timestamp.ToString());


            if (user.Login != default && user.Password != default)
            {
                session.user = new { login = user.Login, password = user.Password };
                sessionPairs.Add("login", user.Login);
                sessionPairs.Add("password", user.Password);

            }
            else if (user.Email != default && user.Password != default)
            {
                session.user = new { email = user.Email, password = user.Password };
                sessionPairs.Add("email", user.Email);
                sessionPairs.Add("password", user.Password);
            }


            var signSession = this.SignParams(sessionPairs);
            /*Console.WriteLine(signSession);*/

            //Console.WriteLine($"authSecret is : {config.cred.authSecret}");

            //convert the session signature string to a byte array
            byte[] signature = Encoding.UTF8.GetBytes(signSession.ToString());

            //converting authsecret to a byte array
            /*byte apiKey = Convert.FromBase64String(config.cred.authSecret);*/
            System.Text.ASCIIEncoding encodeing = new System.Text.ASCIIEncoding();
            var apiKey = Encoding.UTF8.GetBytes(config.cred.authSecret);
             
            //Generate a HMACSHA1 signature
            using(HMACSHA1 hmac = new HMACSHA1(apiKey))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string hexSignature = BitConverter.ToString(signatureBytes).ToLowerInvariant().Replace("-", "");
                //Console.WriteLine(hexSignature);
                session.signature = hexSignature;
            }
            
            Console.WriteLine(session.signature);
            return session;
        }

        /*        public string SignParams(Session userSession)
                {
                    if (userSession.GetType() != typeof(object))
                    {
                        //throw something
                    }
                    Type t = typeof(Session);
                    PropertyInfo[] propertyInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    FieldInfo[] fieldInfos = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    RuntimeTypeHandle myType = typeof(Session).TypeHandle;
                    Console.WriteLine(myType);
                    this.GetPropertyInfo(fieldInfos, userSession);

                    var stesting = ConnectyCubeExtension.ToQueryString(userSession);
                    Console.WriteLine(stesting);

                    return stesting;
                }
        */
        public StringBuilder SignParams(SortedDictionary<string, string> sessionPairs)
        {
            StringBuilder signature = new StringBuilder();

         /*   foreach(KeyValuePair<string, string> kvp in sessionPairs)
            {
                Console.WriteLine($"Key : {kvp.Key}");
                Console.WriteLine($"Value: {kvp.Value}");
            }*/

            signature.Append($"application_id={sessionPairs["application_id"]}&");
            signature.Append($"auth_key={sessionPairs["auth_key"]}&");
            signature.Append($"nonce={sessionPairs["nonce"]}&");
            signature.Append($"timestamp={sessionPairs["timestamp"]}");

            if(sessionPairs.ContainsKey("login"))
            {
                signature.Append($"&user[login]={sessionPairs["login"]}&");
                signature.Append($"user[password]={sessionPairs["password"]}");
                /*Console.WriteLine(sessionPairs.ContainsKey("login"));*/
            }
            else if(sessionPairs.ContainsKey("email"))
            {
                signature.Append($"&user[email]={sessionPairs["email"]}&");
                signature.Append($"user[password]={sessionPairs["password"]}");
                /*Console.WriteLine(sessionPairs.ContainsKey("email"));*/
            }

            Console.WriteLine(signature);

            return signature;
        }
        public string GetUrl(string path)
        {
            return "string";
        }

        private string HmacSha1(string signature)
        {
            return "string";
        }

        private double RandomNonce()
        {
            long max = 9999999999;
            long min = 1000000000;

            var random = new Random();

            double num = Math.Floor(random.NextDouble() * (max - min) + min);
            /*Console.WriteLine(num);*/

            return num;
        }
     
        private long GetTimeStamp()
        {
            /*Console.WriteLine(DateTimeOffset.Now.ToUnixTimeSeconds());*/
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            return timestamp;
        }

        private string GetPropertyInfo(FieldInfo[] fieldInfos, Session userSession)
        {
           /* Array.Sort(propertyInfos);*/
            int upper = fieldInfos.GetUpperBound(0);
            int lower = fieldInfos.GetLowerBound(0);

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            //string for api call
            string parameterStrings = default;
            
          /*  foreach(var props in propertyInfos)
            {
                Console.WriteLine(props.PropertyType);
            }*/

            for (int i = 0; i < fieldInfos.Length; i++)
            {
                /*   if (fieldInfos[i].PropertyType == typeof(System.Object))
                   {
                       Console.WriteLine(fieldInfos[i].GetValue(userSession));
                   }
                   else
                   {
                       Console.WriteLine(fieldInfos[i]);
                   }*/

                Console.WriteLine(fieldInfos.Length);
            }

            return "true";
        }
    }

    public static class ConnectyCubeExtension
    {
        public static string ToQueryString(this Session userSession, string separator = ",")
        {
            var properties = userSession.GetType().GetProperties()
             .Where(x => x.CanRead)
             .Where(x => x.GetValue(userSession, null) != null)
             .ToDictionary(x => x.Name, x => x.GetValue(userSession, null));

            var propertyNames = properties
            .Where(x => !(x.Value is string) && x.Value is IEnumerable)
            .Select(x => x.Key)
            .ToList();

            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join("&", enumerable.Cast<object>());
                }
            }
            return string.Join("&", properties
           .Select(x => string.Concat(
               Uri.EscapeDataString(x.Key), "=",
               Uri.EscapeDataString(x.Value.ToString()))));
        }
    }
}
