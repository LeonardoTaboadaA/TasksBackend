using System.ComponentModel.DataAnnotations;

namespace TasksBackend.DTO
{
    public class UsuarioRequestEditar
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
        public string PhoneNumber { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}
