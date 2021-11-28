using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebMotors.UI.Models;

namespace WebMotors.UI.Service.Base
{
    public class BaseClient
    {
        protected readonly HttpClient _client;
        protected JsonSerializerSettings settings => new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public BaseClient(HttpClient client, EndpointConfig config)
        {
            client.BaseAddress = new Uri(config.Endpoint);
            _client = client;
        }


        public ByteArrayContent SerializeObject(object data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
