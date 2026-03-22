using System;
using System.Collections.Generic;
using Libros;
namespace ConsoleApp1;

class Program
{
    static List<Libro> libros = new List<Libro>();
    static int contadorId = 1;
    static void Main(string[] args)
    {
///////////////////////////// MENU PRINCIPAL////////////////////////////////////////////

        bool salir = false;
        while (!salir)
        {
        Console.Clear();
        Console.WriteLine("1. Libro");
        Console.WriteLine("2. Usuario");
        Console.WriteLine("3. Prestamos");
        Console.WriteLine("4. Busquedas y Reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");
        Console.WriteLine("");
        Console.Write("Seleccione una opción: ");
        int opcionMenuPrincipal = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        

            switch (opcionMenuPrincipal)
            {
                case 1:
                    MenuLibro();
                    break;
                case 2:
                    MenuUsuario();
                    break;
                case 3:
                    MenuPrestamos();
                    break;
                case 4:
                    BusquedasReportes();
                    break;
                case 5:
                    GuardarCargarDatos();
                    break;
                case 6:
                    salir = true;
                    Salir();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
    }
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////MENU DE LIBRO///////////////////////////////////
      static void MenuLibro()

    {
        
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle del libro por ID/ISBN");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("6. Volver al menú principal");
        Console.WriteLine("");
        Console.Write("Seleccione una opción: ");
        int opcionMenuLibro = int.Parse(Console.ReadLine());
        Console.WriteLine("");

            switch (opcionMenuLibro)
            {
                case 1:
                    RegistrarLibro();
                    break;
                case 2:
                    ListarLibros();
                    break;
                case 3:
                    VerDetalleLibro();
                    break;
                case 4:
                    ActualizarLibro();
                    break;
                case 5:
                    EliminarLibro();
                    break;
                case 6:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
    }

}
static void RegistrarLibro()
    {
        Console.Clear();
        Console.WriteLine("Registrar nuevo libro");
        Console.WriteLine("");
        Libro nuevo = new Libro();
        nuevo.Id = contadorId++;

        Console.WriteLine("Titulo : ");
        nuevo.Titulo = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("ISBN : ");
        nuevo.ISBN = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Autor : ");
        nuevo.Autor = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Categoria : ");
        nuevo.Categoria = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Año");
        nuevo.Anio = int.Parse(Console.ReadLine());

        Console.Write("¿Está disponible? (s/n): ");
        string estado = Console.ReadLine().ToLower();

        if (estado == "s"){
        nuevo.Disponible = true;
        }else{
        nuevo.Disponible = false;
        }

        libros.Add(nuevo);

        Console.WriteLine("");
        Console.WriteLine("Presiona enter volver al menú libro");
        Console.ReadKey();
    }
    // menu listar
static void ListarLibros()
    {
        bool volver = false;
    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("Listado de Libros");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("4. Volver al menú de libros");
        Console.Write("\nSeleccione una opción: ");

        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ListarTodos();
                break;
            case 2:
                ListarDisponibles();
                break;
            case 3:
                ListarPrestados();
                break;
            case 4:
                volver = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                Console.ReadKey();
                break;
        }
    }

}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ListarTodos()
{
    Console.Clear();
    Console.WriteLine("Todos los libros");

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (var libro in libros)
        {
            Console.WriteLine($"ID: {libro.Id} | ISBN: {libro.ISBN} | Título: {libro.Titulo} | Autor: {libro.Autor} | Categoría: {libro.Categoria} | Año: {libro.Anio}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();

}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ListarDisponibles()
{
     Console.Clear();
    Console.WriteLine("Libros disponibles:\n");

    var disponibles = libros.Where(l => l.Disponible).ToList();

    if (disponibles.Count == 0)
    {
        Console.WriteLine("No hay libros disponibles.");
    }
    else
    {
        foreach (var libro in disponibles)
        {
            Console.WriteLine($"ID: {libro.Id} | ISBN: {libro.ISBN} | Título: {libro.Titulo} | Autor: {libro.Autor} | Categoría: {libro.Categoria} | Año: {libro.Anio}");
        }
    }

    Console.WriteLine("Presiona una tecla para volver...");
    Console.ReadKey();

}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ListarPrestados()
{
    Console.Clear();
    Console.WriteLine("Libros prestados:");
    Console.WriteLine("");

    var prestados = libros.Where(l => !l.Disponible).ToList();

    if (prestados.Count == 0)
    {
        Console.WriteLine("No hay libros prestados.");
    }
    else
    {
        foreach (var libro in prestados)
        {
            Console.WriteLine($"ID: {libro.Id} | ISBN: {libro.ISBN} | Título: {libro.Titulo} | Autor: {libro.Autor} | Categoría: {libro.Categoria} | Año: {libro.Anio}");
        }
    }
    
    Console.WriteLine("");
    Console.WriteLine("Presiona una tecla para volver...");
    Console.ReadKey();

}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////




////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void VerDetalleLibro()
    { 
        Console.Clear();
    Console.WriteLine("Ver detalle del libro");
    Console.WriteLine("");

    Console.Write("Ingrese ID o ISBN: ");
    string entrada = Console.ReadLine();
    int idBuscado;
    Libro encontrado = null;

    if (int.TryParse(entrada, out idBuscado))
    {
        encontrado = libros.FirstOrDefault(l => l.Id == idBuscado);
    }
    else
    {
        encontrado = libros.FirstOrDefault(l => l.ISBN == entrada);
    }

    Console.Clear();
    if (encontrado == null)
    {
        Console.WriteLine("No se encontró ningún libro con ese ID/ISBN.");
    }
    else
    {
        Console.WriteLine("Detalle del libro:");
        Console.WriteLine($"ID: {encontrado.Id}");
        Console.WriteLine($"ISBN: {encontrado.ISBN}");
        Console.WriteLine($"Título: {encontrado.Titulo}");
        Console.WriteLine($"Autor: {encontrado.Autor}");
        Console.WriteLine($"Categoría: {encontrado.Categoria}");
        Console.WriteLine($"Año: {encontrado.Anio}");
    }
    
    Console.WriteLine("");
    Console.WriteLine("Presiona una tecla para volver al menú libro...");
    Console.ReadKey();

}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ActualizarLibro()
{
    Console.Clear();
    Console.WriteLine("Actualizar libro");
    Console.WriteLine("");

    Console.Write("Ingrese el ID o ISBN del libro a actualizar: ");
    string entrada = Console.ReadLine();

    int idBuscado;
    Libro encontrado = null;

    if (int.TryParse(entrada, out idBuscado))
    {
        encontrado = libros.FirstOrDefault(l => l.Id == idBuscado);
    }
    else
    {
        encontrado = libros.FirstOrDefault(l => l.ISBN == entrada);
    }

    if (encontrado == null)
    {
        Console.WriteLine("No se encontró ningún libro con ese ID/ISBN.");
    }
    else
    {
        Console.WriteLine("Libro encontrado:");
        Console.WriteLine($"ID: {encontrado.Id} | ISBN: {encontrado.ISBN} | Título: {encontrado.Titulo} | Autor: {encontrado.Autor} | Categoría: {encontrado.Categoria} | Año: {encontrado.Anio}");

        Console.WriteLine("Ingrese los nuevos valores (deje vacío si no desea cambiar):");

        Console.Write("Nuevo título: ");
        string nuevoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoTitulo))
            encontrado.Titulo = nuevoTitulo;

        Console.Write("Nuevo autor: ");
        string nuevoAutor = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoAutor))
            encontrado.Autor = nuevoAutor;

        Console.Write("Nuevo año: ");
        string nuevoAnio = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoAnio) && int.TryParse(nuevoAnio, out int anio))
            encontrado.Anio = anio;

        Console.Write("Nueva categoría: ");
        string nuevaCategoria = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaCategoria))
            encontrado.Categoria = nuevaCategoria;

        Console.WriteLine("Libro actualizado correctamente.");
    }

    Console.WriteLine("");
    Console.WriteLine("Presiona una tecla para volver al menú...");
    Console.ReadKey();
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void EliminarLibro()
    {
        Console.Clear();
    Console.WriteLine("Eliminar libro");
    Console.WriteLine("");

    Console.Write("Ingrese el ID o ISBN del libro a eliminar: ");
    string entrada = Console.ReadLine();

    int idBuscado;
    Libro encontrado = null;
    if (int.TryParse(entrada, out idBuscado))
    {
        encontrado = libros.FirstOrDefault(l => l.Id == idBuscado);
    }
    else
    {
        encontrado = libros.FirstOrDefault(l => l.ISBN == entrada);
    }

    Console.Clear();
    if (encontrado == null)
    {
        Console.WriteLine("No se encontró ningún libro con ese ID/ISBN.");
    }
    else
    {
        if (!encontrado.Disponible)
        {
            Console.WriteLine("El libro no puede eliminarse porque está prestado.");
        }
        else
        {
            libros.Remove(encontrado);
            Console.WriteLine($"Libro '{encontrado.Titulo}' eliminado correctamente.");
        }
    }

    Console.WriteLine("");
    Console.WriteLine("Presiona una tecla para volver al menú...");
    Console.ReadKey();

    }


/// 
/// MENU DE USUARIO
/// 


public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }
}
static void MenuUsuario()
    {
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle de usuarios por ID / documento");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("6. Volver al menú principal");

        Console.WriteLine("Ingrese una opción:");
        int opcionMenuUsuario = int.Parse(Console.ReadLine());
        Console.WriteLine("");



        switch (opcionMenuUsuario)
            {
                case 1:
                    RegistrarUsuario();
                    break;
                case 2:
                    ListarUsuarios();
                    break;
                case 3:
                    VerDetalleUsuario();
                    break;
                case 4:
                    ActualizarUsuario();
                    break;
                case 5:
                    EliminarUsuario();
                    break;
                case 6:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }

    }

    static void RegistrarUsuario()
    {
        Console.Clear();
        Console.WriteLine("Registrar nuevo usuario");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Presiona enter volver al menú usuario");
        Console.ReadKey();
    }
    static void ListarUsuarios()
    {
        Console.Clear();
        Console.WriteLine("Listado de usuarios");
        Console.WriteLine("");
        Console.WriteLine("Presiona enter volver al menú usuario");
        Console.ReadKey();
}
static void VerDetalleUsuario()
    {
        Console.Clear();
        Console.WriteLine("Ver detalle del usuario por ID/documento");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú usuario");
        Console.ReadKey();
}
static void ActualizarUsuario()
    {
        Console.Clear();
        Console.WriteLine("Editar nombre");
        Console.WriteLine("");
        Console.WriteLine("Editar contacto");
        Console.WriteLine("");
        Console.WriteLine("Activar / desactivar");
        Console.WriteLine("");

        Console.WriteLine("Presiona enter volver al menú usuario");
        Console.ReadKey();
}
static void EliminarUsuario()
    {
        Console.Clear();
        bool tienePrestamosActivos = false;
        Console.WriteLine("Eliminar usuario");
        Console.ReadKey();
    }
}


// menu prestamos

public class Prestamo
{
    public int IdPrestamo { get; set; }
    public int IdUsuario { get; set; }
    public int IdLibro { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaLimite { get; set; }
    public DateTime? FechaDevolucion { get; set; } 
    public string Estado { get; set; } = "Activo";
}

static void MenuPrestamos()
    {
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("1. Crear nuevo préstamo");
        Console.WriteLine("2. Listar préstamos");
        Console.WriteLine("3. Ver detalle del préstamo por ID");
        Console.WriteLine("4. Registrar devolución");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("6. Volver al menú principal");

        Console.WriteLine("Ingrese una opción:");
        int opcionMenuPrestamos = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        switch (opcionMenuPrestamos)
            {
                case 1:
                    CrearPrestamo();
                    break;
                case 2:
                    ListarPrestamos();
                    break;
                case 3:
                    VerDetallePrestamo();
                    break;
                case 4:
                    RegistrarDevolucion();
                    break;
                case 5:
                    EliminarPrestamo();
                    break;
                case 6:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
}
    }
    static void CrearPrestamo()
    {
        Console.Clear();
        Console.WriteLine("Usuario existe y esta activo");
        Console.WriteLine("");
        Console.WriteLine("Libro existe y esta disponible");
        Console.WriteLine("");

        Console.WriteLine("Presiona enter volver al menú préstamos");
        Console.ReadKey();
    }
    static void ListarPrestamos()
    {
        Console.Clear();
        Console.WriteLine("Todos");
        Console.WriteLine("Activos");
        Console.WriteLine("Devueltos");
        Console.WriteLine("");

        Console.WriteLine("Volver al menú préstamos");
        Console.ReadKey();
}
static void VerDetallePrestamo()
    {
        Console.Clear();
        Console.WriteLine("Ver detalle del préstamo por ID");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú préstamos");
        Console.ReadKey();
}
static void RegistrarDevolucion()
    {
        Console.Clear();
        Console.WriteLine("Cambia el prestamo a devuelto");
        Console.WriteLine("Marca el libro como disponible");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú préstamos");
        Console.ReadKey();
}
static void EliminarPrestamo()
    {
        Console.Clear();
        Console.WriteLine("ADVERTENCIA: Esta acción no se puede deshacer");
        Console.WriteLine("");
        Console.WriteLine("Recomendacion : recomendado: solo si está cerrado o fue creado por error; si lo borras activo, debes devolver el libro automáticamente");
        Console.WriteLine("");
        Console.WriteLine("Eliminar préstamo");
        Console.ReadKey();
}

// menu busquedas y reportes
static void BusquedasReportes()
    {
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("1. Buscar libro");
        Console.WriteLine("2. Buscar usuario");
        Console.WriteLine("3. Reportes");
        Console.WriteLine("4. Volver al menú principal");
        
        Console.WriteLine("ingrese una opcion");
        int opcionMenuBusquedas = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        switch (opcionMenuBusquedas)
            {
                case 1:
                    BuscarLibro();
                    break;
                case 2:
                    BuscarUsuario();
                    break;
                case 3:
                    Reportes();
                    break;
                case 4:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
}
    }
    static void BuscarLibro()
    {
        Console.Clear();
        Console.WriteLine("SELECCIONA EL CRITERIO DE BUSQUEDA");
        Console.WriteLine("1. titulo");
        Console.WriteLine("2. autor");
        Console.WriteLine("3. ID/IBSN");
        Console.WriteLine("4. categoria");

        Console.WriteLine("Ingrese una opcion");
        int opcionBuscarLibro = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        switch (opcionBuscarLibro)
            {
                case 1:
                    BuscarRepotePorTitulo();
                    break;
                case 2:
                    BuscarRepotePorAutor();
                    break;
                case 3:
                    BuscarRepotePorID();
                    break;
                case 4:
                BuscarRepotePorCategoria();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenteuevamente.");
                    Console.ReadKey(); 
                    break;
            }
        

        Console.ReadKey();
    }
    static void BuscarRepotePorTitulo()
    {
        Console.Clear();
        Console.WriteLine("Buscar libro por titulo");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
    static void BuscarRepotePorAutor()
    {
        Console.Clear();
        Console.WriteLine("Buscar libro por autor");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
    static void BuscarRepotePorID()
    {
        Console.Clear();
        Console.WriteLine("Buscar libro por ID/ISBN");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
    static void BuscarRepotePorCategoria()
    {
        Console.Clear();
        Console.WriteLine("Buscar libro por categoria");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
    static void BuscarUsuario()
    {
        bool volver = false;
        while (!volver){
        Console.Clear();
        Console.WriteLine("SELECCIONA EL CRITERIO DE BUSQUEDA");
        Console.WriteLine("1. nombre");
        Console.WriteLine("2. ID/documento");
        Console.WriteLine("3. volver al menu busquedas y reportes");

        Console.WriteLine("Ingrese una opcion");
        int opcionBuscarUsuarios = int.Parse(Console.ReadLine());
        Console.WriteLine("");



            switch (opcionBuscarUsuarios)
            {
                case 1:
                    BuscarUsuarioPorNombre();
                    break;
                case 2:
                    BuscarUsuarioPorID();
                    break;
                case 3: 
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
}
    }
    static void BuscarUsuarioPorNombre()
    {
        Console.Clear();
        Console.WriteLine("Buscar usuario por nombre");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
    static void BuscarUsuarioPorID()
    {
        Console.Clear();
        Console.WriteLine("Buscar usuario por ID/documento");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú busquedas y reportes");
        Console.ReadKey();
    }
static void Reportes()
    {
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("REPORTES");
        Console.WriteLine("1. Prestamos por usuario");
        Console.WriteLine("2. Prestamos por libro");
        Console.WriteLine("3. Prestamos vencidos");
        Console.WriteLine("4. Resumen general");
        Console.WriteLine("5. Volver al menú busquedas y reportes");

        Console.WriteLine("Ingrese una opcion");
        int opcionMenuReportes = int.Parse(Console.ReadLine());
        

        Console.WriteLine("");

        switch (opcionMenuReportes)
            {
                case 1:
                    PrestamosPorUsuario();
                    break;
                case 2:
                    PrestamosPorLibro();
                    break;
                case 3:
                    PrestamosVencidos();
                    break;
                case 4:
                    ResumenGeneral();
                    break;
                case 5:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
        }
        }
    }
static void PrestamosPorUsuario()
    {
        Console.Clear();
        Console.WriteLine("Listar préstamos por usuario");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú reportes");
        Console.ReadKey();
}
static void PrestamosPorLibro()
    {
        Console.Clear();
        Console.WriteLine("Listar préstamos por libro");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú reportes");
        Console.ReadKey();
}
static void PrestamosVencidos()
    {
        Console.Clear();
        Console.WriteLine("Listar préstamos vencidos");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú reportes");
        Console.ReadKey();
}
static void ResumenGeneral()
    {
        Console.Clear();
        Console.WriteLine("Resumen general");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú reportes");
        Console.ReadKey();
}
    

    // menu guardar y cargar datos
    static void GuardarCargarDatos()
    {
        bool volver = false;
        while (!volver)
        {
        Console.Clear();
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. vaciar todo");
        Console.WriteLine("4. Volver al menú principal");
        

        Console.WriteLine("Ingrese una opción:");
        int opcionMenuGuardarCargar = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        switch (opcionMenuGuardarCargar)
            {
                case 1:
                    GuardarDatos();
                    break;
                case 2:
                    CargarDatos();
                    break;
                case 3:
                    VaciarDatos();
                    break;
                case 4:
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
}
static void GuardarDatos()
    {
        bool volver = false;
        Console.Clear();
        Console.WriteLine("Guardar datos");
        Console.WriteLine("1. libros");
        Console.WriteLine("2. usuarios");
        Console.WriteLine("3. préstamos");

        Console.WriteLine("Ingrese una opción:");
        int opcionGuardarDatos = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        switch (opcionGuardarDatos)
            {
                case 1:
                    GuardarLibros();
                    break;
                case 2:
                    GuardarUsuarios();
                    break;
                case 3:
                    GuardarPrestamos();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
}
static void GuardarLibros()
    {
        Console.Clear();
        Console.WriteLine("Guardar libros");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú guardar/cargar datos");
        Console.ReadKey();
}
static void GuardarUsuarios()
    {
        Console.Clear();
        Console.WriteLine("Guardar usuarios");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú guardar/cargar datos");
        Console.ReadKey();
}
static void GuardarPrestamos()
    {
        Console.Clear();
        Console.WriteLine("Guardar préstamos");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú guardar/cargar datos");
        Console.ReadKey();
}
static void CargarDatos()
    {
        Console.Clear();
        Console.WriteLine("Datos cargados");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú guardar/cargar datos");
        Console.ReadKey();
}
static void VaciarDatos()
    {
        Console.Clear();
        Console.WriteLine("ADVERTENCIA: Esta acción no se puede deshacer");
        Console.WriteLine("");  
        Console.WriteLine("Ingresa CONFIRMAR para vaciar todos los datos de libros, usuarios y préstamos");
        Console.WriteLine(""); 
        Console.WriteLine("ingresa enter para cancelar");
        string confirmacion = Console.ReadLine();
        if (confirmacion == "CONFIRMAR")
        {
            Console.WriteLine("Datos vaciados");
        }
        else
        {
            Console.WriteLine("Acción cancelada");
        }
        Console.ReadKey();
    }
}
static void Salir()
    {
        Console.WriteLine("guardar antes de salir ? (S/N)");
        string respuesta = Console.ReadLine();
        if (respuesta == "S")
        {
            Console.WriteLine("Guardando datos...");
        }else if (respuesta == "N")
        {
            Console.WriteLine("Saliendo sin guardar...");
        }
        else
        {
            Console.WriteLine("Opción no válida. Saliendo sin guardar...");
        }
    }
}
