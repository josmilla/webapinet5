using Microsoft.Extensions.Configuration;
using WebCliente.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebCliente.Infrastructure.Agents
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

        public async Task<Alumno> GetAlumnoByIdAsync(Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.GetFromJsonAsync<Alumno>(alumnosApiUrl);
            //return await _httpClient.SendAsync()
        }

        //public async Task<Alumno> UpdateAsync(Guid alumnoId, Alumno alumno)
        //{
        //    var alumnotoupdate = await GetAlumnoByIdAsync(alumnoId);
        //    alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
        //    return alumnotoupdate;
        //}



        public async Task<List<Alumno>> Actualizar (Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);


        }
        public async Task<List<Alumno>> Delete(Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);


        }

        //public async Task<List<Alumno>> AddEdit (Guid alumnoId, [FromBody] Alumno alumno)
        //{
        //    alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
        //    return await _httpClient.GetFromJsonAsync<List<Alumno>>(alumnosApiUrl);



        //}


        public async Task<HttpResponseMessage> DeleteAsync(Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.DeleteAsync(alumnosApiUrl);

        }
        public async Task<Alumno> Update (Guid alumnoId, Alumno alumno)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            HttpResponseMessage response = await _httpClient.PostAsync(alumnosApiUrl, new StringContent(alumno.ToString()));
            await HttpResponseValidator.ValidateStatusCode(response);
            return await response.Content.ReadFromJsonAsync<Alumno>();
        }



        public async Task<HttpResponseMessage> CrearAlumno([FromBody] Alumno alumno)
        {

            //alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            return await _httpClient.PostAsync(alumnosApiUrl, new StringContent(alumno.ToString()));
            
        }

        public async Task<HttpResponseMessage> ActualizarAlumno(Guid alumnoId, Alumno alumno)
        {
           
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            //var content = new StringContentWithoutCharset((alumno.ToString()), "application/json");
            //content = new StringContent(alumnosApiUrl, Encoding.UTF8, "application/json");
              var httpResponseMessage = await _httpClient.PutAsync(alumnosApiUrl, new StringContent(alumno.ToString()));
            if (httpResponseMessage == null)
            {
                throw new Exception("Put async error - Http response message is null.");
            }

            return httpResponseMessage;

            // return await _httpClient.PutAsync(alumnosApiUrl, content);
            // return (response);
            //return await response.Content.ReadAsStringAsync().Result;
            //return result;
        }
        public async Task<Alumno> Crear (Guid alumnoId)
        {
            alumnosApiUrl = alumnosApiUrl + "/" + alumnoId;
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(alumnosApiUrl, new StringContent(ToString()));
            await HttpResponseValidator.ValidateStatusCode(response);
            return await response.Content.ReadFromJsonAsync<Alumno>();
        }


        private void InitializeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(alumnosApiUrl);
            _httpClient = httpClient;
        }

        public static class HttpResponseValidator
        {
            public static async Task ValidateStatusCode(HttpResponseMessage response)
            {
                if ((int)response.StatusCode < 200 || (int)response.StatusCode > 299)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.Conflict)
                    {
                        DBConcurrencyException ex = new DBConcurrencyException(errorResponse);
                        throw ex;
                    }
                }
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
        public class StringContentWithoutCharset : StringContent
        {
            public StringContentWithoutCharset(string content) : base(content)
            {
            }

            public StringContentWithoutCharset(string content, Encoding encoding) : base(content, encoding)
            {
                Headers.ContentType.CharSet = "";
            }

            public StringContentWithoutCharset(string content, Encoding encoding, string mediaType) : base(content, encoding, mediaType)
            {
                Headers.ContentType.CharSet = "";
            }

            public StringContentWithoutCharset(string content, string mediaType) : base(content, Encoding.UTF8, mediaType)
            {
                Headers.ContentType.CharSet = "";
            }
        }


    }
}
