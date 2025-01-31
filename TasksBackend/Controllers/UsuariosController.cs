using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TasksBackend.DTO;
using TasksBackend.Entidades;

namespace TasksBackend.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public UsuariosController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UsuarioDTO>>> ListadoUsuarios()
        {
            var usuarios = await context.Users.ToListAsync();
            return Ok(usuarios);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Crear([FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = new ApplicationUser
            {
                UserName = usuarioRequest.UserName,
                Email = usuarioRequest.Email,
                Dni = usuarioRequest.Dni,
                ApellidoPaterno = usuarioRequest.ApellidoPaterno,
                ApellidoMaterno = usuarioRequest.ApellidoMaterno,
                Nombre = usuarioRequest.Nombre,
                Direccion = usuarioRequest.Direccion,
                PhoneNumber = usuarioRequest.NumeroCelular,
                Cargo = usuarioRequest.Cargo,
                
            };
            var resultado = await userManager.CreateAsync(usuario, usuarioRequest.Password);

            if (resultado.Succeeded)
            {
                await userManager.AddClaimAsync(usuario, new Claim("role", usuarioRequest.Rol));
                return Ok("Usuario creado exitosamente");
            }

            else
            {
                return BadRequest(resultado.Errors);
            }

        }

    }
}
