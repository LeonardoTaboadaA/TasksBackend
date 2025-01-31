using Microsoft.AspNetCore.Identity;
using System;

namespace TasksBackend.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool Enabled { get; set; } = true;
    }
}
