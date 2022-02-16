using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Infrastructure.Data.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private AlumnoContext _context;
        private DbSet<Alumno> _dbSet;
        public AlumnoRepository(AlumnoContext context)
        {
            _context = context;
            _dbSet = context.Set<Alumno>();
        }

        public async Task<List<Alumno>> GetAlumnoAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Alumno> GetAlumnoByIdAsync(Guid alumnoId)
        {
            return await _dbSet.Where(p => p.AlumnoId == alumnoId).FirstOrDefaultAsync();
        }
        public async Task<Alumno> InsertAsync(Alumno alumno)
        {
            _dbSet.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno;
        }
        public async Task<Alumno> UpdateAsync(Guid alumnoId, Alumno alumno)
        {
            Alumno alumnoToUpdate = await GetAlumnoByIdAsync(alumnoId);
            alumnoToUpdate.Nombres = alumno.Nombres;
            alumnoToUpdate.Apellidos = alumno.Apellidos;
            alumnoToUpdate.Edad = alumno.Edad;
            alumnoToUpdate.Nivel = alumno.Nivel;
            alumnoToUpdate.FechaRegistro = alumno.FechaRegistro;

            _dbSet.Update(alumnoToUpdate);
            await _context.SaveChangesAsync();

            return alumnoToUpdate;
        }

        public async Task<Alumno> DeleteAsync(Guid alumnoId)
        {
            Alumno alumnoToDelete = await GetAlumnoByIdAsync(alumnoId);

            _dbSet.Remove(alumnoToDelete);
            await _context.SaveChangesAsync();
            return alumnoToDelete;
        }
    }
}
