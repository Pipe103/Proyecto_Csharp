namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
/// MENU PRINCIPAL

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
                    
                    break;
                case 5:
                    
                    break;
                case 6:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
    }
    }

    //MENU DE LIBRO

    public class Libro
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public int Anio { get; set; }
    public bool Disponible { get; set; }
}


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
        Console.WriteLine("");
        Console.WriteLine("Presiona enter volver al menú libro");
        Console.ReadKey();
    }
static void ListarLibros()
    {
        Console.Clear();
        Console.WriteLine("Listar todos");
        Console.WriteLine("");
        Console.WriteLine("Listar disponibles");
        Console.WriteLine("");
        Console.WriteLine("Listar prestados");
        Console.WriteLine("");
        Console.WriteLine("Presiona enter volver al menú libro");
        Console.ReadKey();
}
static void VerDetalleLibro()
    {
        Console.Clear();
        Console.WriteLine("Ver detalle del libro por ID/ISBN");
        Console.WriteLine("");
        
        Console.WriteLine("Presiona enter volver al menú libro");
        Console.ReadKey();
}
static void ActualizarLibro()
    {
        Console.Clear();
        Console.WriteLine("Editar titulo");
        Console.WriteLine("");
        Console.WriteLine("Editar autor");
        Console.WriteLine("");
        Console.WriteLine("Editar año / categoría");
        Console.WriteLine("");

        Console.WriteLine("Presiona enter volver al menú libro");
        Console.ReadKey();
}
static void EliminarLibro()
    {
        Console.Clear();
        bool prestado = false;
        Console.WriteLine("Eliminar libro");
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
        Console.WriteLine("");
        int opcionMenuUsuario = int.Parse(Console.ReadLine());



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
        Console.WriteLine("");
        int opcionMenuPrestamos = int.Parse(Console.ReadLine());

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
}
