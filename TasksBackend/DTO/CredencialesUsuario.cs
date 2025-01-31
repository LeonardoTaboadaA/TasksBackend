using System.ComponentModel.DataAnnotations;

namespace TasksBackend.DTO
{
    public class CredencialesUsuario
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
