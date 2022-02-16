using Microsoft.Extensions.Configuration;
using Net5.Deployment.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Infrastructure.Agents
{
    public class AlumnosHttpClient
    {
        private HttpClient _httpClient;
        private string alumnosApiUrl = "";
         
        public AlumnosHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            alumnosApiUrl = configuration.GetSection("ProductUrl").Value;
            InitializeClient(httpClient);
        }

        public async Task<List<Alumno>> GetAlumnoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Alumno>>("");
        }

        //public async Task<List<Alumno>> DeleteAsync(Guid alumnoId)
        //{

        //    return await _httpClient.GetFromJsonAsync<List<Alumno>>($"/api/Alumno/{alumnoId}");



        //}

        private void InitializeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(alumnosApiUrl);
            _httpClient = httpClient;
        }
    }
}
