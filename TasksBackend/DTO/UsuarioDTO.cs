using System;

namespace TasksBackend.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } 
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Enabled { get; set; }
    }

}
