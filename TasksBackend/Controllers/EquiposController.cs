using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksBackend.DTO;
using TasksBackend.Entidades;

namespace TasksBackend.Controllers
{
    [Route("api/equipos")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EquiposController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<EquipoDTO>>> Get() 
        {
            var equipos = await context.Equipos.ToListAsync();
            return mapper.Map<List<EquipoDTO>>(equipos);
        }

        [HttpGet("opciones")]
        public async Task<IActionResult> ObtenerOpcionesEquipos()
        {
            var equipos = await context.Equipos
                .Select(p => new EquipoOpcionesDTO
                {
                    Id = p.Id,
                    Marca = p.Marca,
                    Nombre = p.Nombre,
                })
                .ToListAsync();

            return Ok(equipos);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] EquipoRequest equipoRequest)
        {
            // Validar el modelo recibido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna errores de validación
            }

            // Verificar si ya existe un equipo con los mismos datos clave
            var equipoExistente = await context.Equipos
                .FirstOrDefaultAsync(e =>
                    e.Marca == equipoRequest.Marca &&
                    e.Modelo == equipoRequest.Modelo &&
                    e.AnioFabricacion == equipoRequest.AnioFabricacion
                );

            if (equipoExistente != null)
            {
                return Conflict("Ya existe un equipo con la misma Marca, Modelo y Año de Fabricación.");
            }

            // Mapear EquipoRequest a Equipo
            var equipo = mapper.Map<Equipo>(equipoRequest);

            // Guardar el equipo en la base de datos
            context.Equipos.Add(equipo);
            await context.SaveChangesAsync();

            var equipoDTO = mapper.Map<EquipoOpcionesDTO>(equipo);

            // Retornar una respuesta exitosa
            return Ok(equipoDTO);
        }

    }
}
