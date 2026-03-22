using System;
namespace Usuarios
{
public class Usuario
{
    public Usuario(){}

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }


    public Usuario(int id, string nombre, string apellido, string documento, string correo, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
        Correo = correo;
        Telefono = telefono;
        Activo = true; 
    }


    public string ResumenCorto()
    {
        return $"{Id} - {Nombre} {Apellido}";
    }


    public string DetalleCompleto()
    {
        return $"ID: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nDocumento: {Documento}\nCorreo: {Correo}\nTeléfono: {Telefono}\nActivo: {Activo}";
    }

 
    public override string ToString()
    {
        return ResumenCorto();
    }
}
}