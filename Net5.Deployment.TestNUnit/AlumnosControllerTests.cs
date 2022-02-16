using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Controllers;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using Net5.Deployment.API.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.TestNUnit
{
    [TestFixture]
    public class AlumnosControllerTests
    {
        private DbContextOptions<AlumnoContext> _dbContextOptions = new DbContextOptionsBuilder<AlumnoContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .Options;

        private AlumnoRepository _alumnoRepository;
        private AlumnosController _controller;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();
            _alumnoRepository = new AlumnoRepository(new AlumnoContext(_dbContextOptions));
            _controller = new AlumnosController(_alumnoRepository);
        }

        [Test]
        public async Task GetAlumnoAsync()
        {
            var result = await _controller.GetAlumnoAsync();
            var alumnos = result.As<IEnumerable<Alumno>>();
            alumnos.Should().NotBeNullOrEmpty();
            alumnos.Count().Should().Be(5);
            //Assert.AreEqual(5, result.Count());
        }
        [Test]
        public async Task GetAsync()
        {
            var result = await _controller.GetAsync(new Guid("02540696-8994-42c7-b703-e630223883ab"));
            var alumno = result.As<Alumno>();
            alumno.Should().NotBeNull();
            alumno.Nombres.Should().Be("Pedro");
        }

        private void SeedDb()
        {
            using var context = new AlumnoContext(_dbContextOptions);

            List<Alumno> alumnos = new List<Alumno>
            {
                new Alumno{ AlumnoId = new Guid("35749678-0d54-44bc-83d5-274d57898f30"),Nombres="Jose",Apellidos="Ramos",Edad=5,Nivel="Inicial", FechaRegistro=DateTime.Now },
                new Alumno{ AlumnoId = new Guid("02540696-8994-42c7-b703-e630223883ab"),Nombres="Pedro",Apellidos="Heoap",Edad=10,Nivel="Primaria", FechaRegistro=DateTime.Now },
                new Alumno{ AlumnoId = new Guid("03404a76-0c4d-4eda-bb45-8df096cb976d"),Nombres="Maria",Apellidos="Neptuno",Edad=14,Nivel="Secundaria", FechaRegistro=DateTime.Now },
                new Alumno{ AlumnoId = new Guid("993feb68-3e87-4f9b-b45b-cbf13712de06"),Nombres="Luisa",Apellidos="Caere",Edad=12,Nivel="Secundaria", FechaRegistro=DateTime.Now },
                new Alumno{ AlumnoId = new Guid("947e2439-baef-4216-89d6-3f9f28d2a702"),Nombres="Camila",Apellidos="Prieto",Edad=7,Nivel="Inicial", FechaRegistro=DateTime.Now }
            };

            context.Alumno.AddRange(alumnos);
            context.SaveChanges();
        }
    }
}