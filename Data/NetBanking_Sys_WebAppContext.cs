using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class NetBanking_Sys_WebAppContext : DbContext
    {
        public NetBanking_Sys_WebAppContext()
        {
        }

        public NetBanking_Sys_WebAppContext(DbContextOptions<NetBanking_Sys_WebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientesCuenta> ClientesCuentas { get; set; }
        public virtual DbSet<ClientesPrestamo> ClientesPrestamos { get; set; }
        public virtual DbSet<ClientesTarjeta> ClientesTarjetas { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<HistorialDeposito> HistorialDepositos { get; set; }
        public virtual DbSet<HistorialPagosPrestamo> HistorialPagosPrestamos { get; set; }
        public virtual DbSet<HistorialPagosTarjetum> HistorialPagosTarjeta { get; set; }
        public virtual DbSet<HistorialRetiro> HistorialRetiros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tarjeta> Tarjetas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BFLORENTINO\\SQLBRYAN;Initial Catalog=NetBanking_Sys_WebApp;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__CLIENTES__B4ADFE39B4B4B020");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Correo_Electronico");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(130)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientesCuenta>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.NumeroCuenta })
                    .HasName("PK__CLIENTES__399B59E6A08DC597");

                entity.ToTable("CLIENTES_CUENTAS");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.ClientesCuenta)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Cedul__5812160E");

                entity.HasOne(d => d.NumeroCuentaNavigation)
                    .WithMany(p => p.ClientesCuenta)
                    .HasForeignKey(d => d.NumeroCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Numer__59063A47");
            });

            modelBuilder.Entity<ClientesPrestamo>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.CodigoPrestamo })
                    .HasName("PK__CLIENTES__74F0EAB2321976B5");

                entity.ToTable("CLIENTES_PRESTAMOS");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPrestamo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Prestamo");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.ClientesPrestamos)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Cedul__5441852A");

                entity.HasOne(d => d.CodigoPrestamoNavigation)
                    .WithMany(p => p.ClientesPrestamos)
                    .HasForeignKey(d => d.CodigoPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Codig__5535A963");
            });

            modelBuilder.Entity<ClientesTarjeta>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.NumeroTarjeta })
                    .HasName("PK__CLIENTES__85DEF3A27F3EFE38");

                entity.ToTable("CLIENTES_TARJETAS");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Tarjeta");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.ClientesTarjeta)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Cedul__73BA3083");

                entity.HasOne(d => d.NumeroTarjetaNavigation)
                    .WithMany(p => p.ClientesTarjeta)
                    .HasForeignKey(d => d.NumeroTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___Numer__74AE54BC");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.NumeroCuenta)
                    .HasName("PK__CUENTAS__D36A7DF96FF6B00D");

                entity.ToTable("CUENTAS");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta");

                entity.Property(e => e.Balance).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion");
            });

            modelBuilder.Entity<HistorialDeposito>(entity =>
            {
                entity.HasKey(e => e.CodigoDeposito)
                    .HasName("PK__HISTORIA__6F0CC4C9A101F592");

                entity.ToTable("HISTORIAL_DEPOSITOS");

                entity.Property(e => e.CodigoDeposito)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Deposito");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoDepositado)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("Monto_Depositado");

                entity.Property(e => e.NumeroCuentaDestinoDeposito)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta_Destino_Deposito");

                entity.Property(e => e.TarjetaOrigenRetiro)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Tarjeta_Origen_Retiro");

                entity.HasOne(d => d.NumeroCuentaDestinoDepositoNavigation)
                    .WithMany(p => p.HistorialDepositos)
                    .HasForeignKey(d => d.NumeroCuentaDestinoDeposito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Fecha__1CBC4616");

                entity.HasOne(d => d.TarjetaOrigenRetiroNavigation)
                    .WithMany(p => p.HistorialDepositos)
                    .HasForeignKey(d => d.TarjetaOrigenRetiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Tarje__1DB06A4F");
            });

            modelBuilder.Entity<HistorialPagosPrestamo>(entity =>
            {
                entity.HasKey(e => e.CodigoPago)
                    .HasName("PK__HISTORIA__18E10B919F86AAFE");

                entity.ToTable("HISTORIAL_PAGOS_PRESTAMOS");

                entity.Property(e => e.CodigoPago)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Pago");

                entity.Property(e => e.CodigoPrestamo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Prestamo");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoPagado).HasColumnType("decimal(13, 2)");

                entity.HasOne(d => d.CodigoPrestamoNavigation)
                    .WithMany(p => p.HistorialPagosPrestamos)
                    .HasForeignKey(d => d.CodigoPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Fecha__03F0984C");
            });

            modelBuilder.Entity<HistorialPagosTarjetum>(entity =>
            {
                entity.HasKey(e => e.CodigoPago)
                    .HasName("PK__HISTORIA__18E10B918F8D642D");

                entity.ToTable("HISTORIAL_PAGOS_TARJETA");

                entity.Property(e => e.CodigoPago)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Pago");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoPagado).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.NumeroCuentaOrigen)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta_Origen");

                entity.Property(e => e.NumeroTarjeta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Tarjeta");

                entity.HasOne(d => d.NumeroCuentaOrigenNavigation)
                    .WithMany(p => p.HistorialPagosTarjeta)
                    .HasForeignKey(d => d.NumeroCuentaOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Numer__57DD0BE4");

                entity.HasOne(d => d.NumeroTarjetaNavigation)
                    .WithMany(p => p.HistorialPagosTarjeta)
                    .HasForeignKey(d => d.NumeroTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Numer__56E8E7AB");
            });

            modelBuilder.Entity<HistorialRetiro>(entity =>
            {
                entity.HasKey(e => e.CodigoRetiro)
                    .HasName("PK__HISTORIA__2751F66607A0AB9F");

                entity.ToTable("HISTORIAL_RETIROS");

                entity.Property(e => e.CodigoRetiro)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Retiro");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoRetirado).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.NumeroCuentaOrigenRetiro)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta_Origen_Retiro");

                entity.Property(e => e.TarjetaDestinoDeposito)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Tarjeta_Destino_Deposito");

                entity.HasOne(d => d.NumeroCuentaOrigenRetiroNavigation)
                    .WithMany(p => p.HistorialRetiros)
                    .HasForeignKey(d => d.NumeroCuentaOrigenRetiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Fecha__2180FB33");

                entity.HasOne(d => d.TarjetaDestinoDepositoNavigation)
                    .WithMany(p => p.HistorialRetiros)
                    .HasForeignKey(d => d.TarjetaDestinoDeposito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORIAL__Tarje__22751F6C");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.CodigoPrestamo)
                    .HasName("PK__PRESTAMO__05D148BDB785EEE2");

                entity.ToTable("PRESTAMOS");

                entity.Property(e => e.CodigoPrestamo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Prestamo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CuotasTotalesAPagar).HasColumnName("Cuotas_Totales_A_Pagar");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.MontoPrestado)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("Monto_Prestado");

                entity.Property(e => e.PagoPorCuota).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__ROLES__3C872F7681102715");

                entity.ToTable("ROLES");

                entity.Property(e => e.IdRol)
                    .ValueGeneratedNever()
                    .HasColumnName("idRol");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombreRol");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.NumeroTarjeta)
                    .HasName("PK__TARJETAS__1730D9B294B7EA30");

                entity.ToTable("TARJETAS");

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Tarjeta");

                entity.Property(e => e.BalanceConsumido).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.BalanceDisponible).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Expedicion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Vencimiento");

                entity.Property(e => e.TopeCredito).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.ValorDeValidacion).HasColumnName("Valor_De_Validacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NombreUsuario)
                    .HasName("PK__USUARIOS__6B0F5AE17CE4495A");

                entity.ToTable("USUARIOS");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.PasswordHashed)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("passwordHashed");

                entity.Property(e => e.RutaFoto).IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__RutaFo__2B0A656D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
