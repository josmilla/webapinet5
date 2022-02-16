using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebCliente.Infrastructure.Agents;
using WebCliente.Models;

namespace WebCliente.Controllers
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


        public async Task<ActionResult> Delete(Guid Alumnoid)
        {
              await _alumnosAgent.Delete(Alumnoid);
            return RedirectToAction("Index");
             
        }

        //public async Task<ActionResult> Actualizar (Guid Alumnoid, [FromBody] Alumno alumno)
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

        public IActionResult Detalle()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> AddEdit(Guid Alumnoid)
        {
            // return View();
           //  Alumnoid = Guid.Empty;
             var alumnos = await _alumnosAgent.GetAlumnoid(Alumnoid);
            return View(alumnos);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit([FromBody] Alumno alumno, AlumnosHttpClient content)
        {
            //_SAlumno = new Alumno();
            //using (var response = await _alumnosAgent.ActualizarAlumno(alumno.AlumnoId, content))
            //{
            //    // return response.Dispose();

            //    return response.ToString();
            //}

            if (ModelState.IsValid)

            {
                if (alumno.AlumnoId == Guid.Empty)
                {
                    var alumnos = await _alumnosAgent.ActualizarAlumno(alumno.AlumnoId, content);
                    //alumnos.EnsureSuccessStatusCode();
                    //Console.WriteLine("registration status: {0}", alumnos.StatusCode);
                    //return RedirectToAction("Index");
                    return View(alumnos);
                    //await _alumnosAgent.CrearAlumno(alumno);
                    // return RedirectToAction("AddEdit");
                }

                else
                {

                    var alumnos = await _alumnosAgent.ActualizarAlumno(alumno.AlumnoId, alumno);
                    alumnos.EnsureSuccessStatusCode();
                    //Console.WriteLine("registration status: {0}", alumnos.StatusCode);
                    return RedirectToAction("Index");
                    //return View(alumnos);
                    //await _alumnosAgent.ActualizarAlumno(alumno.AlumnoId,alumno);

                    //return RedirectToAction("AddEdit");
                }
            }
            return RedirectToAction("Index");
        }



        //public async Task<IActionResult> AddEdit(Alumno alumno)
        //{
        //    //if (ModelState.IsValid)
        //{


        // if (alumno.AlumnoId == Guid.Empty)
        // return View(alumno);

        // return (IActionResult)await _alumnosAgent.Update(Alumnoid, alumno);

        // return View(alumnos);
        // context.Add(client);
        // else
        //return (IActionResult)await _alumnosAgent.Update(Alumnoid, alumno);
        //return (IActionResult) await _alumnosAgent.Crear(Alumno);
        //   context.Update(client);
        // await context.SaveChangesAsync();
        // return RedirectToAction(nameof(Index));
        ////}
        //return View(alumno);
        // return RedirectToAction(nameof(Index));
        //}


        //public async Task<IActionResult> Actualizar (Guid Alumnoid)
        //{
        //    // return View();
        //    var alumnos = await _alumnosAgent.GetAlumnoid(Alumnoid);
        //    return View(alumnos);
        //}

        //public IActionResult Alumno()
        //{
        //    return View();

        //}

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
