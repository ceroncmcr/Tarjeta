# Tarjetas

Este proyecto permite gestionar transacciones de compra y pago mediante una tarjeta. Consta de un backend desarrollado en .NET 6 utilizando los patrones de diseño CQRS, Mediator y Result, y un frontend creado con Next.js y React.

## Instalación de la Base de Datos

1. Crea una base de datos llamada `CardDb`.
2. Ejecuta el archivo `script.sql` en la base de datos para configurar las tablas y datos iniciales.

## Ejecución del Proyecto de Forma Local

### Clonar el Repositorio

Primero, clona el repositorio en tu máquina local:
      
```bash
git clone https://github.com/ceroncmcr/Tarjeta.git
```

Luego, navega al directorio del proyecto:

```bash
cd Tarjeta
```

## Configuración del Proyecto

Antes de ejecutar el proyecto, es necesario modificar la cadena de conexión en el archivo `appsettings.json` del backend para utilizar tu usuario y contraseña de la base de datos.

1. Navega al archivo `appsettings.json` ubicado en `CardService/src/Web.Api/`.
2. Abre el archivo y localiza la sección `ConnectionStrings`.
3. Modifica la propiedad `SqlServerConnection` para incluir tu usuario y contraseña:

```json
"ConnectionStrings": {
  "SqlServerConnection": "Data Source=your_server;Initial Catalog=CardDb;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
}
```

Reemplaza `your_server`, `your_user`, y `your_password` con los valores correspondientes.

### Ejecutar el Backend

Para ejecutar la API, asegúrate de tener .NET 6 instalado.

1. Navega al directorio del proyecto del backend:

```bash
cd CardService/src/Web.Api
```

2. Inicia el servidor:

```bash
dotnet run
```

### Ejecutar el Frontend

1. Navega al directorio del frontend:

```bash
cd CardFront
```

2. Instala las dependencias necesarias:

```bash
npm install
```

3. Inicia la aplicación localmente:

```bash
npm run dev
```

Con esto, deberías tener tanto el backend como el frontend corriendo localmente y listos para gestionar transacciones de tarjetas.
