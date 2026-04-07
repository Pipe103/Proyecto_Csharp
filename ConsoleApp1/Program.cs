using System.Text.Json;
using System.IO;using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1;

class Program
{                 
static List<Libro> libros = new List<Libro>();   

static List<Usuario> usuarios = new List<Usuario>();
static List<Prestamo> prestamos = new List<Prestamo>();
static int contadorUsuarioId = 1;

static PrestamoService prestamoService = new PrestamoService(prestamos, usuarios, libros);
static UsuarioService usuarioService = new UsuarioService(usuarios, prestamos);

static LibroService libroService = new LibroService(libros);
static int contadorId = 1;
    static void Main(string[] args)
    {

usuarios.Add(new Usuario(0, "Ana", "Lopez", "111", "ana@gmail.com", "300111"));
usuarios.Add(new Usuario(0, "Luis", "Gomez", "222", "luis@gmail.com", "300222"));

libroService.AgregarLibro(new Libro { Id = 1, Titulo = "Libro A", Disponible = true });

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

    if (estado == "s")
    {
        nuevo.Disponible = true;
    }
    else
    {
        nuevo.Disponible = false;
    }

    libroService.AgregarLibro(nuevo);

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
    Console.WriteLine("Todos los libros\n");

    // Obtenemos todos los libros desde el servicio
    var lista = libroService.ObtenerTodos();

    if (lista.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (var libro in lista)
        {
            Console.WriteLine($"ID: {libro.Id} | ISBN: {libro.ISBN} | Título: {libro.Titulo} | Autor: {libro.Autor} | Categoría: {libro.Categoria} | Año: {libro.Anio} | Disponible: {(libro.Disponible ? "Sí" : "No")}");
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

    // Obtenemos todos los libros y filtramos los que están disponibles
    var lista = libroService.ObtenerTodos()
        .Where(l => l.Disponible)
        .ToList();

    if (lista.Count == 0)
    {
        Console.WriteLine("No hay libros disponibles.");
    }
    else
    {
        foreach (var libro in lista)
        {
            Console.WriteLine($"ID: {libro.Id} | ISBN: {libro.ISBN} | Título: {libro.Titulo} | Autor: {libro.Autor} | Categoría: {libro.Categoria} | Año: {libro.Anio} | Disponible: {(libro.Disponible ? "Sí" : "No")}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ListarPrestados()
{
    Console.Clear();
    Console.WriteLine("Libros prestados:\n");

    var prestados = libroService.ObtenerTodos()
        .Where(l => !l.Disponible)
        .ToList();

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
        encontrado = libroService.BuscarPorId(idBuscado);
    }
    else
    {
        encontrado = libroService.BuscarPorISBN(entrada);
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
    Console.WriteLine("Actualizar libro\n");

    Console.Write("Ingrese el ID o ISBN del libro a actualizar: ");
    string entrada = Console.ReadLine();

    int idBuscado;
    Libro encontrado = null;

    if (int.TryParse(entrada, out idBuscado))
    {
        encontrado = libroService.BuscarPorId(idBuscado);
    }
    else
    {
        encontrado = libroService.BuscarPorISBN(entrada);
    }

    if (encontrado == null)
    {
        Console.WriteLine("No se encontró ningún libro con ese ID/ISBN.");
    }
    else
    {
        Console.WriteLine("\nLibro encontrado:");
        Console.WriteLine($"ID: {encontrado.Id} | ISBN: {encontrado.ISBN} | Título: {encontrado.Titulo}");

        Console.WriteLine("\nIngrese los nuevos valores (deje vacío si no desea cambiar):");

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

        Console.WriteLine("\nLibro actualizado correctamente.");
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
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
        encontrado = libroService.BuscarPorId(idBuscado);
    }
    else
    {
        encontrado = libroService.BuscarPorISBN(entrada);
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
            libroService.EliminarLibro(encontrado.Id);

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
    }
    static void RegistrarUsuario()
{
    Console.Clear();
    Console.WriteLine("=== Registrar nuevo usuario ===\n");

    Console.Write("Ingrese nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Ingrese apellido: ");
    string apellido = Console.ReadLine();

    Console.Write("Ingrese documento: ");
    string documento = Console.ReadLine();

    Console.Write("Ingrese correo: ");
    string correo = Console.ReadLine();

    Console.Write("Ingrese teléfono: ");
    string telefono = Console.ReadLine();

    Usuario nuevoUsuario = new Usuario
    {
        Id = contadorUsuarioId++,
        Nombre = nombre,
        Apellido = apellido,
        Documento = documento,
        Correo = correo,
        Telefono = telefono
    };

    usuarioService.RegistrarUsuario(nuevoUsuario);

    Console.WriteLine("\nUsuario registrado correctamente:");
    Console.WriteLine(nuevoUsuario.DetalleCompleto());

    Console.WriteLine("\nPresiona cualquier tecla para volver al menú usuario...");
    Console.ReadKey();
}
    ///////////////////////////////
    /// 
    


static void ListarUsuarios()
{
    Console.Clear();
    Console.WriteLine("=== LISTADO DE USUARIOS ===\n");

    var lista = usuarioService.ObtenerTodos();

    if (lista.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados.");
    }
    else
    {
        foreach (var u in lista)
        {
            Console.WriteLine(u.DetalleCompleto());
            Console.WriteLine("---------------------------");
        }
    }

    Console.WriteLine("\nPresiona cualquier tecla para volver al menú usuario...");
    Console.ReadKey();
}

///////////////////////////////////////////////////


static void VerDetalleUsuario()
{
    Console.Clear();
    Console.WriteLine("=== Ver detalle del usuario por ID/documento ===\n");

    Console.Write("Ingrese ID o Documento: ");
    string entrada = Console.ReadLine();

    var encontrado = usuarioService.BuscarPorIdODocumento(entrada);

    Console.WriteLine();

    if (encontrado != null)
    {
        Console.WriteLine("Usuario encontrado:");
        Console.WriteLine(encontrado.DetalleCompleto());
    }
    else
    {
        Console.WriteLine("No se encontró ningún usuario con ese ID o documento.");
    }

    Console.WriteLine("\nPresiona cualquier tecla para volver al menú usuario...");
    Console.ReadKey();
}

////////////////////////////////////////////////



static void ActualizarUsuario()
{
    Console.Clear();
    Console.WriteLine("=== ACTUALIZAR USUARIO ===");

    Console.Write("Ingrese el ID del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido.");
        Console.ReadKey();
        return;
    }

    var usuario = usuarioService.BuscarPorIdODocumento(id.ToString());

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.Write("Nuevo nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Nuevo apellido: ");
    string apellido = Console.ReadLine();

    Console.Write("Nuevo documento: ");
    string documento = Console.ReadLine();

    Console.Write("Nuevo correo: ");
    string correo = Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    string telefono = Console.ReadLine();

    Usuario actualizado = new Usuario
    {
        Id = usuario.Id,
        Nombre = string.IsNullOrWhiteSpace(nombre) ? usuario.Nombre : nombre,
        Apellido = string.IsNullOrWhiteSpace(apellido) ? usuario.Apellido : apellido,
        Documento = string.IsNullOrWhiteSpace(documento) ? usuario.Documento : documento,
        Correo = string.IsNullOrWhiteSpace(correo) ? usuario.Correo : correo,
        Telefono = string.IsNullOrWhiteSpace(telefono) ? usuario.Telefono : telefono
    };

    usuarioService.ActualizarUsuario(id, actualizado);

    Console.WriteLine("\nUsuario actualizado correctamente ✔");
    Console.ReadKey();
}
///////////////////////////////////



static void EliminarUsuario()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR USUARIO ===\n");

    Console.Write("Ingrese el ID del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido.");
        Console.ReadKey();
        return;
    }

    Usuario usuario = usuarioService.BuscarPorIdODocumento(id.ToString());
    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado.");
        Console.ReadKey();
        return;
    }

    bool puedeEliminar = usuarioService.PuedeEliminar(usuario.Id);
    if (!puedeEliminar)
    {
        Console.WriteLine("No se puede eliminar el usuario, tiene préstamos activos.");
        Console.ReadKey();
        return;
    }

    Console.Write($"¿Seguro que desea eliminar a {usuario.Nombre}? (S/N): ");
    string confirmacion = Console.ReadLine();

    if (confirmacion.ToLower() == "s")
    {
        usuarioService.EliminarUsuario(usuario.Id);
        Console.WriteLine("Usuario eliminado correctamente ✔");
    }
    else
    {
        Console.WriteLine("Operación cancelada");
    }

    Console.ReadKey();
}


// menu prestamos

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
    Console.WriteLine("=== CREAR PRÉSTAMO ===\n");

    Console.Write("Ingrese ID del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int idUsuario))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    Usuario usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);

    if (usuario == null || !usuario.Activo)
    {
        Console.WriteLine("\nUsuario no existe o está inactivo");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\nUsuario válido");

    Console.Write("Ingrese ISBN del libro: ");
    string isbn = Console.ReadLine();

    Libro libro = libros.FirstOrDefault(l => l.ISBN == isbn);

    if (libro == null || !libro.Disponible)
    {
        Console.WriteLine("\nLibro no disponible");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\nLibro disponible");

    string resultado = prestamoService.CrearPrestamo(idUsuario, libro.Id);

    Console.WriteLine("\n" + resultado);

    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
}

    static void ListarPrestamos()
{
    bool volver = false;

    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR PRÉSTAMOS ===");

        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Devueltos");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                MostrarTodos();
                break;

            case "2":
                MostrarActivos();
                break;

            case "3":
                MostrarDevueltos();
                break;

            case "4":
                volver = true;
                break;

            default:
                Console.WriteLine("Opción no válida ");
                Console.ReadKey();
                break;
        }
    }
}
static void MostrarTodos()
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS PRÉSTAMOS ===");

    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos");
    }
    else
    {
        foreach (var p in prestamos)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Console.ReadKey();
}
static void MostrarActivos()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS ACTIVOS ===");

    var activos = prestamos.Where(p => p.Estado == "Activo").ToList();

    if (activos.Count == 0)
    {
        Console.WriteLine("No hay préstamos activos");
    }
    else
    {
        foreach (var p in activos)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Console.ReadKey();
}
static void MostrarDevueltos()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS DEVUELTOS ===");

    var devueltos = prestamos.Where(p => p.Estado == "Devuelto").ToList();

    if (devueltos.Count == 0)
    {
        Console.WriteLine("No hay préstamos devueltos");
    }
    else
    {
        foreach (var p in devueltos)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Console.ReadKey();
}
static void VerDetallePrestamo()
{
    Console.Clear();
    Console.WriteLine("=== VER DETALLE DEL PRÉSTAMO ===");

    Console.Write("Ingrese ID del préstamo: ");
    int id = int.Parse(Console.ReadLine());

    Prestamo prestamo = prestamos.FirstOrDefault(p => p.IdPrestamo == id);

    if (prestamo == null)
    {
        Console.WriteLine("\nNo se encontró el préstamo ");
    }
    else
    {
        Console.WriteLine("\nDetalle del préstamo:\n");
        Console.WriteLine(prestamo.DetalleCompleto());
    }

    Console.WriteLine("Presiona una tecla para volver...");
    Console.ReadKey();
}
static void RegistrarDevolucion()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR DEVOLUCIÓN ===");

    Console.Write("Ingrese ID del préstamo: ");
    int id = int.Parse(Console.ReadLine());

    Prestamo prestamo = prestamos.FirstOrDefault(p => p.IdPrestamo == id);

    if (prestamo == null)
    {
        Console.WriteLine("\nPréstamo no encontrado ");
        Console.ReadKey();
        return;
    }

    if (prestamo.Estado == "Devuelto")
    {
        Console.WriteLine("\nEste préstamo ya fue devuelto ");
        Console.ReadKey();
        return;
    }

    prestamo.Estado = "Devuelto";
    prestamo.FechaDevolucion = DateTime.Now;

    Libro libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);

    if (libro != null)
    {
        libro.Disponible = true;
    }

    Console.WriteLine("\nDevolución registrada correctamente ");
    Console.ReadKey();
}
static void EliminarPrestamo()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR PRÉSTAMO ===\n");

    Console.WriteLine("⚠ ADVERTENCIA: Esta acción no se puede deshacer\n");

    Console.Write("Ingrese ID del préstamo: ");
    int id = int.Parse(Console.ReadLine());

    var prestamo = prestamoService.BuscarPorId(id);

    if (prestamo == null)
    {
        Console.WriteLine("\nPréstamo no encontrado");
        Console.ReadKey();
        return;
    }

    Console.Write("\n¿Seguro que desea eliminar el préstamo? (S/N): ");
    string confirmacion = Console.ReadLine();

    if (confirmacion?.ToLower() == "s")
    {
        string resultado = prestamoService.EliminarPrestamo(id);
        Console.WriteLine("\n" + resultado);
    }
    else
    {
        Console.WriteLine("\nOperación cancelada");
    }

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
    Console.WriteLine("=== BUSCAR LIBRO POR TÍTULO ===\n");

    Console.Write("Ingrese el título: ");
    string titulo = Console.ReadLine().ToLower();

    var resultados = libros
        .Where(l => l.Titulo.ToLower().Contains(titulo))
        .ToList();

    Console.WriteLine();

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron libros ");
    }
    else
    {
        Console.WriteLine("Resultados:\n");

        foreach (var libro in resultados)
        {
            Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Autor: {libro.Autor}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
    static void BuscarRepotePorAutor()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR LIBRO POR AUTOR ===\n");

    Console.Write("Ingrese el nombre del autor: ");
    string autor = Console.ReadLine().ToLower();

    var resultados = libros
        .Where(l => l.Autor.ToLower().Contains(autor))
        .ToList();

    Console.WriteLine();

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron libros ");
    }
    else
    {
        Console.WriteLine("Resultados:\n");

        foreach (var libro in resultados)
        {
            Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Autor: {libro.Autor}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
    static void BuscarRepotePorID()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR LIBRO POR ID / ISBN ===\n");

    Console.Write("Ingrese ID o ISBN: ");
    string entrada = Console.ReadLine();

    Libro encontrado = null;

    if (int.TryParse(entrada, out int id))
    {
        encontrado = libros.FirstOrDefault(l => l.Id == id);
    }
    else
    {
        encontrado = libros.FirstOrDefault(l => l.ISBN == entrada);
    }

    Console.WriteLine();

    if (encontrado == null)
    {
        Console.WriteLine("No se encontró el libro ");
    }
    else
    {
        Console.WriteLine("Libro encontrado:\n");
        Console.WriteLine($"ID: {encontrado.Id}");
        Console.WriteLine($"ISBN: {encontrado.ISBN}");
        Console.WriteLine($"Título: {encontrado.Titulo}");
        Console.WriteLine($"Autor: {encontrado.Autor}");
        Console.WriteLine($"Categoría: {encontrado.Categoria}");
        Console.WriteLine($"Año: {encontrado.Anio}");
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
    static void BuscarRepotePorCategoria()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR LIBRO POR CATEGORÍA ===\n");

    Console.Write("Ingrese la categoría: ");
    string categoria = Console.ReadLine().ToLower();

    var resultados = libros
        .Where(l => l.Categoria.ToLower().Contains(categoria))
        .ToList();

    Console.WriteLine();

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron libros ");
    }
    else
    {
        Console.WriteLine("Resultados:\n");

        foreach (var libro in resultados)
        {
            Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Categoría: {libro.Categoria}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
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
    Console.WriteLine("=== BUSCAR USUARIO POR NOMBRE ===\n");

    Console.Write("Ingrese el nombre: ");
    string nombre = Console.ReadLine().ToLower();

    var resultados = usuarios
        .Where(u => u.Nombre.ToLower().Contains(nombre))
        .ToList();

    Console.WriteLine();

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron usuarios ");
    }
    else
    {
        Console.WriteLine("Resultados:\n");

        foreach (var u in resultados)
        {
            Console.WriteLine($"ID: {u.Id} | Nombre: {u.Nombre} {u.Apellido} | Documento: {u.Documento}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
    static void BuscarUsuarioPorID()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR USUARIO POR ID / DOCUMENTO ===\n");

    Console.Write("Ingrese ID o documento: ");
    string entrada = Console.ReadLine();

    Usuario encontrado = null;

    if (int.TryParse(entrada, out int id))
    {
        encontrado = usuarios.FirstOrDefault(u => u.Id == id);
    }
    else
    {
        encontrado = usuarios.FirstOrDefault(u => u.Documento == entrada);
    }

    Console.WriteLine();

    if (encontrado == null)
    {
        Console.WriteLine("Usuario no encontrado ");
    }
    else
    {
        Console.WriteLine("Usuario encontrado:\n");
        Console.WriteLine(encontrado.DetalleCompleto());
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
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
    Console.WriteLine("=== PRÉSTAMOS POR USUARIO ===\n");

    Console.Write("Ingrese ID del usuario: ");
    int id = int.Parse(Console.ReadLine());

    Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("\nUsuario no encontrado ");
        Console.ReadKey();
        return;
    }

    var lista = prestamos
        .Where(p => p.IdUsuario == id)
        .ToList();

    Console.WriteLine($"\nPréstamos de {usuario.Nombre}:\n");

    if (lista.Count == 0)
    {
        Console.WriteLine("No tiene préstamos");
    }
    else
    {
        foreach (var p in lista)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
static void PrestamosPorLibro()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS POR LIBRO ===\n");

    Console.Write("Ingrese ID del libro: ");
    int id = int.Parse(Console.ReadLine());

    Libro libro = libros.FirstOrDefault(l => l.Id == id);

    if (libro == null)
    {
        Console.WriteLine("\nLibro no encontrado ");
        Console.ReadKey();
        return;
    }

    var lista = prestamos
        .Where(p => p.IdLibro == id)
        .ToList();

    Console.WriteLine($"\nPréstamos del libro: {libro.Titulo}\n");

    if (lista.Count == 0)
    {
        Console.WriteLine("Este libro no tiene préstamos");
    }
    else
    {
        foreach (var p in lista)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
static void PrestamosVencidos()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS VENCIDOS ===\n");

    var vencidos = prestamos
        .Where(p => p.Estado == "Activo" && DateTime.Now > p.FechaLimite)
        .ToList();

    if (vencidos.Count == 0)
    {
        Console.WriteLine("No hay préstamos vencidos ✔");
    }
    else
    {
        Console.WriteLine("Préstamos vencidos:\n");

        foreach (var p in vencidos)
        {
            Console.WriteLine($"ID: {p.IdPrestamo} | Usuario: {p.IdUsuario} | Libro: {p.IdLibro} | Fecha límite: {p.FechaLimite.ToShortDateString()}");
        }
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
static void ResumenGeneral()
{
    Console.Clear();
    Console.WriteLine("=== RESUMEN GENERAL ===\n");

    int totalLibros = libros.Count;
    int disponibles = libros.Count(l => l.Disponible);
    int prestados = totalLibros - disponibles;

    int totalUsuarios = usuarios.Count;
    int activos = usuarios.Count(u => u.Activo);
    int inactivos = totalUsuarios - activos;

    int totalPrestamos = prestamos.Count;
    int activosPrestamos = prestamos.Count(p => p.Estado == "Activo");
    int devueltos = prestamos.Count(p => p.Estado == "Devuelto");
    int vencidos = prestamos.Count(p => p.Estado == "Activo" && DateTime.Now > p.FechaLimite);

    Console.WriteLine(" LIBROS");
    Console.WriteLine($"Total: {totalLibros}");
    Console.WriteLine($"Disponibles: {disponibles}");
    Console.WriteLine($"Prestados: {prestados}\n");

    Console.WriteLine("USUARIOS");
    Console.WriteLine($"Total: {totalUsuarios}");
    Console.WriteLine($"Activos: {activos}");
    Console.WriteLine($"Inactivos: {inactivos}\n");

    Console.WriteLine("PRÉSTAMOS");
    Console.WriteLine($"Total: {totalPrestamos}");
    Console.WriteLine($"Activos: {activosPrestamos}");
    Console.WriteLine($"Devueltos: {devueltos}");
    Console.WriteLine($"Vencidos: {vencidos}");

    Console.WriteLine("\nPresiona una tecla para volver...");
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
    Console.WriteLine("=== GUARDAR LIBROS ===\n");

    try
    {
        string json = JsonSerializer.Serialize(libros, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("libros.json", json);

        Console.WriteLine("Libros guardados correctamente ");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al guardar ");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
static void GuardarUsuarios()
{
    Console.Clear();
    Console.WriteLine("=== GUARDAR USUARIOS ===\n");

    try
    {
        string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("usuarios.json", json);

        Console.WriteLine("Usuarios guardados correctamente ");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al guardar ");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
    Console.ReadKey();
}
static void GuardarPrestamos()
{
    Console.Clear();
    Console.WriteLine("=== GUARDAR PRÉSTAMOS ===\n");

    try
    {
        string json = JsonSerializer.Serialize(prestamos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("prestamos.json", json);

        Console.WriteLine("Préstamos guardados correctamente ");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al guardar ");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("\nPresiona una tecla para volver...");
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
    Console.WriteLine("⚠ ADVERTENCIA: Esta acción no se puede deshacer\n");
    Console.WriteLine("Ingresa CONFIRMAR para vaciar todos los datos");
    Console.WriteLine("Presiona ENTER para cancelar\n");

    string confirmacion = Console.ReadLine();

    if (confirmacion == "CONFIRMAR")
    {
        libros.Clear();
        usuarios.Clear();
        prestamos.Clear();

        if (File.Exists("libros.json"))
            File.Delete("libros.json");

        if (File.Exists("usuarios.json"))
            File.Delete("usuarios.json");

        if (File.Exists("prestamos.json"))
            File.Delete("prestamos.json");

        Console.WriteLine("\nTodos los datos fueron eliminados correctamente ✔");
    }
    else
    {
        Console.WriteLine("\nAcción cancelada");
    }

    Console.ReadKey();
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
