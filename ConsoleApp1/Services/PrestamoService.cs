using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos;
        private List<Usuario> usuarios;
        private List<Libro> libros;

        private int contadorPrestamoId = 1;

        public PrestamoService(List<Prestamo> prestamos, List<Usuario> usuarios, List<Libro> libros)
        {
            this.prestamos = prestamos;
            this.usuarios = usuarios;
            this.libros = libros;
        }

        public string CrearPrestamo(int usuarioId, int libroId)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null || !usuario.Activo)
                return "Usuario no válido.";

            var libro = libros.FirstOrDefault(l => l.Id == libroId);
            if (libro == null || !libro.Disponible)
                return "Libro no disponible.";

            var prestamo = new Prestamo
            {
                IdPrestamo = contadorPrestamoId++,
                IdUsuario = usuarioId,
                IdLibro = libroId,
                FechaPrestamo = DateTime.Now,
                FechaLimite = DateTime.Now.AddDays(7),
                Estado = "Activo"
            };

            prestamos.Add(prestamo);
            libro.Disponible = false;

            return "Préstamo creado correctamente.";
        }

        public string RegistrarDevolucion(int prestamoId)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.IdPrestamo == prestamoId);

            if (prestamo == null)
                return "Préstamo no encontrado.";

            if (prestamo.Estado == "Devuelto")
                return "El préstamo ya fue devuelto.";

            prestamo.Estado = "Devuelto";
            prestamo.FechaDevolucion = DateTime.Now;

            var libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);
            if (libro != null)
                libro.Disponible = true;

            return "Devolución registrada correctamente.";
        }

        public string EliminarPrestamo(int id)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.IdPrestamo == id);

            if (prestamo == null)
                return "Préstamo no encontrado.";

            if (prestamo.Estado == "Activo")
            {
                var libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);
                if (libro != null)
                    libro.Disponible = true;
            }

            prestamos.Remove(prestamo);

            return "Préstamo eliminado correctamente.";
        }

        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        public List<Prestamo> ObtenerActivos()
        {
            return prestamos.Where(p => p.Estado == "Activo").ToList();
        }

        public List<Prestamo> ObtenerDevueltos()
        {
            return prestamos.Where(p => p.Estado == "Devuelto").ToList();
        }

        public Prestamo? BuscarPorId(int id)
        {
            return prestamos.FirstOrDefault(p => p.IdPrestamo == id);
        }

        public List<Prestamo> ObtenerPorUsuario(int usuarioId)
        {
            return prestamos.Where(p => p.IdUsuario == usuarioId).ToList();
        }
    }
}