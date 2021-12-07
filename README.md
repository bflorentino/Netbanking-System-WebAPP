# Netbanking-System-WebAPP

Proyecto final para la materia de programación 2 con el profesor Juan Rosario.

### Datos Generales sobre el proyecto

Es una aplicación web de netbanking construida en .Net utilizando a C# como lenguaje de programacion y Asp.Net Core como entorno web. La aplicación está construida en una arquitectura basada en capas, entre las que están:

- La capa de Presentacion
- La capa de negocios
- La capa de acceso a datos

En la capa de presentación, de una manera híbrida, se utilizó el patrón de arquitectura MVC, en la que la capa de negocios y la capa de acceso a datos sirvieron como los modelos para las distintas vistas a través de DTOs y View Models.

Para el desarrollo del backend de la aplicación se utilizarón las siguientes tecnologías:

- C#
- SQL Server como gestor de base de datos.
- Entity Framework Core como ORM.
- LinQ para manejar consultas.

### Sobre la base de datos

La base de datos, desarrollada en SQL Server, consta de un total de 13 tablas, las cuales almacenan los datos referentes a los procesos en la aplicación. En el archivo
