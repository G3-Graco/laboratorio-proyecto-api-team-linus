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
    public class PrestamoController : ControllerBase
    {
        
       // Llama al método de servicio para realizar el inicio de sesión y obtener el token JWT.
        private readonly IPrestamosService _prestamoService;
        public PrestamoController(IPrestamosService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        

        /// <summary>
        /// Buscar todos los préstamos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamos>>> GetAll(){

            var prestamos = await _prestamoService.GetAll();

            return Ok(prestamos);
        }

        /// <summary>
        /// Buscar préstamo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamos>> GetById(int id){
            var prestamos = await _prestamoService.GetPrestamoById(id);
            return Ok(prestamos);
        }

       /// <summary>
       /// Crear préstamos
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Prestamos>> Post([FromBody] Prestamos Objeto)
        {
            try
            {
                var createdObjeto =
                    await _prestamoService.CreatePrestamo(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
       
        
      
    }
}