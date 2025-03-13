using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TasksBackend.DTO;
using TasksBackend.Entidades;
using TasksBackend.Utilidades;

namespace TasksBackend.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UsuarioDTO>>> ListadoUsuarios([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Users.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var usuarios = await queryable.OrderByDescending(x => x.FechaCreacion).Paginar(paginacionDTO).ToListAsync();
            return Ok(mapper.Map<List<UsuarioDTO>>(usuarios));
        }

        [HttpGet("opciones")]
        public async Task<IActionResult> ObtenerOpcionesResponsables()
        {
            var usuarios = await context.Users
                .Where(p => p.Enabled)
                .Select(p => new UsuarioOpcionesDTO
                {
                    Id = p.Id,
                    Dni = p.Dni,
                    Nombre = p.Nombre,
                    Apellido = p.ApellidoPaterno + " " + p.ApellidoMaterno
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Crear([FromBody] UsuarioRequest usuarioRequest)
        {
            /*var usuario = new ApplicationUser
            {
                UserName = usuarioRequest.UserName,
                Email = usuarioRequest.Email,
                Dni = usuarioRequest.Dni,
                ApellidoPaterno = usuarioRequest.ApellidoPaterno,
                ApellidoMaterno = usuarioRequest.ApellidoMaterno,
                Nombre = usuarioRequest.Nombre,
                Direccion = usuarioRequest.Direccion,
                PhoneNumber = usuarioRequest.PhoneNumber,
                Cargo = usuarioRequest.Cargo,
                
            };*/
            var usuario = mapper.Map<ApplicationUser>(usuarioRequest);

            var resultado = await userManager.CreateAsync(usuario, usuarioRequest.Password);

            if (resultado.Succeeded)
            {
                await userManager.AddClaimAsync(usuario, new Claim("role", usuarioRequest.Rol));
                return NoContent();
            }

            else
            {
                return BadRequest(resultado.Errors);
            }

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioResponse>> Get(string Id)
        {
            var usuario = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (usuario == null)
            {
                return NotFound();
            }

            // Obtener los claims del usuario
            var claims = await userManager.GetClaimsAsync(usuario);

            // Buscar el claim del rol
            var roleClaim = claims.FirstOrDefault(c => c.Type == "role");

            // Mapear a UsuarioResponse
            var usuarioResponse = mapper.Map<UsuarioResponse>(usuario);
            usuarioResponse.Rol = roleClaim?.Value;

            return usuarioResponse;
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UsuarioRequestEditar usuarioRequestEditar)
        {
            var usuario = await userManager.FindByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            // 🔹 1. ACTUALIZAR CONTRASEÑA (si se envió una nueva)
            if (!string.IsNullOrWhiteSpace(usuarioRequestEditar.Password))
            {
                var resetToken = await userManager.GeneratePasswordResetTokenAsync(usuario);
                var passwordResult = await userManager.ResetPasswordAsync(usuario, resetToken, usuarioRequestEditar.Password);

                if (!passwordResult.Succeeded)
                {
                    return BadRequest(passwordResult.Errors);
                }
            }

            // 🔹 2. ACTUALIZAR ROLES (Claims)
            var claims = await userManager.GetClaimsAsync(usuario);
            var roleClaim = claims.FirstOrDefault(c => c.Type == "role");

            if (roleClaim != null)
            {
                await userManager.RemoveClaimAsync(usuario, roleClaim);
            }

            await userManager.AddClaimAsync(usuario, new Claim("role", usuarioRequestEditar.Rol));

            // 🔹 3. ACTUALIZAR DEMÁS DATOS
            usuario = mapper.Map(usuarioRequestEditar, usuario);

            var updateResult = await userManager.UpdateAsync(usuario);
            if (!updateResult.Succeeded)
            {
                return BadRequest(updateResult.Errors);
            }

            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            if (!usuario.Enabled)
            {
                return BadRequest(new { mensaje = "El usuario ya está deshabilitado." });
            }

            usuario.Enabled = false;
            var resultado = await userManager.UpdateAsync(usuario);

            if (!resultado.Succeeded)
            {
                return BadRequest(resultado.Errors);
            }

            return NoContent();
        }

    }
}
