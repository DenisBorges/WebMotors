using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMotors.UI.Models;
using WebMotors.UI.Service.Base;


namespace WebMotors.UI.Service
{
    public class WebMotorsService : BaseClient, IWebMotorsService
    {

        public WebMotorsService(HttpClient client, EndpointConfig config) : base(client,config){}

        public async Task AtualizarAnuncio(AnuncioWebMotors register)
        {
            using (HttpResponseMessage resposta = await _client.PutAsync("AtualizarAnuncio", SerializeObject(register)))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();
            }

        }

        public async Task CriarAnuncio(AnuncioWebMotors register)
        {
            using (HttpResponseMessage resposta = await _client.PostAsync("CriarAnuncio", SerializeObject(register)))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();
            }
        }

        public async Task ExcluirAnuncio(int id)
        {
            using (HttpResponseMessage resposta = await _client.DeleteAsync($"ExcluirAnuncio?id={id}"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();
            }
        }

        public async Task<List<MakeDto>> GetMake()
        {
            List<MakeDto> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync("GetMake"))
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

            using (HttpResponseMessage resposta = await _client.GetAsync($"GetModel?makeId={makeId}"))
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

            using (HttpResponseMessage resposta = await _client.GetAsync("GetVehicles"))
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

            using (HttpResponseMessage resposta = await _client.GetAsync("GetVersion"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<VersionDto>>(response, settings);
            }

            return resultado;
        }

        public async Task<List<AnuncioWebMotors>> ListarTodos()
        {
            List<AnuncioWebMotors> resultado = null;

            using (HttpResponseMessage resposta = await _client.GetAsync("ListarTodos"))
            using (HttpContent conteudo = resposta.Content)
            {
                string response = await conteudo.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<AnuncioWebMotors>>(response, settings);
            }

            return resultado;
        }
    }
}
