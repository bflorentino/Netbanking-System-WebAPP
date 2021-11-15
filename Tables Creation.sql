create database NetBanking_Sys_WebApp

use NetBanking_Sys_WebApp;

CREATE TABLE CLIENTES
(
	Cedula varchar(11) check(len(Cedula)=11),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	FechaNacimiento date not null,
	Direccion varchar(130) not null,
	Telefono varchar(12) not null check(len(Telefono)= 13),
	Correo_Electronico varchar(100),
	primary key(Cedula)
);

CREATE TABLE PRESTAMOS
(
	Codigo_Prestamo varchar(10) check (len(Codigo_Prestamo) = 10) PRIMARY KEY,
	Fecha_Inicio date not null,
	Monto_Prestado decimal(11, 2) not null,
	Cuotas_Totales_A_Pagar int not null,
	CuotasPagadas int not null,
	PagoPorCuota decimal(11, 2) not null,
	TasaInteres decimal(2,2) not null,
	Activo varchar(2) not null check (Activo = 'Si' or Activo = 'No')
);

CREATE TABLE CUENTAS
(
	Numero_Cuenta varchar(20) primary key check(len(Numero_Cuenta) = 20),
 	Fecha_Creacion date not null,
	Balance decimal(13, 2) not null,
);

CREATE TABLE TARJETAS
(
	Numero_Tarjeta varchar(16) check(len(Numero_Tarjeta) = 16),
	Valor_De_Validacion int check(Valor_De_Validacion between 100 and 999) not null,
	Fecha_Vencimiento date not null,
	BalanceDisponible decimal(13,2) not null,
	BalanceConsumido decimal(13,2),
	Fecha_Expedicion date not null
	primary key(Numero_Tarjeta)
);

CREATE TABLE CLIENTES_PRESTAMOS
(
	Cedula varchar(11),
	Codigo_Prestamo varchar(10)
	primary key(Cedula, Codigo_Prestamo),
	foreign key(Cedula) references CLIENTES(Cedula),
	foreign key(Codigo_Prestamo) references PRESTAMOS(Codigo_Prestamo) 
)

CREATE TABLE CLIENTES_CUENTAS
(	
	Cedula varchar(11) not null,
	Numero_Cuenta varchar(20) not null,
	primary key(Cedula, Numero_Cuenta),
	foreign key(Cedula) references CLIENTES(Cedula),
	foreign key(Numero_Cuenta) references CUENTAS(Numero_Cuenta)
);

CREATE TABLE CLIENTES_TARJETAS
(	
	Cedula varchar(11) not null,
	Numero_Tarjeta varchar(16) not null,
	primary key(Cedula, Numero_Tarjeta),
	foreign key(Cedula) references CLIENTES(Cedula),
	foreign key(Numero_Tarjeta) references Tarjetas(Numero_Tarjeta)
);

 CREATE TABLE USUARIOS
(
	NombreUsuario varchar(100) not null,
	passwordHashed varchar(max) not null,
	idRol int not null,
	RutaFoto varchar(max)
	primary key(NombreUsuario)
	Foreign key(idRol) references ROLES(idRol)
)

 CREATE TABLE ROLES
(
	idRol int primary key,
	nombreRol varchar(25) not null
);

 CREATE TABLE HISTORIAL_PAGOS_PRESTAMOS
(
	Codigo_Pago varchar(7) not null primary key check(len(Codigo_Pago)=7), 
	Codigo_Prestamo varchar(10) not null,
	MontoPagado decimal(13, 2) not null,
	Fecha date not null
	Foreign key (Codigo_Prestamo) references PRESTAMOS(Codigo_Prestamo)
)

 CREATE TABLE HISTORIAL_RETIROS
(
	Codigo_Retiro varchar(7) primary key check(len(Codigo_Retiro) = 7),
	Numero_Cuenta_Origen_Retiro varchar(20) not null,
    Tarjeta_Destino_Deposito varchar(16) not null,
	MontoRetirado decimal(13, 2) not null,
    Fecha date not null
	Foreign key (Numero_Cuenta_Origen_Retiro) references CUENTAS(Numero_Cuenta),
	Foreign key (Tarjeta_Destino_Deposito) references TARJETAS(Numero_Tarjeta)
)

CREATE TABLE HISTORIAL_DEPOSITOS
(
	Codigo_Deposito varchar(8) primary key check(len(Codigo_Deposito) = 8),
    Tarjeta_Origen_Retiro varchar(16) not null,
	Numero_Cuenta_Destino_Deposito varchar(20) not null,
	Monto_Depositado decimal(13, 2) not null,
    Fecha date not null
	Foreign key (Numero_Cuenta_Destino_Deposito) references CUENTAS(Numero_Cuenta),
	Foreign key (Tarjeta_Origen_Retiro) references TARJETAS(Numero_Tarjeta)
); 
