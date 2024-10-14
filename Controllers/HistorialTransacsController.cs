using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BANCOATM1.BD;
using BANCOATM1.Models;

namespace BANCOATM1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialTransacsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialTransacsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialTransac>>> GetTransacs()
        {
            return await _context.Transacs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialTransac>> GetHistorialTransac(int id)
        {
            var historialTransac = await _context.Transacs.FindAsync(id);

            if (historialTransac == null)
            {
                return NotFound();
            }

            return historialTransac;
        }

        [HttpGet("BuscarPorIDcliente/{ID}")]
        public async Task<ActionResult<IEnumerable<HistorialTransac>>> GetTransaccionesByClienteID(int ID)
        {
            var historialTransac = await _context.Transacs
                .Where(c => c.ID_cliente == ID)
                .ToListAsync();

            if (historialTransac == null || !historialTransac.Any())
            {
                return NotFound();
            }

            return historialTransac;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialTransac(int id, HistorialTransac historialTransac)
        {
            if (id != historialTransac.ID_Historial)
            {
                return BadRequest();
            }

            _context.Entry(historialTransac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialTransacExists(id))
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

        [HttpPost]
        public async Task<ActionResult<HistorialTransac>> PostHistorialTransac(HistorialTransac historialTransac)
        {
            try
            {
                _context.Transacs.Add(historialTransac);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetHistorialTransac", new { id = historialTransac.ID_Historial }, historialTransac);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialTransac(int id)
        {
            var historialTransac = await _context.Transacs.FindAsync(id);
            if (historialTransac == null)
            {
                return NotFound();
            }

            _context.Transacs.Remove(historialTransac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialTransacExists(int id)
        {
            return _context.Transacs.Any(e => e.ID_Historial == id);
        }
    }
}
