using Microsoft.EntityFrameworkCore.Migrations;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIT.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Categoria = table.Column<string>(maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMovimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    estadoMovimiento = table.Column<string>(maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMovimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pruebas",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    prueba = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pruebas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Sucursal = table.Column<string>(maxLength: 50, nullable: true),
                    idSinAgro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TipoMovimiento = table.Column<string>(maxLength: 50, nullable: true),
                    foto = table.Column<string>(maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoParada",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TipoParada = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoParada", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trCambiosEstado",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    idEstadoInicial = table.Column<Guid>(nullable: true),
                    idEstadoFinal = table.Column<Guid>(nullable: true),
                    InicioReal = table.Column<TimeSpan>(nullable: true),
                    FinReal = table.Column<TimeSpan>(nullable: true),
                    horas = table.Column<float>(nullable: true),
                    idTrMovimiento = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trCambiosEstado", x => x.id);
                    table.ForeignKey(
                        name: "FK_trCambiosEstado_EstadoMovimiento1",
                        column: x => x.idEstadoFinal,
                        principalTable: "EstadoMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trCambiosEstado_EstadoMovimiento",
                        column: x => x.idEstadoInicial,
                        principalTable: "EstadoMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    Linea = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea", x => x.id);
                    table.ForeignKey(
                        name: "FK_Linea_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Producto = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    idCategoria = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_CategoriaProducto",
                        column: x => x.idCategoria,
                        principalTable: "CategoriaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnidadDeMedida",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    unidadDeMedida = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadDeMedida", x => x.id);
                    table.ForeignKey(
                        name: "FK_UnidadDeMedida_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogo2",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    idPruebas = table.Column<Guid>(nullable: true),
                    Texto = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo2", x => x.id);
                    table.ForeignKey(
                        name: "FK_Catalogo2_pruebas",
                        column: x => x.idPruebas,
                        principalTable: "pruebas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Area = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    idSucursal = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.id);
                    table.ForeignKey(
                        name: "FK_Area_Sucursal",
                        column: x => x.idSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotivoDeParada",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    motivoDeParada = table.Column<string>(maxLength: 50, nullable: true),
                    idTipoParada = table.Column<Guid>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoDeParada", x => x.id);
                    table.ForeignKey(
                        name: "FK_MotivoDeParada_TipoParada",
                        column: x => x.idTipoParada,
                        principalTable: "TipoParada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotivoDeParada_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Componente = table.Column<string>(maxLength: 50, nullable: true),
                    idProducto = table.Column<Guid>(nullable: true),
                    Kilogramos = table.Column<float>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    Descripcion = table.Column<string>(nullable: false),
                    idCategoria = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Componente_CategoriaProducto",
                        column: x => x.idCategoria,
                        principalTable: "CategoriaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Componente_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Componente_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Sector = table.Column<string>(maxLength: 50, nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    status = table.Column<Guid>(nullable: false),
                    idArea = table.Column<Guid>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sector_Area",
                        column: x => x.idArea,
                        principalTable: "Area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sector_Estatus",
                        column: x => x.status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automatizacion",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    IdSector = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automatizacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Automatizacion_Sector",
                        column: x => x.IdSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoRecurso",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Grupo = table.Column<string>(maxLength: 50, nullable: true),
                    idSector = table.Column<Guid>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    IdUnidadMedida = table.Column<Guid>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoRecurso", x => x.id);
                    table.ForeignKey(
                        name: "FK_GrupoRecurso_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoRecurso_UnidadMedida",
                        column: x => x.IdUnidadMedida,
                        principalTable: "UnidadDeMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoRecurso_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MtoMSectorParada",
                columns: table => new
                {
                    idSector = table.Column<Guid>(nullable: true),
                    idMotivoParada = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MtoMSectorParada_MotivoDeParada",
                        column: x => x.idMotivoParada,
                        principalTable: "MotivoDeParada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MtoMSectorParada_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDeParada",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    detalleDeParada = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    idSector = table.Column<Guid>(nullable: true),
                    idGrupoDeRecurso = table.Column<Guid>(nullable: false),
                    idMotivoParada = table.Column<Guid>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeParada", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleDeParada_GrupoRecurso",
                        column: x => x.idGrupoDeRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleDeParada_MotivoDeParada",
                        column: x => x.idMotivoParada,
                        principalTable: "MotivoDeParada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleDeParada_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleDeParada_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Operacion = table.Column<string>(maxLength: 50, nullable: true),
                    idGrupoRecurso = table.Column<Guid>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Operacion_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacion_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Actividad = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    idProducto = table.Column<Guid>(nullable: true),
                    IdComponente = table.Column<Guid>(nullable: true),
                    idGrupoRecurso = table.Column<Guid>(nullable: true),
                    idOperacion = table.Column<Guid>(nullable: true),
                    Instrucciones = table.Column<string>(nullable: true),
                    CodigoBarra = table.Column<string>(maxLength: 50, nullable: true),
                    IdUnidadMedida = table.Column<Guid>(nullable: true),
                    factorConversion = table.Column<float>(nullable: true),
                    ER = table.Column<float>(nullable: true),
                    Status = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Actividad_Componente",
                        column: x => x.IdComponente,
                        principalTable: "Componente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Operacion",
                        column: x => x.idOperacion,
                        principalTable: "Operacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_UnidadDeMedida",
                        column: x => x.IdUnidadMedida,
                        principalTable: "UnidadDeMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuntoDeControl",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    puntoDeControl = table.Column<string>(maxLength: 50, nullable: true),
                    descripcionUbicacion = table.Column<string>(maxLength: 250, nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    @long = table.Column<double>(name: "long", type: "float", nullable: false),
                    idOperacion = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoDeControl", x => x.id);
                    table.ForeignKey(
                        name: "FK_PuntoDeControl_Operacion",
                        column: x => x.idOperacion,
                        principalTable: "Operacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Movimiento = table.Column<string>(maxLength: 50, nullable: true),
                    idTipoMovimiento = table.Column<Guid>(nullable: true),
                    idActividad = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Actividad",
                        column: x => x.idActividad,
                        principalTable: "Actividad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimiento_TipoMovimiento",
                        column: x => x.idTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    idSector = table.Column<Guid>(nullable: true),
                    idGrupoRecursoPrincipal = table.Column<Guid>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    idUnidadMedida = table.Column<Guid>(nullable: true),
                    ProductividadDeseada = table.Column<int>(nullable: true),
                    Costo = table.Column<float>(nullable: true),
                    CodigoBarra = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    TurnoNoche = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    Status = table.Column<Guid>(nullable: true),
                    Foto = table.Column<string>(maxLength: 50, nullable: true),
                    idActividad = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recurso_Actividad",
                        column: x => x.idActividad,
                        principalTable: "Actividad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_GrupoRecurso2",
                        column: x => x.idGrupoRecursoPrincipal,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_UnidadDeMedida",
                        column: x => x.idUnidadMedida,
                        principalTable: "UnidadDeMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_Estatus",
                        column: x => x.Status,
                        principalTable: "Estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lectura",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CodigoBarra = table.Column<string>(maxLength: 50, nullable: true),
                    Linea = table.Column<string>(maxLength: 50, nullable: true),
                    SerialDispositivo = table.Column<string>(nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaHoraLector = table.Column<DateTime>(type: "datetime", nullable: false),
                    idRecurso = table.Column<Guid>(nullable: true),
                    idGrupoRecurso = table.Column<Guid>(nullable: true),
                    Cantidad = table.Column<double>(fixedLength: true, maxLength: 10, nullable: true),
                    idSector = table.Column<Guid>(nullable: true),
                    idActividad = table.Column<Guid>(nullable: true),
                    idPuntoDeControl = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectura", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lectura_Actividad",
                        column: x => x.idActividad,
                        principalTable: "Actividad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectura_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectura_PuntoDeControl",
                        column: x => x.idPuntoDeControl,
                        principalTable: "PuntoDeControl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectura_Recurso",
                        column: x => x.idRecurso,
                        principalTable: "Recurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectura_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MtoMGrupoRecurso",
                columns: table => new
                {
                    idGrupoRecurso = table.Column<Guid>(nullable: false),
                    idRecurso = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MtoMGrupoRecurso_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MtoMGrupoRecurso_Recurso",
                        column: x => x.idRecurso,
                        principalTable: "Recurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trMovimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    fechaHoraInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaHoraFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    idEstado = table.Column<Guid>(nullable: true),
                    productividad = table.Column<float>(nullable: true),
                    producido = table.Column<float>(nullable: true),
                    Disponible = table.Column<float>(nullable: true),
                    idRecurso = table.Column<Guid>(nullable: true),
                    idGrupoRecurso = table.Column<Guid>(nullable: true),
                    idSector = table.Column<Guid>(nullable: true),
                    idMovimiento = table.Column<Guid>(nullable: true),
                    idActividad = table.Column<Guid>(nullable: true),
                    idTipoMovimiento = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trMovimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_trMovimiento_Actividad",
                        column: x => x.idActividad,
                        principalTable: "Actividad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_EstadoMovimiento",
                        column: x => x.idEstado,
                        principalTable: "EstadoMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_Movimiento",
                        column: x => x.idMovimiento,
                        principalTable: "Movimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_Recurso",
                        column: x => x.idRecurso,
                        principalTable: "Recurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_Sector",
                        column: x => x.idSector,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trMovimiento_TipoMovimiento",
                        column: x => x.idTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trParada",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    idMotivoParada = table.Column<Guid>(nullable: true),
                    PeriodoTiempoInicio = table.Column<TimeSpan>(nullable: true),
                    PeriodoTiempoFin = table.Column<TimeSpan>(nullable: true),
                    InicioReal = table.Column<TimeSpan>(nullable: true),
                    FinReal = table.Column<TimeSpan>(nullable: true),
                    idDetalleDeParada = table.Column<Guid>(nullable: true),
                    horas = table.Column<float>(nullable: true),
                    retroactiva = table.Column<bool>(nullable: true),
                    idTrMovimiento = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trParada", x => x.id);
                    table.ForeignKey(
                        name: "FK_trParada_DetalleDeParada",
                        column: x => x.idDetalleDeParada,
                        principalTable: "DetalleDeParada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trParada_MotivoDeParada",
                        column: x => x.idMotivoParada,
                        principalTable: "MotivoDeParada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trParada_trMovimiento",
                        column: x => x.idTrMovimiento,
                        principalTable: "trMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrProduccion",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    PeriodoTiempoInicio = table.Column<TimeSpan>(nullable: true),
                    PeriodoTiempoFin = table.Column<TimeSpan>(nullable: true),
                    InicioReal = table.Column<TimeSpan>(nullable: true),
                    FinReal = table.Column<TimeSpan>(nullable: true),
                    idProducto = table.Column<Guid>(nullable: true),
                    idComponente = table.Column<Guid>(nullable: true),
                    idOperacion = table.Column<Guid>(nullable: true),
                    Productiva = table.Column<float>(nullable: true),
                    Disponibles = table.Column<float>(nullable: true),
                    Productividad = table.Column<float>(nullable: true),
                    Cantidad = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    idRecurso = table.Column<Guid>(nullable: true),
                    idGrupoRecurso = table.Column<Guid>(nullable: true),
                    idTrMovimiento = table.Column<Guid>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delete = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProduccion", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrProduccion_Componente",
                        column: x => x.idComponente,
                        principalTable: "Componente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProduccion_GrupoRecurso",
                        column: x => x.idGrupoRecurso,
                        principalTable: "GrupoRecurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProduccion_Operacion",
                        column: x => x.idOperacion,
                        principalTable: "Operacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProduccion_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProduccion_Recurso",
                        column: x => x.idRecurso,
                        principalTable: "Recurso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProduccion_trMovimiento",
                        column: x => x.idTrMovimiento,
                        principalTable: "trMovimiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_IdComponente",
                table: "Actividad",
                column: "IdComponente");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_idGrupoRecurso",
                table: "Actividad",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_idOperacion",
                table: "Actividad",
                column: "idOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_idProducto",
                table: "Actividad",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_IdUnidadMedida",
                table: "Actividad",
                column: "IdUnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_Status",
                table: "Actividad",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Area_idSucursal",
                table: "Area",
                column: "idSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Status",
                table: "Area",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Automatizacion_IdSector",
                table: "Automatizacion",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo2_idPruebas",
                table: "Catalogo2",
                column: "idPruebas");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_idCategoria",
                table: "Componente",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_idProducto",
                table: "Componente",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_Status",
                table: "Componente",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeParada_idGrupoDeRecurso",
                table: "DetalleDeParada",
                column: "idGrupoDeRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeParada_idMotivoParada",
                table: "DetalleDeParada",
                column: "idMotivoParada");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeParada_idSector",
                table: "DetalleDeParada",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeParada_Status",
                table: "DetalleDeParada",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRecurso_idSector",
                table: "GrupoRecurso",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRecurso_IdUnidadMedida",
                table: "GrupoRecurso",
                column: "IdUnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRecurso_Status",
                table: "GrupoRecurso",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_idActividad",
                table: "Lectura",
                column: "idActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_idGrupoRecurso",
                table: "Lectura",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_idPuntoDeControl",
                table: "Lectura",
                column: "idPuntoDeControl");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_idRecurso",
                table: "Lectura",
                column: "idRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_idSector",
                table: "Lectura",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_Status",
                table: "Linea",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoDeParada_idTipoParada",
                table: "MotivoDeParada",
                column: "idTipoParada");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoDeParada_Status",
                table: "MotivoDeParada",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_idActividad",
                table: "Movimiento",
                column: "idActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_idTipoMovimiento",
                table: "Movimiento",
                column: "idTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMGrupoRecurso_idGrupoRecurso",
                table: "MtoMGrupoRecurso",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMGrupoRecurso_idRecurso",
                table: "MtoMGrupoRecurso",
                column: "idRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMSectorParada_idMotivoParada",
                table: "MtoMSectorParada",
                column: "idMotivoParada");

            migrationBuilder.CreateIndex(
                name: "IX_MtoMSectorParada_idSector",
                table: "MtoMSectorParada",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_idGrupoRecurso",
                table: "Operacion",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Status",
                table: "Operacion",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idCategoria",
                table: "Producto",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Status",
                table: "Producto",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoDeControl_idOperacion",
                table: "PuntoDeControl",
                column: "idOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_idActividad",
                table: "Recurso",
                column: "idActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_idGrupoRecursoPrincipal",
                table: "Recurso",
                column: "idGrupoRecursoPrincipal");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_idSector",
                table: "Recurso",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_idUnidadMedida",
                table: "Recurso",
                column: "idUnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_Status",
                table: "Recurso",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_idArea",
                table: "Sector",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_status",
                table: "Sector",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_trCambiosEstado_idEstadoFinal",
                table: "trCambiosEstado",
                column: "idEstadoFinal");

            migrationBuilder.CreateIndex(
                name: "IX_trCambiosEstado_idEstadoInicial",
                table: "trCambiosEstado",
                column: "idEstadoInicial");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idActividad",
                table: "trMovimiento",
                column: "idActividad");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idEstado",
                table: "trMovimiento",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idGrupoRecurso",
                table: "trMovimiento",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idMovimiento",
                table: "trMovimiento",
                column: "idMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idRecurso",
                table: "trMovimiento",
                column: "idRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idSector",
                table: "trMovimiento",
                column: "idSector");

            migrationBuilder.CreateIndex(
                name: "IX_trMovimiento_idTipoMovimiento",
                table: "trMovimiento",
                column: "idTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_trParada_idDetalleDeParada",
                table: "trParada",
                column: "idDetalleDeParada");

            migrationBuilder.CreateIndex(
                name: "IX_trParada_idMotivoParada",
                table: "trParada",
                column: "idMotivoParada");

            migrationBuilder.CreateIndex(
                name: "IX_trParada_idTrMovimiento",
                table: "trParada",
                column: "idTrMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idComponente",
                table: "TrProduccion",
                column: "idComponente");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idGrupoRecurso",
                table: "TrProduccion",
                column: "idGrupoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idOperacion",
                table: "TrProduccion",
                column: "idOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idProducto",
                table: "TrProduccion",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idRecurso",
                table: "TrProduccion",
                column: "idRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_TrProduccion_idTrMovimiento",
                table: "TrProduccion",
                column: "idTrMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadDeMedida_Status",
                table: "UnidadDeMedida",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automatizacion");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Catalogo2");

            migrationBuilder.DropTable(
                name: "Lectura");

            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "MtoMGrupoRecurso");

            migrationBuilder.DropTable(
                name: "MtoMSectorParada");

            migrationBuilder.DropTable(
                name: "trCambiosEstado");

            migrationBuilder.DropTable(
                name: "trParada");

            migrationBuilder.DropTable(
                name: "TrProduccion");

            migrationBuilder.DropTable(
                name: "pruebas");

            migrationBuilder.DropTable(
                name: "PuntoDeControl");

            migrationBuilder.DropTable(
                name: "DetalleDeParada");

            migrationBuilder.DropTable(
                name: "trMovimiento");

            migrationBuilder.DropTable(
                name: "MotivoDeParada");

            migrationBuilder.DropTable(
                name: "EstadoMovimiento");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "TipoParada");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "GrupoRecurso");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "UnidadDeMedida");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
