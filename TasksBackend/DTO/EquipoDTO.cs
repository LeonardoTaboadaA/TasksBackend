using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TasksBackend.DTO
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Nombre { get; set; }
        public decimal Potencia { get; set; }
        public int Tension { get; set; }
        public decimal Amperaje { get; set; }
        public int AnioFabricacion { get; set; }
        public string Especialidad { get; set; }
    }
}
