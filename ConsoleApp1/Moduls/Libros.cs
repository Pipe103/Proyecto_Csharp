namespace Moduls;

public class Libro
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public int Anio { get; set; }
    public bool Disponible { get; set; }

    public Libro()
    {
        Disponible = true;
    }

    public Libro(int id, string isbn, string titulo, string autor, string categoria, int anio)
    {
        Id = id;
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Anio = anio;
        Disponible = true;
    }

    public string ResumenCorto()
    {
        return $"ID: {Id} | {Titulo} | {(Disponible ? "Disponible" : "Prestado")}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\nISBN: {ISBN}\nTítulo: {Titulo}\nAutor: {Autor}\nCategoría: {Categoria}\nAño: {Anio}\nEstado: {(Disponible ? "Disponible" : "Prestado")}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
