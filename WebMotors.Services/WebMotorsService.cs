using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain;

namespace WebMotors.Services
{
    public class WebMotorsService : IWebMotorsService
    {
        private readonly HttpClient _client;
        private JsonSerializerSettings settings => new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public WebMotorsService(HttpClient client, ConnectionConfig config)
        {
            client.BaseAddress = new Uri(config.Endpoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client = client;
        }

        public async Task<List<MakeDto>> GetMake()
        {
            List<MakeDto> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync("/Make"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<MakeDto>>(response, settings);
            }

            return resultado;
        }

        public async Task<List<ModelDto>> GetModel(int makeId)
        {
            List<ModelDto> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync($"/Model?MakeID={makeId}"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<ModelDto>>(response, settings);
            }

            return resultado;
        }

        public async Task<List<VehiclesDto>> GetVehicles(int page)
        {
            List<VehiclesDto> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync($"/Vehicles?Page={page}"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<VehiclesDto>>(response, settings);
            }

            return resultado;
        }

        public async Task<List<VersionDto>> GetVersion(int modelId)
        {
            List<VersionDto> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync($"/Version?ModelID={modelId}"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<VersionDto>>(response, settings);
            }

            return resultado;
        }
    }
}
