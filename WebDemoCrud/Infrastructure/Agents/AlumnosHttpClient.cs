using Microsoft.Extensions.Configuration;
using WebDemoCrud.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDemoCrud.Infrastructure.Agents
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


         
        public async Task<List<Alumno>> Delete (Guid alumnoId)
        {
             alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
             return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);
         


        }

        public async Task<List<Alumno>> AddEdit (Guid alumnoId, [FromBody] Alumno alumno)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);
        


        }


        public async Task<HttpResponseMessage> DeleteAsync(Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.DeleteAsync(alumnosApiUrl);

        }


        public async Task<HttpResponseMessage> PutAsync(Guid alumnoId, [FromBody] Alumno alumno)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.PutAsJsonAsync(alumnosApiUrl, alumno);
           // return Ok(result);

        }

        //public async Task<List<Alumno>> Crear (Guid alumnoId)
        //{
        //    alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
        //    return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);
        

        //}

        //public async Task<HttpResponseMessage>  Crear (Guid alumnoId)
        //{
        //    alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
        //     await _httpClient.PostAsync(alumnosApiUrl);
        //    // return Ok(result);

        //}


        private void InitializeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(alumnosApiUrl);
            _httpClient = httpClient;
        }
    }
}
