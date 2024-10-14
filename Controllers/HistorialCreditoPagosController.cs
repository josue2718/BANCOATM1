using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BANCOATM1.BD;
using BANCOATM1.BD.Models;
using BANCOATM1.Models;

namespace BANCOATM1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialCreditoPagosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialCreditoPagosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialCreditoPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialCreditoPagos>>> GetHistorialCreditoPagos()
        {
            return await _context.HistorialCreditoPagos.ToListAsync();
        }

        // GET: api/HistorialCreditoPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialCreditoPagos>> GetHistorialCreditoPagos(int id)
        {
            var historialCreditoPagos = await _context.HistorialCreditoPagos.FindAsync(id);

            if (historialCreditoPagos == null)
            {
                return NotFound();
            }

            return historialCreditoPagos;
        }
        [HttpGet("BuscarPorIDcliente/{ID}")]
        public async Task<ActionResult<IEnumerable<HistorialCreditoPagos>>> GetTransaccionesByClienteID(int ID)
        {
            var historialCreditoPagos = await _context.HistorialCreditoPagos
                .Where(c => c.ID_cliente == ID)
                .ToListAsync();

            if (historialCreditoPagos == null || !historialCreditoPagos.Any())
            {
                return NotFound();
            }

            return historialCreditoPagos;
        }

        // PUT: api/HistorialCreditoPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialCreditoPagos(int id, HistorialCreditoPagos historialCreditoPagos)
        {
            if (id != historialCreditoPagos.ID_PagosCredito)
            {
                return BadRequest();
            }

            _context.Entry(historialCreditoPagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialCreditoPagosExists(id))
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

        // POST: api/HistorialCreditoPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialCreditoPagos>> PostHistorialCreditoPagos(HistorialCreditoPagos historialCreditoPagos)
        {
            

            try
            {
                _context.HistorialCreditoPagos.Add(historialCreditoPagos);
            await _context.SaveChangesAsync();

                return CreatedAtAction("GetHistorialCreditoPagos", new { id = historialCreditoPagos.ID_PagosCredito }, historialCreditoPagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
            
        }

        // DELETE: api/HistorialCreditoPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialCreditoPagos(int id)
        {
            var historialCreditoPagos = await _context.HistorialCreditoPagos.FindAsync(id);
            if (historialCreditoPagos == null)
            {
                return NotFound();
            }

            _context.HistorialCreditoPagos.Remove(historialCreditoPagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialCreditoPagosExists(int id)
        {
            return _context.HistorialCreditoPagos.Any(e => e.ID_PagosCredito == id);
        }
    }
}