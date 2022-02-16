using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Infrastructure.Data.Repositories
{
    public interface IAlumnoRepository
    {
        Task<Alumno> DeleteAsync(Guid alumnoId);
        Task<Alumno> GetAlumnoByIdAsync(Guid alumnoId);
        Task<List<Alumno>> GetAlumnoAsync();
        Task<Alumno> InsertAsync(Alumno alumno);
        Task<Alumno> UpdateAsync(Guid alumnoId, Alumno alumno);
    }
}