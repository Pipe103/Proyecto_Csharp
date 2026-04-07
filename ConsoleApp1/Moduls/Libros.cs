namespace ConsoleApp1.Models
{
    public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";       // Inicializado para evitar CS8618
    public string ISBN { get; set; } = "";
    public string Autor { get; set; } = "";
    public string Categoria { get; set; } = "";
    public int Anio { get; set; }
    public bool Disponible { get; set; }
}
}