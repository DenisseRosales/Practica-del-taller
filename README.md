Gestor de Tareas - ASP.NET Core MVC  
Aplicación web para organizar tareas personales, construida con ASP.NET Core 8.0 siguiendo el patrón MVC.  

Funcionalidades principales  
- Autenticación de usuarios: Registro e inicio de sesión seguro con Identity  
- CRUD completo: Crear, consultar, editar y eliminar tareas  
- Listas individuales: Cada usuario gestiona su propia colección de tareas  
- Sistema de prioridades: Clasificación en Alta, Media y Baja  
- Filtros dinámicos: Visualiza tareas según su prioridad  
- Estado de finalización: Marca tareas como completadas fácilmente  
- Diseño moderno y responsivo: Interfaz adaptable con colores según prioridad  

Tecnologías empleadas  
- ASP.NET Core 8.0  
- Entity Framework Core  
- SQL Server / SQLite  
- Bootstrap 5  
- Identity para autenticación  

Pasos para ejecutar el proyecto  
1. Clonar el repositorio 
   ```bash
   git clone https://github.com/tuusuario/ListaTareasApp.git
   cd ListaTareasApp
   ```  

2. Configurar la base de datos
   - Ajusta la cadena de conexión en `appsettings.json` si es necesario  
   - Aplica las migraciones:  
     ```bash
     dotnet ef database update
     ```  

3. Iniciar la aplicación
   ```bash
   dotnet run
   ```  
   Disponible en: [https://localhost:7275]  
