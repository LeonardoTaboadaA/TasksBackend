using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksBackend.Entidades
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; } // ID autoincremental

        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(100, ErrorMessage = "La marca no debe superar los 100 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La tensión es obligatoria.")]
        [Range(1, 1000, ErrorMessage = "La tensión debe estar entre 1 y 1000 V.")]
        public int Tension { get; set; }

        [Required(ErrorMessage = "El año de fabricación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de fabricación debe estar entre 1900 y 2100.")]
        public int AnioFabricacion { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El modelo no debe superar los 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "La potencia es obligatoria.")]
        [Range(0.1, 1000, ErrorMessage = "La potencia debe estar entre 0.1 y 1000 HP.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Potencia { get; set; }

        [Required(ErrorMessage = "El amperaje es obligatorio.")]
        [Range(0.1, 500, ErrorMessage = "El amperaje debe estar entre 0.1 y 500 A.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amperaje { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La especialidad no debe superar los 100 caracteres.")]
        public string Especialidad { get; set; }

        [StringLength(50, ErrorMessage = "El estado no debe superar los 50 caracteres.")]
        public string Estado { get; set; } // Opcional: "Operativo", "En reparación"

        [StringLength(255, ErrorMessage = "La ubicación no debe superar los 255 caracteres.")]
        public string Ubicacion { get; set; } // Opcional: "Azotea", "Sala de máquinas"

        [StringLength(255, ErrorMessage = "La descripción no debe superar los 255 caracteres.")]
        public string Descripcion { get; set; } // Información adicional

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int? Cantidad { get; set; } // Opcional

        [Range(0.1, double.MaxValue, ErrorMessage = "La carga térmica debe ser mayor a 0.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? CargaTermica { get; set; } // Opcional

        [StringLength(50, ErrorMessage = "El tipo de gas no debe superar los 50 caracteres.")]
        public string TipoGasRefrigerante { get; set; } // Opcional

        [Range(0.1, double.MaxValue, ErrorMessage = "La capacidad de carga debe ser mayor a 0.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? CapacidadCarga { get; set; } // Opcional

        [Range(1900, 2100, ErrorMessage = "El año de instalación debe estar entre 1900 y 2100.")]
        public int? AnioInstalacion { get; set; } // Opcional

        public bool? ConexionMonitoreo { get; set; } // Opcional: Indica si tiene monitoreo
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public List<ClientesEquipos> ClienteEquipo { get; set; }
    }
}
