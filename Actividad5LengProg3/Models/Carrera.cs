using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad5LengProg3.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int CantidadCreditos { get; set; }

        [Required]
        public int CantidadMaterias { get; set; }

        // Relación 1 a muchos con Estudiante
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
