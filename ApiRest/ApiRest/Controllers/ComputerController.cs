using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Servicio Api Rest Crud .net core 2.0
/// </summary>
namespace ApiRest.Controllers
{
    /// <summary>
    /// Rutas para la petición
    /// </summary>
    [Produces("application/json")]
    [Route("api/Computer")]
    public class ComputerController : Controller
    {
        /// <summary>
        /// Base de datos virtual
        /// </summary>
        private readonly ApplicationDbContex db;

        /// <summary>
        /// Inicialización de clase con la bd
        /// </summary>
        /// <param name="db"></param>
        public ComputerController(ApplicationDbContex db)
        {
            this.db = db;
        }

        /// <summary>
        /// Metodo Get para solicitud de computadores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Computer> GetComputer()
        {
            return db.Computers.ToList();
        }

        /// <summary>
        ///  Metodo Get para solicitud de computadores por medio de un parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "DbPost")]
        public IActionResult GetByComputer(int id)
        {
            var computer = db.Computers.FirstOrDefault(x => x.id == id);

            if (computer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(computer);
            }

        }

        /// <summary>
        /// Metodo Push para solicitud para agregar un nuevo registro
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostComputer([FromBody] Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computer);
                db.SaveChanges();
                return new CreatedAtRouteResult("DbPost", new { id = computer.id }, computer);

            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Metodo Put para modificar un registro por medio de un parametro
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutComputer([FromBody] Computer computer, int id)
        {
            if (computer.id != id)
            {
                return BadRequest();
            }
            db.Entry(computer).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();

        }

        /// <summary>
        /// Metodo delete para eliminar un registro 
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteComputer([FromBody] Computer computer, int id)
        {
            if (computer.id != id)
            {
                return BadRequest();
            }
            db.Computers.Remove(computer);
            db.SaveChanges();
            return Ok(computer);

        }


    }
}