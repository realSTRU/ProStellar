
using Microsoft.EntityFrameworkCore;
using ProStellar.Shared.Models;

namespace ProStellar.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }

        public DbSet<Cantidad> Cantidades { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<TipoPago> TiposPagos { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
    }
}