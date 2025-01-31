using System.ComponentModel.DataAnnotations;

namespace TasksBackend.DTO
{
    public class UsuarioRequest
    {
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NumeroCelular { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}
