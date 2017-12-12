using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueJsCrudWithTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace VueJsCrudWithTemplate.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehiculos")]
    public class VehiculosController : Controller
    {
        private readonly DataModel _context;

        public VehiculosController(DataModel context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public IEnumerable<Vehiculo> Get()
        {
            var vehiculos = _context.Vehiculos.ToList();

            return vehiculos;


        }

   

        // POST: api/Vehiculos
        [HttpPost]
        public IActionResult Post([FromBody]Vehiculo Entity)
        {
            if (Entity == null)
                return BadRequest();

            Entity.MarcaNombre = _context.Marcas.Where(x => x.Id == Entity.MarcaId).FirstOrDefault().Nombre;
            Entity.ModeloNombre = _context.Modelos.Where(x => x.Id == Entity.ModeloId).FirstOrDefault().Nombre;

            if (!ModelState.IsValid)
                return BadRequest();

          
                _context.Vehiculos.Add(Entity);
                _context.SaveChanges();
            

            return Ok(Entity);
        }

        public class PostModel
        {
            public Vehiculo Entity { get; set; }
        }

        // POST: api/Vehiculos
        [HttpPut("{id}")]
        public IActionResult Put( int id, [FromBody]Vehiculo entity)
        {

            if (entity == null || entity.Id != id)
            {
                return BadRequest();
            }

            var vehiculo = _context.Vehiculos.AsNoTracking().FirstOrDefault(x=>x.Id==id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            vehiculo = entity;
            vehiculo.MarcaNombre = _context.Marcas.Where(x => x.Id == vehiculo.MarcaId).FirstOrDefault().Nombre;
            vehiculo.ModeloNombre = _context.Modelos.Where(x => x.Id == vehiculo.ModeloId).FirstOrDefault().Nombre;



            _context.Vehiculos.Update(vehiculo);
            _context.SaveChanges();

            return Ok(vehiculo);

        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<Modelo> Modelos([FromRoute] int id) {

            var modelos = _context.Modelos.Where(x => x.MarcaId == id).ToList();
            
            return modelos;

        }

        [HttpGet("[action]")]
        public IEnumerable<Marca> Marcas()
        {

            var marcas = _context.Marcas.ToList();

            return marcas;

        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (id == 0)
                return BadRequest();

            var vehiculo = _context.Vehiculos.Find(id);

            if (vehiculo == null)
                return BadRequest();

            _context.Vehiculos.Remove(vehiculo);
            _context.SaveChanges();


            return Ok();

        }
    }
}
