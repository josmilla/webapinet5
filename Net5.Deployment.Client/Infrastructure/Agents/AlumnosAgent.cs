using Net5.Deployment.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Infrastructure.Agents
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

        //public async Task<List<Alumno>> DeleteAsync(Guid alumnoId)
        //{
        //    return await _client.DeleteAsync(alumnoId);
        //}
    }
}
