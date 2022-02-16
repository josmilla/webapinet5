using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net5.Deployment.API.Infrastructure.Data.Entities
{
    public partial class Alumno
    {
        public Guid AlumnoId { get; set; }


        [Column(TypeName = "varchar(75)")]
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string Nombres { get; set; }

        [Column(TypeName = "varchar(75)")]
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string Apellidos { get; set; }

        public int Edad { get; set; }

        [Column(TypeName = "varchar(75)")]
        [Display(Name = "Nivel")]
        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string Nivel { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha de Registro")]
        [Required(ErrorMessage = "El campo fecha de ingreso es obligatorio")]
        public DateTime FechaRegistro { get; set; }
    }
}
