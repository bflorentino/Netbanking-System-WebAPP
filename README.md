# Netbanking-System-WebAPP

Proyecto final para la materia de programación 2 con el profesor Juan Rosario.

## Si quieres probar la App:

Luego de crear la base de datos en SQL Server, debes de ingresar el siguiente comando en el Package Manager Console, posicionándote en el proyecto Data:

Scaffold-DbContext "Server= tu servidor;Initial Catalog=NetBanking_Sys_WebApp;Trusted_Connection=True; Microsoft.EntityFrameworkCore.SqlServer -force

*Nota:* En caso de que utilices una contraseña y un usuario en SQL Server, debes de agregarlos, modificando la parte de Trusted_Connection.

Este enofoque de trabajo es el enfoque llamado Database First Aproach, en el que primero tenemos la base de datos y a partir de ella creamos nuestro modelo de datos con Entity Framework.

## Datos Generales sobre el proyecto

Esta es una aplicación web de netbanking, en la cual el objetivo es emular las actividades de un banco a través de un sistema web. En la misma, se ofrecen 3 productos: cuentas de ahorro, tarjetas de crédito y préstamos. La aplicación fue construida con 2 módulos: uno para administradores y otro para clientes del banco.

Para manejar el acceso a módulos se aplicaron roles en la base de datos, para facilitar el acceso a los mismos.


### Módulo de administradores

Los administradores son quienes pueden realizar el manejo de los datos de la aplicación, realizando operaciones como insertar, leer y actualizar datos. Las operaciones que pueden realizar los administradores son las siguientes.

- Crear clientes, préstamos, tarjetas de crédito y cuentas de ahorro.
- Leer información de los clientes, préstamos, tarjeta de créidto y cuentas de ahorro.
- Actualizar la información de los productos ya mencionados anteriormente.

Para entrar al módulo de administradores, se debe entrar a tráves del login. Con las credenciales ingresadas, el sistema reconoce si es admin y le permite el acceso a dicho módulo.


### Módulo de clientes

Los clientes, podrán realizar operaciones diversas con los productos que tengan asociados a ellos. Estos 3 productos que pueden tener son: cuentas de ahorro, préstamos y tarjetas de crédito.

Con estos 3 productos los clientes del netbanking pueden hacer diversas transacciones entre las que se encuentran:

- El pago de cuotas de préstamos.
- Realizar transferencias bancarias de una cuenta a otra.
- La realización de retiros (pagar una tarjeta de crédito, en el cual el dinero proviene del balance disponible en las diferentes cuentas de ahorro que tenga un cliente).
- La realización de dépositos (A través de esta transacción se pasa dinero de una tarjeta de crédito a una cuenta de ahorro).

También los clientes pueden realizar consultas de las siguientes informaciones:

- Consultar su balance en sus cuentas de ahorro.
- Consultar su historial de depósitos a sus distintas cuentas.
- Consultar sus historiales de retiros.
- Consultar sus historiales de pagos a préstamos.
- Consultar sus balance consumido y disponible en sus tarjetas de créditos.
- Consultas sus historiales de pagos a las tarjetas de crédito.

El acceso al módulo de clientes está dado desde el login. Al ingresar las credenciales, el sistema reconoce si es un cliente y le permite el acceso al módulo de clientes.


### Login y Registro de usuario

La aplicación también cuenta con un login y un registro de usuario. A través del login los usuarios introducen sus credenciales y de acuerdo a su rol en el sistema tendrán acceso a las diferentes operaciones. 

El registro de usuario, permite a los usuarios registrarse en el sistema. Solo se puede registrar como cliente, ya que para crear un admin, se debe hacer el registro de la creación del usuario admin desde el gestor de la base de datos. Solo se pueden registrar como usuarios aquellos que previamente hayan sido registrados como clientes por algún admin.


## Tecnologías usadas para construir la aplicación

La aplicación fue construida en .Net utilizando a C# como lenguaje de programacion y Asp.Net Core como entorno web. La aplicación está construida en una arquitectura basada en capas, entre las que están:

- La capa de Presentacion
- La capa de negocios
- La capa de acceso a datos

En la capa de presentación, de una manera híbrida, se utilizó el patrón de arquitectura MVC, en la que la capa de negocios y la capa de acceso a datos sirvieron como los modelos para las distintas vistas a través de DTOs y View Models.

Para el desarrollo del backend de la aplicación se utilizarón las siguientes tecnologías:

- C#
- SQL Server como gestor de base de datos.
- Entity Framework Core como ORM.
- LinQ para manejar consultas.

### Para el frontend:

- Se utilizó código Razor en las vistas
- Se utilizó CSS para dar estilos
- JavaScript se utilizó solo para realizar algunas peticiones al servidor de manera asincrónica.

### Sobre la base de datos

La base de datos, desarrollada en SQL Server, consta de un total de 13 tablas, las cuales almacenan los datos referentes a los procesos en la aplicación. En el archivo Database.SQL se encuentran los scripts necesarios para ganerar la base de datos.

Diagrama para la base de datos:

![image](https://user-images.githubusercontent.com/77745940/145115112-d92f40ff-22d6-4fba-810b-94d6ca1f2eb4.png)


