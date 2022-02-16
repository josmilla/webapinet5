using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;

namespace Net5.Deployment.API.Infrastructure.Data.Contexts
{
    public static class AlumnoContextExtensions
    {
        public static void EnsureSeeDataForContext(this AlumnoContext context)
        {
            context.Alumno.RemoveRange(context.Alumno);
            context.SaveChanges();

            List<Alumno> alumnos = new List<Alumno>();

            alumnos.Add(new Alumno
            {
                AlumnoId = new Guid("FE243451-E3F4-42FA-93BB-B4DC8C6144A4"),
                Nombres = "Juan P",
                Apellidos = "Xbox Rojas",
                Edad = 10,
                Nivel = "Primaria",
                FechaRegistro = DateTime.Now
            });
            alumnos.Add(new Alumno
            {
                AlumnoId = new Guid("49BC36D4-37F0-4CAD-83BF-1026A04DF1D0"),
                Nombres = "Maria Saly",
                Apellidos = "Castil Rers",
                Edad = 5,
                Nivel = "Inicial",
                FechaRegistro = DateTime.Now
            });
            alumnos.Add(new Alumno
            {
                AlumnoId = new Guid("0F7C3D83-15CD-4F32-9EF2-9FE3270BE286"),
                Nombres = "Pedro Hiew",
                Apellidos = "Torres Y",
                Edad = 10,
                Nivel = "Primaria",
                FechaRegistro = DateTime.Now
            });
            alumnos.Add(new Alumno
            {
                AlumnoId = new Guid("FB678BD3-D178-4ED0-87E2-2A3BC81CB32D"),
                Nombres = "Luis Mari",
                Apellidos = "Loerw Junae",
                Edad = 14,
                Nivel = "Secundaria",
                FechaRegistro = DateTime.Now
            });
            alumnos.Add(new Alumno
            {
                AlumnoId = new Guid("AD48BA04-D528-43C4-855D-B2F2B7D8215F"),
                Nombres = "Mazil Pro",
                Apellidos = "Chai Po",
                Edad = 15,
                Nivel = "Secundaria",
                FechaRegistro = DateTime.Now
            });

            context.Alumno.AddRange(alumnos);
            context.SaveChanges();
        }
    }
}
