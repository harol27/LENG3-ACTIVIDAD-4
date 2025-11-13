using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad5LengProg3.Models
{
    public class Estudiante
    {
        [Key]
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public int RecintoId { get; set; }
        public Recinto Recinto { get; set; }


        [Required]
        [EmailAddress]
        public string CorreoInstitucional { get; set; }

        [Phone]
        [MinLength(10)]
        public string Celular { get; set; }

        [Phone]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Turno { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100)]
        public int? PorcentajeBeca { get; set; }
    }
}
