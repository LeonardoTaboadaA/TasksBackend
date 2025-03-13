using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TasksBackend.DTO
{
    public class EquipoRequest
    {
        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(100, ErrorMessage = "La marca no debe superar los 100 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El modelo no debe superar los 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La potencia es obligatoria.")]
        [Range(0.1, 1000, ErrorMessage = "La potencia debe estar entre 0.1 y 1000 HP.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Potencia { get; set; }

        [Required(ErrorMessage = "La tensión es obligatoria.")]
        [Range(1, 1000, ErrorMessage = "La tensión debe estar entre 1 y 1000 V.")]
        public int Tension { get; set; }

        [Required(ErrorMessage = "El amperaje es obligatorio.")]
        [Range(0.1, 500, ErrorMessage = "El amperaje debe estar entre 0.1 y 500 A.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amperaje { get; set; }

        [Required(ErrorMessage = "El año de fabricación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de fabricación debe estar entre 1900 y 2100.")]
        public int AnioFabricacion { get; set; }      

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La especialidad no debe superar los 100 caracteres.")]
        public string Especialidad { get; set; }
    }
}
