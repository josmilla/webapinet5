using System;
 

namespace Net5.Deployment.Client.Models
{
    public class Alumno
    {



        public Guid AlumnoId { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public string Nivel { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string UpdateAsync { get; set; }

    }
}
