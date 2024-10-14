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
    public class HistorialServicioController : ControllerBase // Corregido el nombre de la clase controladora
    {
        private readonly AppDbContext _context;

        public HistorialServicioController(AppDbContext context) // Corregido el nombre del constructor
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialServicio>>> GetTransacs()
        {
            return await _context.Servicios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialServicio>> GetHistorialTransac(int id)
        {
            var historialServicio = await _context.Servicios.FindAsync(id);

            if (historialServicio == null)
            {
                return NotFound();
            }

            return historialServicio;
        }

        [HttpGet("BuscarPorIDcliente/{ID}")]
        public async Task<ActionResult<IEnumerable<HistorialServicio>>> GetTransaccionesByClienteID(int ID)
        {
            var historialServicios = await _context.Servicios
                .Where(c => c.ID_cliente == ID)
                .ToListAsync();

            if (historialServicios == null || !historialServicios.Any())
            {
                return NotFound();
            }

            return historialServicios;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialTransac(int id, HistorialServicio historialServicio)
        {
            if (id != historialServicio.ID_Servicio)
            {
                return BadRequest();
            }

            _context.Entry(historialServicio).State = EntityState.Modified;

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
        public async Task<ActionResult<HistorialServicio>> PostHistorialTransac(HistorialServicio historialServicio)
        {
            try
            {
                _context.Servicios.Add(historialServicio);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetHistorialTransac", new { id = historialServicio.ID_Servicio }, historialServicio); // Corregido el cierre de paréntesis y punto y coma
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialTransac(int id)
        {
            var historialServicio = await _context.Servicios.FindAsync(id);
            if (historialServicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(historialServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialTransacExists(int id)
        {
            return _context.Servicios.Any(e => e.ID_Servicio == id); // Corregido el nombre de la variable
        }
    }
}
