using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebCliente.Models;

namespace WebCliente.Infrastructure.Agents
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


        public async Task<Alumno> GetAlumnoid(Guid alumnoid)
        {
            return await _client.GetAlumnoByIdAsync(alumnoid);
        }

        public async Task<HttpResponseMessage> Delete(Guid alumnoId)
        {
            return await _client.DeleteAsync(alumnoId);

        }


        //public async Task<HttpResponseMessage> Actualizar (Guid alumnoId, [FromBody] Alumno alumno)
        public async Task<Alumno> Update(Guid alumnoId, Alumno alumno)
        {
            return await _client.Update(alumnoId, alumno);

        }

        public async Task<Alumno> Crear(Guid alumnoId)
        {
            return await _client.Crear(alumnoId);

        }

        public async Task<HttpResponseMessage> CrearAlumno([FromBody] Alumno alumno)
        {
            return await _client.CrearAlumno(alumno);

        }

        public async Task<HttpResponseMessage> ActualizarAlumno(Guid alumnoId, Alumno alumno)
        {
            return await _client.ActualizarAlumno(alumnoId, alumno);

        }

        public async Task<List<Alumno>> ActualizarAsync(Guid alumnoId)
        {
            return await _client.Actualizar(alumnoId);
        }

        //internal Task<IDisposable> ActualizarAlumno(Guid alumnoId, AlumnosHttpClient content)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<HttpResponseMessage> PutAsync(Guid alumnoId, [FromBody] Alumno alumno)
        //{
        //    return await _client.PutAsync(alumnoId, alumno);
        //}
    }
}
