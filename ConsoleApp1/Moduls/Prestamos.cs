using System;

namespace ConsoleApp1.Models
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; }

        public Prestamo()
        {
            Estado = "Activo";
            FechaDevolucion = null;
        }

        public Prestamo(int idPrestamo, int idUsuario, int idLibro, DateTime fechaPrestamo, DateTime fechaLimite)
        {
            IdPrestamo = idPrestamo;
            IdUsuario = idUsuario;
            IdLibro = idLibro;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            FechaDevolucion = null;
            Estado = "Activo";
        }

        public bool EstaVencido()
        {
            return Estado == "Activo" && DateTime.Now > FechaLimite;
        }

        public int DiasTranscurridos()
        {
            DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;
            return (fechaFinal - FechaPrestamo).Days;
        }

        public string ResumenCorto()
        {
            return $"Préstamo #{IdPrestamo} - Usuario: {IdUsuario} - Libro: {IdLibro} - Estado: {Estado}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {IdPrestamo}\nUsuario: {IdUsuario}\nLibro: {IdLibro}\nFecha préstamo: {FechaPrestamo}\nFecha límite: {FechaLimite}\nFecha devolución: {(FechaDevolucion.HasValue ? FechaDevolucion.ToString() : "No devuelto")}\nEstado: {Estado}";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}