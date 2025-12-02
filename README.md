# Lista de Tareas - ASP.NET Core MVC

Aplicación web para gestión de tareas personales desarrollada con ASP.NET Core y patrón MVC.

## Características principales

- **Autenticación de usuarios**: Sistema de registro e inicio de sesión
- **Gestión CRUD**: Crear, leer, actualizar y eliminar tareas
- **Listas personalizadas**: Cada usuario tiene su propia lista de tareas
- **Prioridades**: Organiza tareas por prioridad (Alta, Media, Baja)
- **Filtrado**: Filtra tareas por prioridad
- **Marcado de completadas**: Marca tareas como completadas
- **Interfaz moderna**: Diseño responsivo con colores por prioridad

## Tecnologías utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server / SQLite
- Bootstrap 5
- Identity para autenticación

## Instrucciones para ejecutar el proyecto

### 1. Clonar el repositorio
```bash
git clone https://github.com/tuusuario/ListaTareasApp.git
cd ListaTareasApp
```

### 2. Configurar la base de datos

Actualiza la cadena de conexión en `appsettings.json` si es necesario.

Ejecuta las migraciones:
```bash
dotnet ef database update
```

### 3. Ejecutar la aplicación
```bash
dotnet run
```

La aplicación estará disponible en: `https://localhost:7275`

## Estructura del proyecto
```
ListaTareasApp/
├── Controllers/         # Controladores MVC
├── Models/             # Modelos de datos
├── Views/              # Vistas Razor
├── Data/               # Contexto de base de datos
├── wwwroot/            # Archivos estáticos (CSS, JS)
└── README.md           # Documentación
```

## Autor

**Jorge Eduardo García Hernández**

Proyecto desarrollado como parte del taller "Uso de ASP.NET Core"

## Licencia

Este proyecto se distribuye bajo la licencia MIT.