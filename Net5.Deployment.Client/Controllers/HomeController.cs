using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net5.Deployment.Client.Infrastructure.Agents;
using Net5.Deployment.Client.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlumnosAgent _alumnosAgent;



        public HomeController(ILogger<HomeController> logger, AlumnosAgent alumnosAgent)
        {
            _logger = logger;
            _alumnosAgent = alumnosAgent;
            
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Alumno> alumnos = await _alumnosAgent.GetAlumnoAsync();
            return View(alumnos);
        }

        

        //public async Task<IActionResult> DeleteAsync(Guid alumnoId)
        //{

        //    List<Alumno> alumnos = await _alumnosAgent.DeleteAsync(alumnoId);
        //    return View(alumnos);

        //}

        //public async Task<IActionResult> Delete (Guid alumnoId)
        //{

        //    List<Alumno> alumnos = await _alumnosAgent.DeleteAsync(alumnoId);

        //    return View(alumnos);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Alumno()
        {
            return View();
        }

        public IActionResult UpdateAsync()
        {
            return View();
        }

         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
