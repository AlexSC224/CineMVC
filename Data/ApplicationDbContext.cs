using CineMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CineMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Relaciones
            builder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Funcion>()
                .HasOne(f => f.Pelicula)
                .WithMany(p => p.Funciones)
                .HasForeignKey(f => f.PeliculaId);

            builder.Entity<Funcion>()
                .HasOne(f => f.Sala)
                .WithMany(s => s.Funciones)
                .HasForeignKey(f => f.SalaId);

            builder.Entity<Reserva>()
                .HasOne(r => r.Funcion)
                .WithMany(f => f.Reservas)
                .HasForeignKey(r => r.FuncionId);

            // 🔧 Configurar precisión para decimales
            builder.Entity<Funcion>()
                .Property(f => f.PrecioEntrada)
                .HasPrecision(18, 2);

            builder.Entity<Reserva>()
                .Property(r => r.Total)
                .HasPrecision(18, 2);

            // Datos iniciales para Peliculas
            builder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    Id = 1,
                    Titulo = "Avengers: Endgame",
                    Duracion = "3h 2min",
                    Genero = "Acción",
                    Clasificacion = "+13",
                    Sinopsis = "Los Vengadores restantes luchan por restaurar el universo.",
                    ImagenBase64 = "",
                    Activa = true
                },
                new Pelicula
                {
                    Id = 2,
                    Titulo = "Coco",
                    Duracion = "1h 45min",
                    Genero = "Animación",
                    Clasificacion = "ATP",
                    Sinopsis = "Un niño se adentra en la Tierra de los Muertos para encontrar a su tatarabuelo.",
                    ImagenBase64 = "",
                    Activa = true
                }
            );

            // Datos iniciales para Salas
            builder.Entity<Sala>().HasData(
                new Sala { Id = 1, Nombre = "Sala 1", Capacidad = 100 },
                new Sala { Id = 2, Nombre = "Sala 2", Capacidad = 80 }
            );

            // Datos iniciales para Funciones
            builder.Entity<Funcion>().HasData(
                new Funcion
                {
                    Id = 1,
                    PeliculaId = 1,
                    SalaId = 1,
                    FechaHora = new DateTime(2025, 8, 1, 18, 0, 0, DateTimeKind.Utc), // Especificar UTC
                    PrecioEntrada = 30.00m
                },
                new Funcion
                {
                    Id = 2,
                    PeliculaId = 2,
                    SalaId = 2,
                    FechaHora = new DateTime(2025, 8, 2, 16, 0, 0, DateTimeKind.Utc), // Especificar UTC
                    PrecioEntrada = 25.00m
                }
            );
        }

    }
}
