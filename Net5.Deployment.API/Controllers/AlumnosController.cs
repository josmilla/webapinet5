using Microsoft.AspNetCore.Mvc;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using Net5.Deployment.API.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepository;
        public AlumnosController(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        // GET: api/<AlumnosController>
        [HttpGet]
        public async Task<IEnumerable<Alumno>> GetAlumnoAsync()
        {
            return await _alumnoRepository.GetAlumnoAsync();
        }

        // GET api/<AlumnosController>/5
        [HttpGet("{id}", Name = "GetAlumno")]
        public async Task<Alumno> GetAsync(Guid id)
        {
            return await _alumnoRepository.GetAlumnoByIdAsync(id);
        }

        // POST api/<AlumnosController>
        [HttpPost]
        //[Route("api/Alumno/Create")]
        public async Task<IActionResult> PostAsync([FromBody] Alumno alumno)
        {
            var result = await _alumnoRepository.InsertAsync(alumno);
            return CreatedAtRoute("GetAlumno", new { id = result.AlumnoId }, result);            
        }

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Alumno alumno)
        {
            var result = await _alumnoRepository.UpdateAsync(id, alumno);
            //return Ok(result);
            return RedirectToAction(nameof(Index));
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        //[Route("api/Alumno/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _alumnoRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
           // return RedirectToAction(nameof(Index));
           return NoContent();
        }

        
    }
}
