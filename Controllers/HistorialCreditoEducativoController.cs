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
    public class HistorialCreditoEducativoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialCreditoEducativoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialCreditoEducativo>>> GetTransacs()
        {
            return await _context.HistorialCreditosEducativos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialCreditoEducativo>> GetHistorialCreditoEducativo(int id)
        {
            var historialServicio = await _context.HistorialCreditosEducativos.FindAsync(id);

            if (historialServicio == null)
            {
                return NotFound();
            }

            return historialServicio;
        }

        [HttpGet("BuscarPorIDcliente/{ID}")]
        public async Task<ActionResult<IEnumerable<HistorialCreditoEducativo>>> GetTransaccionesByClienteID(int ID)
        {
            var historialServicios = await _context.HistorialCreditosEducativos
                .Where(c => c.ID_cliente == ID)
                .ToListAsync();

            if (historialServicios == null || !historialServicios.Any())
            {
                return NotFound();
            }

            return historialServicios;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialTransac(int id, HistorialCreditoEducativo historialCreditoEducativo)
        {
            if (id != historialCreditoEducativo.ID_CreditoEducativo)
            {
                return BadRequest();
            }

            _context.Entry(historialCreditoEducativo).State = EntityState.Modified;

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
        public async Task<ActionResult<HistorialCreditoEducativo>> PostHistorialTransac(HistorialCreditoEducativo historialCreditoEducativo)
        {
            try
            {
                _context.HistorialCreditosEducativos.Add(historialCreditoEducativo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetHistorialCreditoEducativo", new { id = historialCreditoEducativo.ID_CreditoEducativo }, historialCreditoEducativo);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialTransac(int id)
        {
            var historialServicio = await _context.HistorialCreditosEducativos.FindAsync(id);
            if (historialServicio == null)
            {
                return NotFound();
            }

            _context.HistorialCreditosEducativos.Remove(historialServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialTransacExists(int id)
        {
            return _context.HistorialCreditosEducativos.Any(e => e.ID_CreditoEducativo == id);
        }
    }
}
