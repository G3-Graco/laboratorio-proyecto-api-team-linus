using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Services.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Core.Servicios;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        
       // Llama al método de servicio para realizar el inicio de sesión y obtener el token JWT.
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }

        

        /// <summary>
        /// Buscar todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll(){

            var Usuario = await _userService.GetAll();

            return Ok(Usuario);
        }

        /// <summary>
        /// Buscar usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id){
            // Llama al método de servicio para obtener un usuario por su ID.
            var Usuario = await _userService.GetUsuarioById(id);
            // Devuelver con el usuario encontrado.
            return Ok(Usuario);
        }
        

       /// <summary>
       /// Crear usuario
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario Objeto)
        {
            try
            {
                var createdObjeto =
                    await _userService.CreateUsuario(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Objeto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario Objeto){
            try{
                Usuario updatedObjeto =
                    await _userService.UpdateUsuario(id, Objeto);
                
                return updatedObjeto;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }
        
      
    }
}


/* using Core.Entidades;
using Core.Interfaces.Servicios;
using Core.Respuestas;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controladores
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuarioController : ControllerBase
	{
		private IUsuarioServicio _servicio;
		public UsuarioController(IUsuarioServicio servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		/// Método para obtener lista de usuarios
		/// </summary>
		/// <returns>Respuesta con objeto IEnumerable de usuarios</returns>
		[HttpGet]
		public async Task<ActionResult<Respuesta<IEnumerable<Usuario>>>> Get()
		{
			try
			{
				var Respuesta = await _servicio.ObternerTodosAsincrono();

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		/// <summary>
		/// Método para obtener un usuario
		/// </summary>
		/// <returns>Respuesta con objeto usuario</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Respuesta<Usuario>>> Get(int id)
		{
			try
			{
				var Respuesta = await _servicio.ObternerPorIdAsincrono(id);

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		/// <summary>
		/// Método para crear un usuario
		/// </summary>
		/// <returns>Respuesta con objeto usuario</returns>
		[HttpPost]
		public async Task<ActionResult<Respuesta<Usuario>>> Post([FromBody] Usuario usuario)
		{
			try
			{
				var Respuesta = await _servicio.Agregar(usuario);

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		/// <summary>
		/// Método para actualizar datos de un usuario
		/// </summary>
		/// <returns>Respuesta con objeto usuario</returns>
		[HttpPut("{id}")]
		public async Task<ActionResult<Respuesta<Usuario>>> Put(int id, [FromBody] Usuario usuario)
		{
			try
			{
				var Respuesta = await _servicio.Actualizar(id, usuario);

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		/// <summary>
		/// Método para eliminar a un usuario
		/// </summary>
		/// <returns>Respuesta con mensaje de éxito de eliminado y datos null</returns>
		[HttpDelete]
		public async Task<ActionResult<Respuesta<Usuario>>> Delete(int id)
		{
			try
			{
				var Respuesta = await _servicio.Remover(id);

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}



		[HttpPost("iniciosesion")]
		public async Task<IActionResult> Login([FromBody] Usuario usuario)
		{
			try
			{
				var Respuesta = await _servicio.IniciarSesion(usuario.NombreUsuario, usuario.Contrasena);

				return Ok(Respuesta);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}			
		}

		[HttpPost("registrarse")]
		public async Task<IActionResult> Registrarse([FromBody] ModeloRegistrarse modeloRegistrarse)
		{
			try
			{
				var Respuesta = await _servicio.Registrarse(modeloRegistrarse);

				return Ok(Respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

	}
}
*/