using BANCOATM1.BD;
using BANCOATM1.BD.Models;
using BANCOATM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BANCOATM1.BD
{
    public class AppDbContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<HistorialTransac> Transacs { get; set; }
        public DbSet<HistorialServicio> Servicios { get; set; }
        public DbSet<HistorialCreditoEducativo> HistorialCreditosEducativos { get; set; }
        public DbSet<HistorialCreditoPagos> HistorialCreditoPagos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}


 