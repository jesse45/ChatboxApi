using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatboxApi.Utilities
{
    public class Errorhandler
    {
        public static Dictionary<string, List<string>> ExtractErrorsFromApiCall(string body)
        {
            var response = new Dictionary<string, List<string>>();

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(body);
            var errorsJsonElement = jsonElement.GetProperty("errors");

            foreach(var fieldWithErrors in errorsJsonElement.EnumerateObject())
            {
                var field = fieldWithErrors.Name;
                var errors = new List<string>();
                foreach(var errorKind in fieldWithErrors.Value.EnumerateArray())
                {
                    var error = errorKind.GetString();
                    errors.Add(error);
                }
                response.Add(field, errors);
            }

            return response;
        }
    }
}
