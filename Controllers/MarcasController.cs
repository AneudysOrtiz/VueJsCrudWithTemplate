using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueJsCrudWithTemplate.Models;

namespace VueJsCrudWithTemplate.Controllers
{
    [Produces("application/json")]
    [Route("api/Marcas")]
    public class MarcasController : Controller
    {
        private readonly DataModel _context;

        public MarcasController(DataModel context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet(Name = "GetMarcas")]
        public IEnumerable<Marca> Get()
        {
            var vehiculos = _context.Marcas.ToList();

            return vehiculos;


        }

     
        
        // POST: api/Marcas
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Marcas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
