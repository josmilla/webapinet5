using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebDemoCrud.Models;
using WebDemoCrud.Infrastructure.Agents;


namespace WebDemoCrud.Controllers
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






        //public async Task<HttpResponseMessage> DeleteAsync(Guid AlumnoId)
        //{
        //     return await _alumnosAgent.Delete(AlumnoId);
        //   // return RedirectToAction(Index);
        //   // return RedirectToAction(nameof(Index));
        //}


        //public async Task<ActionResult> Delete(Guid Alumnoid)
        //{
        //    await _alumnosAgent.Delete(Alumnoid);
        //    return RedirectToAction("Index");

        //}

        //public async Task<ActionResult> Actualizar(Guid Alumnoid, [FromBody] Alumno alumno)
        //{
        //    await _alumnosAgent.Actualizar(Alumnoid, alumno);
        //    return RedirectToAction("Index");

        //}
        //The DELETE method

        //[HttpPost]
        //public async Task<IActionResult> AddEdit(Alumno alumno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (alumno.AlumnoId == "")
        //            await _alumnosAgent.
        //        context.Add(client);
        //        else
        //            context.Update(client);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(client);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddEdit()
        {
            return View();
        }

        public IActionResult Alumno()
        {
            return View();
        }

        //public IActionResult Update()
        //{
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
