using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios;
        private List<Prestamo> prestamos;

        public UsuarioService(List<Usuario> usuarios, List<Prestamo> prestamos)
        {
            this.usuarios = usuarios ?? new List<Usuario>();
            this.prestamos = prestamos ?? new List<Prestamo>();
        }

        public bool RegistrarUsuario(Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null)
                return false;

            // Validar duplicado por documento
            if (usuarios.Any(u => u.Documento == nuevoUsuario.Documento))
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese documento.");
                return false;
            }

            usuarios.Add(nuevoUsuario);
            return true;
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        public Usuario? BuscarPorIdODocumento(string entrada)
        {
            if (string.IsNullOrEmpty(entrada))
                return null;

            if (int.TryParse(entrada, out int idBuscado))
            {
                return usuarios.FirstOrDefault(u => u.Id == idBuscado);
            }
            else
            {
                return usuarios.FirstOrDefault(u => u.Documento == entrada);
            }
        }

        public bool ActualizarUsuario(int id, Usuario datosActualizados)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return false;

            usuario.Nombre = datosActualizados.Nombre;
            usuario.Apellido = datosActualizados.Apellido;
            usuario.Documento = datosActualizados.Documento;
            usuario.Correo = datosActualizados.Correo;
            usuario.Telefono = datosActualizados.Telefono;

            return true;
        }


        public bool PuedeEliminar(int id)
        {
            return !prestamos.Any(p => p.IdUsuario == id && p.Estado == "Activo");
        }


        public bool EliminarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return false;

            if (!PuedeEliminar(id))
            {
                Console.WriteLine("⚠️ No se puede eliminar: tiene préstamos activos.");
                return false;
            }

            usuarios.Remove(usuario);
            return true;
        }
    }
}