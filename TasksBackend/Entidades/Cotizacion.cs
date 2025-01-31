using System.ComponentModel.DataAnnotations;
using System;

namespace TasksBackend.Entidades
{
    public class Cotizacion
    {
        [Key]
        public int IdCotizacion { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "La fecha de visita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        [Required(ErrorMessage = "La fecha de cotización es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCotizado { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaAprobado { get; set; }
    }
}
