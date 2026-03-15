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
        }
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
}
