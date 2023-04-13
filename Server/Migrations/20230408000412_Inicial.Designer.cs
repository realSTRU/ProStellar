﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProStellar.Server.DAL;

#nullable disable

namespace ProStellar.Server.Migrations
{
    [DbContext(typeof(Contexto))]
<<<<<<<< HEAD:Server/Migrations/20230408000412_Inicial.Designer.cs
    [Migration("20230408000412_Inicial")]
========
    [Migration("20230412003628_Inicial")]
>>>>>>>> FrontEnd:Server/Migrations/20230412003628_Inicial.Designer.cs
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("ProStellar.Shared.Models.Cantidad", b =>
                {
                    b.Property<int>("CantidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("CantidadId");

                    b.ToTable("Cantidades");

                    b.HasData(
                        new
                        {
                            CantidadId = 1,
                            Descripcion = "Día completo",
                            Valor = 1.0
                        },
                        new
                        {
                            CantidadId = 2,
                            Descripcion = "Medio Día",
                            Valor = 0.5
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            EmpleadoId = 1,
                            PrimerApellido = "Duran",
                            PrimerNombre = "Kevin",
                            SegundoApellido = "Bruno",
                            SegundoNombre = "Javier",
                            Telefono = "809-396-8457"
                        },
                        new
                        {
                            EmpleadoId = 2,
                            PrimerApellido = "Germosen",
                            PrimerNombre = "Manuel",
                            SegundoApellido = "Santos",
                            SegundoNombre = "Ernesto",
                            Telefono = "849-456-1153"
                        },
                        new
                        {
                            EmpleadoId = 3,
                            PrimerApellido = "Perdomo",
                            PrimerNombre = "Jose",
                            SegundoApellido = "Escobar",
                            SegundoNombre = "Matias",
                            Telefono = "809-588-5555"
                        },
                        new
                        {
                            EmpleadoId = 4,
                            PrimerApellido = "Del Orbe",
                            PrimerNombre = "Samuel",
                            SegundoApellido = "De Jesus",
                            SegundoNombre = "Martin",
                            Telefono = "829-876-2231"
                        },
                        new
                        {
                            EmpleadoId = 5,
                            PrimerApellido = "Rodriguez",
                            PrimerNombre = "Cesar",
                            SegundoApellido = "Jimenez",
                            SegundoNombre = "Enmanuel",
                            Telefono = "849-456-5356"
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Descripcion = "Con deuda"
                        },
                        new
                        {
                            EstadoId = 2,
                            Descripcion = "Paga"
                        },
                        new
                        {
                            EstadoId = 3,
                            Descripcion = "Vacia"
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Nomina", b =>
                {
                    b.Property<int>("NominaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstadoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NominaId");

                    b.ToTable("Nominas");
                });

            modelBuilder.Entity("ProStellar.Shared.Models.NominaDetalle", b =>
                {
                    b.Property<int>("NominaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<int>("CantidadId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombrePersona")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NominaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("TrabajoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NominaDetalleId");

                    b.HasIndex("NominaId");

                    b.ToTable("NominaDetalle");
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("NominaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PagoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("ProStellar.Shared.Models.PagoDetalle", b =>
                {
                    b.Property<int>("PagoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NominaDetalleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PagoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoPagoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorPagado")
                        .HasColumnType("REAL");

                    b.HasKey("PagoDetalleId");

                    b.HasIndex("PagoId");

                    b.ToTable("PagoDetalle");
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            ProyectoId = 1,
                            Descripcion = "Enel´s new house"
                        },
                        new
                        {
                            ProyectoId = 2,
                            Descripcion = "DURE Interprise BUILD"
                        },
                        new
                        {
                            ProyectoId = 3,
                            Descripcion = "Reconstrucción UCNE"
                        },
                        new
                        {
                            ProyectoId = 4,
                            Descripcion = "circunvalación Oeste"
                        },
                        new
                        {
                            ProyectoId = 5,
                            Descripcion = "La Javiela Bar Red Design"
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.TipoPago", b =>
                {
                    b.Property<int>("TipoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoPagoId");

                    b.ToTable("TiposPagos");

                    b.HasData(
                        new
                        {
                            TipoPagoId = 1,
                            Descripcion = "Pago común"
                        },
                        new
                        {
                            TipoPagoId = 2,
                            Descripcion = "Adelanto"
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Trabajo", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("TrabajoId");

                    b.ToTable("Trabajos");

                    b.HasData(
                        new
                        {
                            TrabajoId = 1,
                            Descripcion = "Maestro Constructor",
                            Precio = 2000.0
                        },
                        new
                        {
                            TrabajoId = 2,
                            Descripcion = "Peon de construcción",
                            Precio = 700.0
                        },
                        new
                        {
                            TrabajoId = 3,
                            Descripcion = "Carpintero",
                            Precio = 1500.0
                        },
                        new
                        {
                            TrabajoId = 4,
                            Descripcion = "Electricista",
                            Precio = 7800.0
                        },
                        new
                        {
                            TrabajoId = 5,
                            Descripcion = "Profesional de redes",
                            Precio = 27000.0
                        });
                });

            modelBuilder.Entity("ProStellar.Shared.Models.NominaDetalle", b =>
                {
                    b.HasOne("ProStellar.Shared.Models.Nomina", null)
                        .WithMany("Detalles")
                        .HasForeignKey("NominaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProStellar.Shared.Models.PagoDetalle", b =>
                {
                    b.HasOne("ProStellar.Shared.Models.Pago", null)
                        .WithMany("Detalles")
                        .HasForeignKey("PagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Nomina", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("ProStellar.Shared.Models.Pago", b =>
                {
                    b.Navigation("Detalles");
                });
#pragma warning restore 612, 618
        }
    }
}
