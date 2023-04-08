
using Microsoft.EntityFrameworkCore;
using ProStellar.Shared.Models;
using System.Linq.Expressions;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    EmpleadoId = 1,
                    PrimerNombre = "Kevin",
                    SegundoNombre = "Javier",
                    PrimerApellido = "Duran",
                    SegundoApellido = "Bruno",
                    Telefono = "809-396-8457"
                },

                new Empleado
                {
                    EmpleadoId = 2,
                    PrimerNombre = "Manuel",
                    SegundoNombre = "Ernesto",
                    PrimerApellido = "Germosen",
                    SegundoApellido = "Santos",
                    Telefono = "849-456-1153"
                },
                new Empleado
                {
                    EmpleadoId = 3,
                    PrimerNombre = "Jose",
                    SegundoNombre = "Matias",
                    PrimerApellido = "Perdomo",
                    SegundoApellido = "Escobar",
                    Telefono = "809-588-5555"
                },
                new Empleado
                {
                    EmpleadoId = 4,
                    PrimerNombre = "Samuel",
                    SegundoNombre = "Martin",
                    PrimerApellido = "Del Orbe",
                    SegundoApellido = "De Jesus",
                    Telefono = "829-876-2231"
                },
                new Empleado
                {
                    EmpleadoId = 5,
                    PrimerNombre = "Cesar",
                    SegundoNombre = "Enmanuel",
                    PrimerApellido = "Rodriguez",
                    SegundoApellido = "Jimenez",
                    Telefono = "849-456-5356"
                }
                );

            modelBuilder.Entity<Trabajo>().HasData(

                new Trabajo
                {
                    TrabajoId = 1,
                    Descripcion = "Maestro Constructor",
                    Precio = 2000.00
                },
                new Trabajo
                {
                    TrabajoId = 2,
                    Descripcion =  "Peon de construcción",
                    Precio = 700.00
                },
                new Trabajo
                {
                    TrabajoId = 3,
                    Descripcion = "Carpintero",
                    Precio = 1500.00
                }

                );

            modelBuilder.Entity<Estado>().HasData(

                new Estado
                {
                    EstadoId = 1,
                    Descripcion = "Con deuda pendiente"
                },
                new Estado
                {
                    EstadoId = 2,
                    Descripcion = "Saldada/Pagada"
                }



                );
            modelBuilder.Entity<Proyecto>().HasData(
                new  Proyecto
                {
                    ProyectoId = 1,
                    Descripcion = "Enel´s new house"
                },

                new Proyecto
                {
                    ProyectoId = 2,
                    Descripcion  = "DURE Interprise BUILD"
                }
                
                
                );

            modelBuilder.Entity<Cantidad>().HasData(
                
                    new Cantidad
                    {
                        CantidadId = 1,
                        Descripcion = "Día completo",
                        Valor = 0.5
                    },
                    new Cantidad
                    {
                        CantidadId = 2,
                        Descripcion = "Medio Día",
                        Valor = 1
                    }
                
                );
            modelBuilder.Entity<TipoPago>().HasData(
                
                new TipoPago
                {
                    TipoPagoId = 1,
                    Descripcion = "Pago común"
                },
                new TipoPago
                {
                    TipoPagoId = 2,
                    Descripcion = "Adelanto"
                }


                
                
                );

            
            
        }
    }
}