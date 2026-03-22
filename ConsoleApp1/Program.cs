using System;
using System.Linq;
using System.Collections.Generic;
using Libros;
using Usuarios;
using Prestamos;
namespace ConsoleApp1;

class Program
{                                                                                                                                                                                                                                                                                                                                                                   
    static List<Libro> libros = new List<Libro>();
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Prestamo> prestamos = new List<Prestamo>();
    static int contadorId = 1;
    static void Main(string[] args)
    {

usuarios.Add(new Usuario(1, "Ana", "Lopez", "111", "ana@gmail.com", "300111"));
usuarios.Add(new Usuario(2, "Luis", "Gomez", "222", "luis@gmail.com", "300222"));

libros.Add(new Libro { Id = 1, Titulo = "Libro A", Disponible = true });
libros.Add(new Libro { Id = 2, Titulo = "Libro B", Disponible = true });
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
        Console.WriteLine("=== Registrar nuevo usuario ===");
        Console.WriteLine();

        
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

        
        Usuario nuevoUsuario = new Usuario(contadorId++, nombre, apellido, documento, correo, telefono);

        
        usuarios.Add(nuevoUsuario);

        Console.WriteLine();
        Console.WriteLine("Usuario registrado correctamente:");
        Console.WriteLine(nuevoUsuario.DetalleCompleto());

        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para volver al menú usuario...");
        Console.ReadKey();
    }
    ///////////////////////////////
    /// 
    


    static void ListarUsuarios()
    {
        Console.Clear();
    Console.WriteLine("=== Listado de usuarios ===");
    Console.WriteLine();

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados.");
    }
    else
    {
        foreach (Usuario u in usuarios)
        {
            Console.WriteLine(u.DetalleCompleto());
            Console.WriteLine("---------------------------");
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presiona cualquier tecla para volver al menú usuario...");
    Console.ReadKey();

}

///////////////////////////////////////////////////


static void VerDetalleUsuario()
    {
        Console.Clear();
    Console.WriteLine("=== Ver detalle del usuario por ID/documento ===");
    Console.WriteLine();

    Console.Write("Ingrese ID o Documento: ");
    string entrada = Console.ReadLine();

    Usuario encontrado = null;

    // Primero intentamos buscar por ID (si la entrada es numérica)
    if (int.TryParse(entrada, out int idBuscado))
    {
        encontrado = usuarios.FirstOrDefault(u => u.Id == idBuscado);
    }
    else
    {
        // Si no es número, buscamos por documento
        encontrado = usuarios.FirstOrDefault(u => u.Documento == entrada);
    }

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

    Console.WriteLine();
    Console.WriteLine("Presiona cualquier tecla para volver al menú usuario...");
    Console.ReadKey();
}

////////////////////////////////////////////////



static void ActualizarUsuario()
{
    Console.Clear();
    Console.WriteLine("=== ACTUALIZAR USUARIO ===");

    Console.Write("Ingrese el ID del usuario: ");
    int id = int.Parse(Console.ReadLine());

    Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado ");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("Usuario encontrado ");
    Console.WriteLine($"Nombre actual: {usuario.Nombre}");
    Console.WriteLine($"Apellido actual: {usuario.Apellido}");
    Console.WriteLine($"Documento actual: {usuario.Documento}");
    Console.WriteLine($"Correo actual: {usuario.Correo}");
    Console.WriteLine($"Teléfono actual: {usuario.Telefono}");
    Console.WriteLine($"Estado actual: {(usuario.Activo ? "Activo" : "Inactivo")}\n");

    // EDITAR NOMBRE
    Console.Write("Nuevo nombre (ENTER para omitir): ");
    string nuevoNombre = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNombre))
    {
        usuario.Nombre = nuevoNombre;
    }

    // EDITAR APELLIDO
    Console.Write("Nuevo apellido (ENTER para omitir): ");
    string nuevoApellido = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoApellido))
    {
        usuario.Apellido = nuevoApellido;
    }

    // EDITAR DOCUMENTO
    Console.Write("Nuevo documento (ENTER para omitir): ");
    string nuevoDocumento = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoDocumento))
    {
        usuario.Documento = nuevoDocumento;
    }

    // EDITAR CORREO
    Console.Write("Nuevo correo (ENTER para omitir): ");
    string nuevoCorreo = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoCorreo))
    {
        usuario.Correo = nuevoCorreo;
    }

    // EDITAR TELÉFONO
    Console.Write("Nuevo teléfono (ENTER para omitir): ");
    string nuevoTelefono = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTelefono))
    {
        usuario.Telefono = nuevoTelefono;
    }

    // CAMBIAR ESTADO
    Console.Write("¿Desea cambiar el estado? (S/N): ");
    string cambiarEstado = Console.ReadLine();

    if (cambiarEstado.ToLower() == "s")
    {
        usuario.Activo = !usuario.Activo;
    }

    Console.WriteLine("\nUsuario actualizado correctamente ✔");
    Console.ReadKey();
}
///////////////////////////////////



static void EliminarUsuario()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR USUARIO ===\n");

    Console.Write("Ingrese el ID del usuario: ");
    int id = int.Parse(Console.ReadLine());

    Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado ");
        Console.ReadKey();
        return;
    }

    bool tienePrestamosActivos = prestamos.Any(p => p.IdUsuario == id && p.Estado == "Activo");

    if (tienePrestamosActivos)
    {
        Console.WriteLine("No se puede eliminar el usuario, tiene préstamos activos ");
        Console.ReadKey();
        return;
    }

    // 🔹 CONFIRMACIÓN
    Console.Write($"¿Seguro que desea eliminar a {usuario.Nombre}? (S/N): ");
    string confirmacion = Console.ReadLine();

    if (confirmacion.ToLower() == "s")
    {
        usuarios.Remove(usuario);
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

    // 🔹 VALIDAR USUARIO
    Console.Write("Ingrese ID del usuario: ");
    int idUsuario = int.Parse(Console.ReadLine());

    Usuario usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);

    if (usuario == null || !usuario.Activo)
    {
        Console.WriteLine("\nUsuario no existe o está inactivo ");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\nUsuario válido ");

    Console.Write("Ingrese ID del libro: ");
    int idLibro = int.Parse(Console.ReadLine());

    Libro libro = libros.FirstOrDefault(l => l.Id == idLibro);

    if (libro == null || !libro.Disponible)
    {
        Console.WriteLine("\nLibro no disponible ");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\nLibro disponible ");

    Prestamo nuevo = new Prestamo();
    nuevo.IdPrestamo = prestamos.Count + 1;
    nuevo.IdUsuario = idUsuario;
    nuevo.IdLibro = idLibro;
    nuevo.FechaPrestamo = DateTime.Now;
    nuevo.FechaLimite = DateTime.Now.AddDays(7);

    prestamos.Add(nuevo);

    libro.Disponible = false;

    Console.WriteLine("\nPréstamo creado correctamente ");
    Console.WriteLine(nuevo.ResumenCorto());

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

    Prestamo prestamo = prestamos.FirstOrDefault(p => p.IdPrestamo == id);

    if (prestamo == null)
    {
        Console.WriteLine("\nPréstamo no encontrado ");
        Console.ReadKey();
        return;
    }

    if (prestamo.Estado == "Activo")
    {
        Libro libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);

        if (libro != null)
        {
            libro.Disponible = true;
        }

        Console.WriteLine("\nEl préstamo estaba activo → libro liberado ");
    }

    Console.Write("\n¿Seguro que desea eliminar el préstamo? (S/N): ");
    string confirmacion = Console.ReadLine();

    if (confirmacion.ToLower() == "s")
    {
        prestamos.Remove(prestamo);
        Console.WriteLine("\nPréstamo eliminado correctamente ");
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
