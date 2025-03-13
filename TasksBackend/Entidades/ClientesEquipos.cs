namespace TasksBackend.Entidades
{
    public class ClientesEquipos
    {
        public int ClienteId { get; set; }
        public int EquipoId { get; set; }

        public Cliente Cliente { get; set; }
        public Equipo Equipo { get; set; }
    }
}
