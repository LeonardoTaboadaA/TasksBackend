namespace TasksBackend.DTO
{
    public class UsuarioResponse
    {
        public string Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public string UserName { get; set; }
        public string Rol { get; set; }
    }
}
