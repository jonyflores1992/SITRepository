using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Estatus
    {
        public Estatus()
        {
            Actividad = new HashSet<Actividad>();
            Area = new HashSet<Area>();
            Componente = new HashSet<Componente>();
            DetalleDeParada = new HashSet<DetalleDeParada>();
            GrupoRecurso = new HashSet<GrupoRecurso>();
            Linea = new HashSet<Linea>();
            MotivoDeParada = new HashSet<MotivoDeParada>();
            Operacion = new HashSet<Operacion>();
            Producto = new HashSet<Producto>();
            Recurso = new HashSet<Recurso>();
            Sector = new HashSet<Sector>();
            UnidadDeMedida = new HashSet<UnidadDeMedida>();
            DefectosCalidad = new HashSet<DefectosCalidad>();

        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Componente> Componente { get; set; }
        public virtual ICollection<DetalleDeParada> DetalleDeParada { get; set; }
        public virtual ICollection<GrupoRecurso> GrupoRecurso { get; set; }
        public virtual ICollection<Linea> Linea { get; set; }
        public virtual ICollection<MotivoDeParada> MotivoDeParada { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<Sector> Sector { get; set; }
        public virtual ICollection<UnidadDeMedida> UnidadDeMedida { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }
    }
}
