# Mastering MVC con .NET 8 & Northwind

Este repositorio contiene un proyecto educativo completamente funcional diseñado para enseñar y aplicar los conceptos fundamentales del patrón de diseño **Model-View-Controller (MVC)** utilizando **.NET 8** y la clásica base de datos empresarial **Northwind**.

El objetivo principal de esta solución es servir como guía práctica para entender cómo estructurar aplicaciones web monolíticas modernas, interactuar con bases de datos relacionales mediante ORMs y renderizar vistas dinámicas de forma eficiente.

---

## 🚀 Stack Tecnológico

* **Framework Principal:** .NET 8 (ASP.NET Core MVC)
* **Acceso a Datos (ORM):** Entity Framework Core 8
* **Base de Datos:** Microsoft SQL Server / Azure SQL (Northwind)
* **Diseño de Interfaz:** Razor Views, HTML5, CSS3, Bootstrap 5 y FontAwesome

---

## 🏗️ Estructura del Proyecto e Implementación MVC

El proyecto sigue la separación de responsabilidades del patrón arquitectónico MVC:

### 1. Modelos (`/Models`)
Contiene las clases POCO que mapean las tablas de la base de datos Northwind, así como los `ViewModels` empleados para estructurar y transferir datos hacia la interfaz de usuario.
* **Validaciones:** Uso de `Data Annotations` (`[Required]`, `[StringLength]`) para asegurar la integridad de la información.

### 2. Vistas (`/Views`)
Construidas mediante el motor **Razor**, combinando HTML estructurado con código C# dinámico.
* **Tag Helpers:** Uso de `asp-controller`, `asp-action` y `asp-for` para enlazar formularios y rutas.
* **Layouts:** Implementación de un contenedor maestro (`_Layout.cshtml`) y vistas parciales reutilizables.

### 3. Controladores (`/Controllers`)
Los intermediarios encargados de interceptar las peticiones HTTP, procesar la lógica de negocio y comunicarse con Entity Framework.
* **Inyección de Dependencias:** El `NorthwindContext` se inyecta nativamente a través del constructor.
* **Flujos Seguros:** Separación entre métodos `[HttpGet]` y `[HttpPost]`, evaluando siempre `ModelState.IsValid`.

---

## 📊 Base de Datos: El Modelo Northwind

Northwind Traders simula la operación de una compañía de importación y exportación. El proyecto interactúa con las siguientes entidades:

| Entidad | Descripción | Relación Principal |
| :--- | :--- | :--- |
| **Customer** | Registro de clientes. | Un cliente puede registrar múltiples `Orders`. |
| **Product** | Catálogo de productos. | Pertenece a una `Category` y a un `Supplier`. |
| **Category** | Clasificación del catálogo. | Agrupa una colección de productos. |
| **Order** | Cabecera del pedido. | Se asocia a un cliente único y a un empleado. |
| **Order Detail** | Desglose de artículos. | Relación muchos a muchos entre `Orders` y `Products`. |

---

## ⚙️ Configuración e Instalación

Para clonar y ejecutar este proyecto localmente, necesitas el **.NET 8 SDK** y una instancia de **SQL Server** con Northwind.

### Paso 1: Clonar el Repositorio

```bash
git clone [https://github.com/TU_USUARIO/TU_REPOSITORIO.git](https://github.com/TU_USUARIO/TU_REPOSITORIO.git)
cd TU_REPOSITORIO
```

### Paso 2: Configurar la Cadena de Conexión

Modifica el archivo `appsettings.json` en la raíz del proyecto para adaptar las credenciales a tu entorno local:

```json
{
  "ConnectionStrings": {
    "NorthwindConnection": "Server=TU_SERVIDOR_SQL;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Paso 3: Restaurar y Ejecutar

Abre una terminal en el directorio del proyecto y ejecuta la CLI de .NET:

```bash
# Restaurar paquetes NuGet
dotnet restore

# Compilar y levantar el servidor web con recarga en vivo
dotnet watch run
```

---

## 📝 Licencia

Este proyecto está distribuido bajo la licencia MIT. Es de uso libre con fines educativos o como plantilla base.
