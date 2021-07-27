using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SIT.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Catalogo2> Catalogo2 { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Componente> Componente { get; set; }
        public virtual DbSet<DetalleDeParada> DetalleDeParada { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<EstadoMovimiento> EstadoMovimiento { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<GrupoRecurso> GrupoRecurso { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<MotivoDeParada> MotivoDeParada { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<MtoMgrupoRecurso> MtoMgrupoRecurso { get; set; }
        public virtual DbSet<MtoMsectorParada> MtoMsectorParada { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Pruebas> Pruebas { get; set; }
        public virtual DbSet<Recurso> Recurso { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<TipoParada> TipoParada { get; set; }
        public virtual DbSet<TrCambiosEstado> TrCambiosEstado { get; set; }
        public virtual DbSet<TrMovimiento> TrMovimiento { get; set; }
        public virtual DbSet<TrParada> TrParada { get; set; }
        public virtual DbSet<TrProduccion> TrProduccion { get; set; }
        public virtual DbSet<UnidadDeMedida> UnidadDeMedida { get; set; }
        public virtual DbSet<Lectura> Lectura { get; set; }
       

        public virtual DbSet<Automatizacion> Automatizacion { get; set; }
        public virtual DbSet<PuntoDeControl> PuntoDeControl { get; set; }
        public virtual DbSet<TrMovimientosDetalle> TrMovimientosDetalle { get; set; }
        public virtual DbSet<TipoProduccion> TipoProduccion { get; set; }
        public virtual DbSet<DefectosCalidad> DefectosCalidad { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Data Source=OCTECNO018;Initial Catalog=SITDTB03;User ID=sa;Password=Admin2021");
                optionsBuilder.UseSqlServer("Data Source=192.168.23.134\\MSSQLSERVERDESAR;Initial Catalog=SITDTB;Persist Security Info=True;User ID=ecanales;Password=melon.2021");
                // scaffold - DBContext "Data Source=192.168.23.134\\MSSQLSERVERDESAR;Initial Catalog=SITDTB;User ID=ecanales;Password=melon.2021;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Context UserContext
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Actividad1)
                    .HasColumnName("Actividad")
                    .HasMaxLength(50);

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.CodigoBarra).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.FactorConversion).HasColumnName("factorConversion");

                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdComponente)
                    .HasConstraintName("FK_Actividad_Componente");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdGrupoRecurso)
                    .HasConstraintName("FK_Actividad_GrupoRecurso");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdOperacion)
                    .HasConstraintName("FK_Actividad_Operacion");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Actividad_Producto");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .HasConstraintName("FK_Actividad_UnidadDeMedida");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Actividad_Estatus");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Area1)
                    .HasColumnName("Area")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");
                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Area_Estatus");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_Area_Sucursal");
            });

            modelBuilder.Entity<PuntoDeControl>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PuntoDeControl1)
                    .HasColumnName("puntoDeControl")
                    .HasMaxLength(50);

                entity.Property(e => e.DescripcionUbicacion)
                   .HasColumnName("descripcionUbicacion")
                   .HasMaxLength(250);

                entity.Property(e => e.Lat)
                   .HasColumnName("Lat")
                   .HasColumnType("float");


                entity.Property(e => e.Long)
                   .HasColumnName("long")
                   .HasColumnType("float");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

               entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.PuntoDeControl)
                    .HasForeignKey(d => d.IdOperacion)
                    .HasConstraintName("FK_PuntoDeControl_Operacion");
            });

            modelBuilder.Entity<Automatizacion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(50);

                
                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Automatizacion)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Automatizacion_Sector");
            });
            modelBuilder.Entity<Catalogo2>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdPruebas).HasColumnName("idPruebas");

                entity.Property(e => e.Texto).HasMaxLength(50);

                entity.HasOne(d => d.IdPruebasNavigation)
                    .WithMany(p => p.Catalogo2)
                    .HasForeignKey(d => d.IdPruebas)
                    .HasConstraintName("FK_Catalogo2_pruebas");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Categoria).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Componente>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Componente1)
                    .HasColumnName("Componente")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Componente)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Componente_CategoriaProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Componente)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Componente_Producto");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Componente)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Componente_Estatus");
            });

            modelBuilder.Entity<DetalleDeParada>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.DetalleDeParada1)
                    .HasColumnName("detalleDeParada")
                    .HasMaxLength(50);

                entity.Property(e => e.IdGrupoDeRecurso).HasColumnName("idGrupoDeRecurso");

                entity.Property(e => e.IdMotivoParada).HasColumnName("idMotivoParada");

                entity.Property(e => e.IdSector).HasColumnName("idSector");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdGrupoDeRecursoNavigation)
                    .WithMany(p => p.DetalleDeParada)
                    .HasForeignKey(d => d.IdGrupoDeRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleDeParada_GrupoRecurso");

                entity.HasOne(d => d.IdMotivoParadaNavigation)
                    .WithMany(p => p.DetalleDeParada)
                    .HasForeignKey(d => d.IdMotivoParada)
                    .HasConstraintName("FK_DetalleDeParada_MotivoDeParada");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.DetalleDeParada)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_DetalleDeParada_Sector");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.DetalleDeParada)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_DetalleDeParada_Estatus");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sucursal1)
                    .HasColumnName("Sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.idSinAgro)
                   .HasColumnName("idSinAgro");


            });

            modelBuilder.Entity<EstadoMovimiento>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstadoMovimiento1)
                    .HasColumnName("estadoMovimiento")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GrupoRecurso>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.Grupo).HasMaxLength(50);

                entity.Property(e => e.IdSector).HasColumnName("idSector");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("IdUnidadMedida");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.GrupoRecurso)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_GrupoRecurso_Sector");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                   .WithMany(p => p.GrupoRecurso)
                   .HasForeignKey(d => d.IdUnidadMedida)
                   .HasConstraintName("FK_GrupoRecurso_UnidadMedida");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.GrupoRecurso)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_GrupoRecurso_Estatus");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Linea1)
                    .HasColumnName("Linea")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Linea)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linea_Estatus");
            });

            modelBuilder.Entity<MotivoDeParada>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdTipoParada).HasColumnName("idTipoParada");

                entity.Property(e => e.MotivoDeParada1)
                    .HasColumnName("motivoDeParada")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdTipoParadaNavigation)
                    .WithMany(p => p.MotivoDeParada)
                    .HasForeignKey(d => d.IdTipoParada)
                    .HasConstraintName("FK_MotivoDeParada_TipoParada");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.MotivoDeParada)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_MotivoDeParada_Estatus");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");

                entity.Property(e => e.Movimiento1)
                    .HasColumnName("Movimiento")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Movimiento)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK_Movimiento_Actividad");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.Movimiento)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .HasConstraintName("FK_Movimiento_TipoMovimiento");
            });

            modelBuilder.Entity<MtoMgrupoRecurso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MtoMGrupoRecurso");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");

                entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGrupoRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MtoMGrupoRecurso_GrupoRecurso");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_MtoMGrupoRecurso_Recurso");
            });

            modelBuilder.Entity<MtoMsectorParada>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MtoMSectorParada");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdMotivoParada).HasColumnName("idMotivoParada");

                entity.Property(e => e.IdSector).HasColumnName("idSector");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdMotivoParadaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMotivoParada)
                    .HasConstraintName("FK_MtoMSectorParada_MotivoDeParada");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_MtoMSectorParada_Sector");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");

                entity.Property(e => e.Operacion1)
                    .HasColumnName("Operacion")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdGrupoRecurso)
                    .HasConstraintName("FK_Operacion_GrupoRecurso");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Operacion_Estatus");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Producto1)
                    .HasColumnName("Producto")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_CategoriaProducto");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Producto_Estatus");
            });

            modelBuilder.Entity<Pruebas>(entity =>
            {
                entity.ToTable("pruebas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Prueba)
                    .HasColumnName("prueba")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.CodigoBarra).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.TurnoNoche).HasDefaultValueSql("((0))");


                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Foto).HasMaxLength(50);

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdGrupoRecursoPrincipal).HasColumnName("idGrupoRecursoPrincipal");

                entity.Property(e => e.IdSector).HasColumnName("idSector");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK_Recurso_Actividad");

                entity.HasOne(d => d.IdGrupoRecursoPrincipalNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdGrupoRecursoPrincipal)
                    .HasConstraintName("FK_Recurso_GrupoRecurso2");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Recurso_Sector");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .HasConstraintName("FK_Recurso_UnidadDeMedida");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Recurso_Estatus");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.IdArea).HasColumnName("idArea");
                entity.Property(e => e.Orden).HasColumnName("Orden");

                entity.Property(e => e.Sector1)
                    .IsRequired()
                    .HasColumnName("Sector")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Sector_Area");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Sector_Estatus");
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoMovimiento1)
                    .HasColumnName("TipoMovimiento")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");
            });
            modelBuilder.Entity<TipoProduccion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

               

                entity.Property(e => e.TipoProduccion1)
                    .HasColumnName("TipoProduccion")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");
            });
            modelBuilder.Entity<TipoParada>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TipoParada1)
                    .HasColumnName("TipoParada")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TrCambiosEstado>(entity =>
            {
                entity.ToTable("trCambiosEstado");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdEstadoFinal).HasColumnName("idEstadoFinal");

                entity.Property(e => e.IdEstadoInicial).HasColumnName("idEstadoInicial");

                entity.Property(e => e.IdTrMovimiento).HasColumnName("idTrMovimiento");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdEstadoFinalNavigation)
                    .WithMany(p => p.TrCambiosEstadoIdEstadoFinalNavigation)
                    .HasForeignKey(d => d.IdEstadoFinal)
                    .HasConstraintName("FK_trCambiosEstado_EstadoMovimiento1");

                entity.HasOne(d => d.IdEstadoInicialNavigation)
                    .WithMany(p => p.TrCambiosEstadoIdEstadoInicialNavigation)
                    .HasForeignKey(d => d.IdEstadoInicial)
                    .HasConstraintName("FK_trCambiosEstado_EstadoMovimiento");
            });
            modelBuilder.Entity<DefectosCalidad>(entity =>
            {
                entity.ToTable("DefectosCalidad");
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasDefaultValueSql("(newid())");
                entity.Property(e => e.IdSector)
                .HasColumnName("IdSector");
                entity.Property(e => e.IdgrupoRecurso)
                .HasColumnName("IdgrupoRecurso");
                entity.Property(e => e.IdRecurso)
                .HasColumnName("IdRecurso");
                entity.Property(e => e.IdProducto)
                .HasColumnName("IdProducto");
                entity.Property(e => e.IdComponente)
                .HasColumnName("IdComponente");
                entity.Property(e => e.Codigo)
                .HasColumnName("Codigo");
                entity.Property(e => e.Defecto)
                .HasColumnName("Defecto");
                entity.Property(e => e.Status)
                .HasColumnName("Status");
                entity.Property(e => e.DescripcionDefecto)
                .HasColumnName("DescripcionDefecto");

                entity.HasOne(d => d.StatusNavigation)
             .WithMany(p => p.DefectosCalidad)
             .HasForeignKey(d => d.Status);
                entity.HasOne(d => d.IdSectorNavigation)
.WithMany(p => p.DefectosCalidad)
.HasForeignKey(d => d.IdSector);
                entity.HasOne(d => d.IdgruporecursoNavigation)
.WithMany(p => p.DefectosCalidad)
.HasForeignKey(d => d.IdgrupoRecurso);
                entity.HasOne(d => d.IdproductoNavigation)
.WithMany(p => p.DefectosCalidad)
.HasForeignKey(d => d.IdProducto);
                entity.HasOne(d => d.IdrecurosNavigation)
.WithMany(p => p.DefectosCalidad)
.HasForeignKey(d => d.IdRecurso);
                entity.HasOne(d => d.IdcomponenteNavigation)
.WithMany(p => p.DefectosCalidad)
.HasForeignKey(d => d.IdComponente);


            });


            modelBuilder.Entity<TrMovimiento>(entity =>
            {
                entity.ToTable("trMovimiento");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraFin)
                    .HasColumnName("fechaHoraFin")
                    .HasColumnType("time");

                entity.Property(e => e.FechaHoraInicio)
                    .HasColumnName("fechaHoraInicio")
                    .HasColumnType("time");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");
                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");
                entity.Property(e => e.IdSector).HasColumnName("idSector");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");
                entity.Property(e => e.Productividad).HasColumnName("productividad");
                entity.Property(e => e.Producido).HasColumnName("producido");
                entity.Property(e => e.Disponible).HasColumnName("Disponible");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TrMovimiento)
                    .HasForeignKey(d => d.IdMovimiento)
                    .HasConstraintName("FK_trMovimiento_Movimiento");

                entity.HasOne(d => d.IdActividadNavigation)
                   .WithMany(p => p.TrMovimiento)
                   .HasForeignKey(d => d.IdActividad)
                   .HasConstraintName("FK_trMovimiento_Actividad");

                entity.HasOne(d => d.IdEstadoNavigation)
                 .WithMany(p => p.TrMovimiento)
                 .HasForeignKey(d => d.IdEstado)
                 .HasConstraintName("FK_trMovimiento_EstadoMovimiento");

                entity.HasOne(d => d.IdRecursoNavigation)
               .WithMany(p => p.TrMovimiento)
               .HasForeignKey(d => d.IdRecurso)
               .HasConstraintName("FK_trMovimiento_Recurso");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
              .WithMany(p => p.TrMovimiento)
              .HasForeignKey(d => d.IdGrupoRecurso)
              .HasConstraintName("FK_trMovimiento_GrupoRecurso");

                entity.HasOne(d => d.IdSectorNavigation)
              .WithMany(p => p.TrMovimiento)
              .HasForeignKey(d => d.IdSector)
              //.HasConstraintName("FK_trMovimiento_Sector")
              ;

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
            .WithMany(p => p.TrMovimiento)
            .HasForeignKey(d => d.IdTipoMovimiento)
            .HasConstraintName("FK_trMovimiento_TipoMovimiento");
            });

            modelBuilder.Entity<TrParada>(entity =>
            {
                entity.ToTable("trParada");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdDetalleDeParada).HasColumnName("idDetalleDeParada");

                entity.Property(e => e.IdMotivoParada).HasColumnName("idMotivoParada");

                entity.Property(e => e.IdTrMovimiento).HasColumnName("idTrMovimiento");

                entity.Property(e => e.Retroactiva).HasColumnName("retroactiva");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdTrMovimientoNavigation)
                    .WithMany(p => p.TrParada)
                    .HasForeignKey(d => d.IdTrMovimiento)
                    .HasConstraintName("FK_trParada_trMovimiento");

                entity.HasOne(d => d.IdMotivoParadaNavigation)
                 .WithMany(p => p.TrParada)
                 .HasForeignKey(d => d.IdMotivoParada)
                 .HasConstraintName("FK_trParada_MotivoDeParada");

                entity.HasOne(d => d.IdDetalleDeParadaNavigation)
              .WithMany(p => p.TrParada)
              .HasForeignKey(d => d.IdDetalleDeParada)
              .HasConstraintName("FK_trParada_DetalleDeParada");

            });
            modelBuilder.Entity<TrMovimientosDetalle>(entity =>
            {
                entity.ToTable("TrMovimientosDetalle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");


             

                entity.Property(e => e.IdDetalleDeParada).HasColumnName("idDetalleDeParada");

                entity.Property(e => e.IdMotivoParada).HasColumnName("idMotivoParada");

                entity.Property(e => e.IdTrMovimiento).HasColumnName("idTrMovimiento");
                entity.Property(e => e.Cantidad).HasColumnName("Cantidad");





                entity.HasOne(d => d.IdTrMovimientoNavigation)
                    .WithMany(p => p.TrMovimientosDetalle)
                    .HasForeignKey(d => d.IdTrMovimiento);
                   

                entity.HasOne(d => d.IdMotivoParadaNavigation)
                 .WithMany(p => p.TrMovimientosDetalle)
                 .HasForeignKey(d => d.IdMotivoParada);

                entity.HasOne(d => d.IdDetalleDeParadaNavigation)
              .WithMany(p => p.TrMovimientosDetalle)
              .HasForeignKey(d => d.IdDetalleDeParada);

                entity.HasOne(d => d.IdTipoProduccionNavigation)
             .WithMany(p => p.TrMovimientosDetalle)
             .HasForeignKey(d => d.IdTipoProduccion);

            });
            modelBuilder.Entity<TrProduccion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdComponente).HasColumnName("idComponente");

                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");

                entity.Property(e => e.IdTrMovimiento).HasColumnName("idTrMovimiento");
                entity.Property(e => e.Disponibles).HasColumnName("Disponibles");
                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdTrMovimientoNavigation)
                    .WithMany(p => p.TrProduccion)
                    .HasForeignKey(d => d.IdTrMovimiento)
                    .HasConstraintName("FK_TrProduccion_trMovimiento");

                entity.HasOne(d => d.IdComponenteNavigation)
                   .WithMany(p => p.TrProduccion)
                   .HasForeignKey(d => d.IdComponente)
                   .HasConstraintName("FK_TrProduccion_Componente");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
               .WithMany(p => p.TrProduccion)
               .HasForeignKey(d => d.IdGrupoRecurso)
               .HasConstraintName("FK_TrProduccion_GrupoRecurso");

                entity.HasOne(d => d.IdOperacionNavigation)
                  .WithMany(p => p.TrProduccion)
                  .HasForeignKey(d => d.IdOperacion)
                  .HasConstraintName("FK_TrProduccion_Operacion");

                entity.HasOne(d => d.IdRecursoNavigation)
             .WithMany(p => p.TrProduccion)
             .HasForeignKey(d => d.IdRecurso)
             .HasConstraintName("FK_TrProduccion_Recurso");

                entity.HasOne(d => d.IdProductoNavigation)
       .WithMany(p => p.TrProduccion)
       .HasForeignKey(d => d.IdProducto)
       .HasConstraintName("FK_TrProduccion_Producto");
       
       entity.HasOne(d => d.IdTipoProduccionNavigation)
      .WithMany(p => p.TrProduccion)
      .HasForeignKey(d => d.IdTipoProduccion)
      .HasConstraintName("FK_TrProduccion_TipoProduccion");
         
        });




            modelBuilder.Entity<Lectura>(entity =>
            {

               entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(10);


                entity.Property(e => e.Linea).HasMaxLength(50);

                entity.Property(e => e.CodigoBarra).HasMaxLength(50);

                entity.Property(e => e.IdGrupoRecurso).HasColumnName("idGrupoRecurso");
                entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");

                entity.Property(e => e.SerialDispositivo).HasColumnName("SerialDispositivo");
                entity.Property(e => e.IdSector).HasColumnName("idSector");

               
                entity.Property(e => e.IdActividad).HasColumnName("idActividad");
                entity.Property(e => e.IdPuntoDeControl).HasColumnName("idPuntoDeControl");

                entity.Property(e => e.FechaHora)
                    .HasColumnName("FechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaHoraLector)
                  .HasColumnName("FechaHoraLector")
                  .HasColumnType("datetime");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Lectura)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK_Lectura_Actividad");

                entity.HasOne(d => d.IdGrupoRecursoNavigation)
                    .WithMany(p => p.Lectura)
                    .HasForeignKey(d => d.IdGrupoRecurso)
                    .HasConstraintName("FK_Lectura_GrupoRecurso");

 

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.Lectura)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_Lectura_Recurso");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Lectura)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Lectura_Sector");

                entity.HasOne(d => d.IdPuntoDeControlNavigation)
                  .WithMany(p => p.Lectura)
                  .HasForeignKey(d => d.IdPuntoDeControl)
                  .HasConstraintName("FK_Lectura_PuntoDeControl");


            });
            modelBuilder.Entity<UnidadDeMedida>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadDeMedida1)
                    .HasColumnName("unidadDeMedida")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("updateAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.UnidadDeMedida)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_UnidadDeMedida_Estatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



   
    }
}
