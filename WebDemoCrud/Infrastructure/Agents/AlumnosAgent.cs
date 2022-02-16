using WebDemoCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace WebDemoCrud.Infrastructure.Agents
{
    public class AlumnosAgent
    {
        private AlumnosHttpClient _client;
        public AlumnosAgent(AlumnosHttpClient client)
        {
            _client = client;
        }

        public async Task<List<Alumno>> GetAlumnoAsync()
        {
            return await _client.GetAlumnoAsync();
        }

     }
}
