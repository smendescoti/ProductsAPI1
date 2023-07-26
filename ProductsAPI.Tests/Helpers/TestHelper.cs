using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAPI.Tests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Método para criar um client http da api de produtos
        /// </summary>
        public static HttpClient CreateClient
        {
            get
            {
                var accessToken = @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoie1wiSWRcIjpcIjg1ODc5MjE4LWQ5N2YtNDgwYy04YzA4LTJjOTc2YzMyZDZmNlwiLFwiTmFtZVwiOlwiU2VyZ2lvIE1lbmRlc1wiLFwiRW1haWxcIjpcInNlcmdpby5jb3RpQHlhaG9vLmNvbVwiLFwiUm9sZVwiOlwiVVNFUl9ST0xFXCIsXCJTaWduZWRBdFwiOlwiMjAyMy0wNy0yNFQyMTo0NTozNC41MTEyMDI0LTAzOjAwXCJ9IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVVNFUl9ST0xFIiwiZXhwIjoxNjkwMjQ2ODM0LCJpc3MiOiJ1c2Vyc2FwcCIsImF1ZCI6IioifQ.aF7Niuycqh2W0T208kLSl5ktaQ7mZVIy6B2WljBfqrk";
                var auth = new AuthenticationHeaderValue("Bearer", accessToken);

                var client = new WebApplicationFactory<Program>().CreateClient();
                client.DefaultRequestHeaders.Authorization = auth;

                return client;
            }
        }

        /// <summary>
        /// Método para serializar o conteudo da requisição que será enviada para um serviço
        /// </summary>
        public static StringContent CreateContent<TRequest>(TRequest request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar o retorno obtido pela execução de um serviço
        /// </summary>
        public static TResponse ReadResponse<TResponse>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
    }
}
