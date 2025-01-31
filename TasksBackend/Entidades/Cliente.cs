using System.ComponentModel.DataAnnotations;
using System;

namespace TasksBackend.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; } 

        [Required(ErrorMessage = "El RUC es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El RUC debe tener 11 dígitos.")]
        public string Ruc { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        [StringLength(255, ErrorMessage = "La razón social no debe superar los 255 caracteres.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no debe superar los 20 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string Correo { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no debe superar los 500 caracteres.")]
        public string Direccion { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
