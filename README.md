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
