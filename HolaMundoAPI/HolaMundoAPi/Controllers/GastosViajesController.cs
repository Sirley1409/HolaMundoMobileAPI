using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPi.Data;
using HolaMundoAPi.Data.Models;
using HolaMundoAPi.Data.Dto;

namespace HolaMundoAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosViajesController : ControllerBase
    {
        private readonly HolaMundoDbContext _context;

        public GastosViajesController(HolaMundoDbContext context)
        {
            _context = context;
        }

        // GET: api/GastosViajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosViaje>>> GetGastosViaje()
        {
          if (_context.GastosViaje == null)
          {
              return NotFound();
          }
            return await _context.GastosViaje.Include(x=> x.ClasificacionGastos).Include(x=> x.User).ToListAsync();
        }

        // GET: api/GastosViajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GastosViaje>> GetGastosViaje(long id)
        {
          if (_context.GastosViaje == null)
          {
              return NotFound();
          }
            var gastosViaje = await _context.GastosViaje.FindAsync(id);

            if (gastosViaje == null)
            {
                return NotFound();
            }

            return gastosViaje;
        }

        // PUT: api/GastosViajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastosViaje(long id, GastosViaje gastosViaje)
        {
            if (id != gastosViaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(gastosViaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastosViajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GastosViajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GastosViaje>> PostGastosViaje(GastosViajeDto gastosViaje)
        {
          if (_context.GastosViaje == null)
          {
              return Problem("Entity set 'HolaMundoDbContext.GastosViaje'  is null.");
          }
            
            GastosViaje Resultado = new GastosViaje() 
            {
                UserId = gastosViaje.UserId,
                ClasificacionGastosId = gastosViaje.ClasificacionGastosId,
                Fecha = gastosViaje.Fecha,
                Valor = gastosViaje.Valor,
                DetalleGasto = gastosViaje.DetalleGasto,
                ClasificacionGastos = this._context.ClasificacionGastos.Where(x=> x.GastosId==gastosViaje.ClasificacionGastosId).FirstOrDefault(),
                User = this._context.Users.Where(x=> x.Id==gastosViaje.UserId).FirstOrDefault()
            };
            _context.GastosViaje.Add(Resultado);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGastosViaje", new { id = Resultado.Id }, Resultado);

        }

        // DELETE: api/GastosViajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGastosViaje(long id)
        {
            if (_context.GastosViaje == null)
            {
                return NotFound();
            }
            var gastosViaje = await _context.GastosViaje.FindAsync(id);
            if (gastosViaje == null)
            {
                return NotFound();
            }

            _context.GastosViaje.Remove(gastosViaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GastosViajeExists(long id)
        {
            return (_context.GastosViaje?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
