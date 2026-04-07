using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class LibroService
    {
        private List<Libro> libros;

        public LibroService(List<Libro> libros)
        {
            this.libros = libros ?? new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        public bool EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
                return false;

            libros.Remove(libro);
            return true;
        }

        public Libro? BuscarPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public List<Libro> BuscarPorTitulo(string titulo)
        {
            return libros
                .Where(l => l.Titulo.ToLower().Contains(titulo.ToLower()))
                .ToList();
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros
                .Where(l => l.Autor.ToLower().Contains(autor.ToLower()))
                .ToList();
        }

        public Libro? BuscarPorISBN(string isbn)
        {
            return libros.FirstOrDefault(l => l.ISBN == isbn);
        }

        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        public List<Libro> OrdenarPorAnio()
        {
            return libros.OrderBy(l => l.Anio).ToList();
        }

        public int TotalLibros()
        {
            return libros.Count;
        }

        public int LibrosDisponibles()
        {
            return libros.Count(l => l.Disponible);
        }

        public int LibrosPrestados()
        {
            return libros.Count(l => !l.Disponible);
        }
    }
}