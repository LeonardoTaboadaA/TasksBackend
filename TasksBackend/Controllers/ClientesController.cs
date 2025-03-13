using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using TasksBackend.DTO;
using TasksBackend.Entidades;
using AutoMapper;

namespace TasksBackend.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] ClienteRequest clienteRequest)
        {
            // Validar el modelo recibido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna errores de validación
            }

            // Verificar si ya existe un cliente con el mismo RUC
            var clienteExistente = await context.Clientes
                .FirstOrDefaultAsync(c => c.Ruc == clienteRequest.Ruc);

            if (clienteExistente != null)
            {
                return Conflict("Ya existe un cliente con el mismo RUC."); // Retorna conflicto si el RUC ya existe
            }

            // Mapear ClienteRequest a Cliente
            var cliente = mapper.Map<Cliente>(clienteRequest);

            // Guardar el cliente en la base de datos
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            // Retornar una respuesta exitosa
            return Ok(new { Message = "Cliente guardado exitosamente", ClienteId = cliente.Id });
        }

    }
}
