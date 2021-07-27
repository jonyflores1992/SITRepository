using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class GrupoRecurso
    {
        public GrupoRecurso()
        {
            Actividad = new HashSet<Actividad>();
            DetalleDeParada = new HashSet<DetalleDeParada>();
            Operacion = new HashSet<Operacion>();
            Recurso = new HashSet<Recurso>();
            DefectosCalidad = new HashSet<DefectosCalidad>();
        }

        public Guid Id { get; set; }
        public string Grupo { get; set; }
        public Guid? IdSector { get; set; }
        public Guid? Status { get; set; }
        public Guid? IdUnidadMedida { get; set; }
        public string Foto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Sector IdSectorNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual UnidadDeMedida IdUnidadMedidaNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<DetalleDeParada> DetalleDeParada { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<Lectura> Lectura { get; set; }
        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }

    }
}
