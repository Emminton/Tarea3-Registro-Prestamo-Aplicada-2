using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Registro_Prestamos.BLL;
using Registro_Prestamos.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        // GET: api/<PrestamosController>
        [HttpGet]
        public ActionResult<IEnumerable<Prestamo>> Get()
        {
            return PrestamosBLL.Getprestamos();
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            return PrestamosBLL.Buscar(id);
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public void Post([FromBody] Prestamo prestamos)
        {
            PrestamosBLL.Guardar(prestamos);
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return PrestamosBLL.Eliminar(id);
        }
    }
}
