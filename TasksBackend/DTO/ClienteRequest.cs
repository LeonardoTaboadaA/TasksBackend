using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TasksBackend.Utilidades;

namespace TasksBackend.DTO
{
    public class ClienteRequest
    {

        [Required(ErrorMessage = "El RUC es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El RUC debe tener 11 dígitos")]
        public string Ruc { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        [StringLength(255, ErrorMessage = "La razón social no debe superar los 255 caracteres.")]
        [MinLength(3, ErrorMessage = "La razón social debe tener al menos 3 caracteres.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El número de celular es obligatorio.")]
        [RegularExpression(@"^9[0-9]{8}$", ErrorMessage = "El número de celular no es válido. Debe comenzar con 9 y tener 9 dígitos.")]
        public string NumeroCelular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no debe superar los 500 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El centro es obligatorio.")]
        [StringLength(255, ErrorMessage = "El centro no debe superar los 255 caracteres.")]
        public string Centro { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        [StringLength(255, ErrorMessage = "La ubicación no debe superar los 255 caracteres.")]
        public string Ubicacion { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> EquiposIds { get; set; }
    }
}
