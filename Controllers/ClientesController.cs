using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BANCOATM1.BD;
using BANCOATM1.Models;
using System.Net.Mail;
using System.Net;

namespace BANCOATM1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientes), new { id = cliente.ID_cliente }, cliente);
        }

        // DELETE: api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ID_cliente == id);
        }

        [HttpGet("BuscarPorNumTarjeta/{numTarjeta}")]
        public async Task<ActionResult<Cliente>> GetClienteByNumTarjeta(long numTarjeta)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.NumTarjeta == numTarjeta);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("BuscarPorNip/{Nip}")]
        public async Task<ActionResult<Cliente>> GetClienteByNip(int Nip)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nip == Nip);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("BuscarPorID/{ID}")]
        public async Task<ActionResult<Cliente>> GetClienteByID(int ID)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ID_cliente == ID);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        // PUT: api/clientes/Actualizar/{ID}
        [HttpPut("Actualizar/{ID}")]
        public async Task<IActionResult> PutCliente(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.SaldoTarjeta = cliente.SaldoTarjeta;
            clienteExistente.LimTrans = cliente.LimTrans;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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

        [HttpPut("ActualizarAduedoTarjeta/{ID}")]
        public async Task<IActionResult> PutClienteSaldo(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.AdeuTarjeta = cliente.AdeuTarjeta;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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

        [HttpPut("ActualizarSErvicio/{ID}")]
        public async Task<IActionResult> PutClienteServicio(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.SaldoTarjeta = cliente.SaldoTarjeta;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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
        [HttpPut("ActualizarNip/{ID}")]
        public async Task<IActionResult> PutClienteID(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.Nip = cliente.Nip;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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


        [HttpPut("ActualizarCE/{ID}")]
        public async Task<IActionResult> PutClienteCEID(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.ACE = cliente.ACE;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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

        [HttpPut("ActualizarHipoteca/{ID}")]
        public async Task<IActionResult> PutClienteHipoteca(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.AdeuHipoteca = cliente.AdeuHipoteca;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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

        [HttpPut("ActualizarAdeucarro/{ID}")]
        public async Task<IActionResult> PutClienteCarro(int ID, [FromBody] Cliente cliente)
        {


            // Obtener el cliente existente de la base de datos
            var clienteExistente = await _context.Clientes.FindAsync(ID);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar el saldo de la tarjeta
            clienteExistente.AdeuCarro = cliente.AdeuCarro;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ID))
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


    }
}
