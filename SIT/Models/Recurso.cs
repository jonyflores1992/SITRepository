using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Recurso
    {
        public Recurso()
        {
            DefectosCalidad = new HashSet<DefectosCalidad>();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid? IdSector { get; set; }
        public Guid? IdGrupoRecursoPrincipal { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? FechaNacimiento { get; set; }
        public Guid? IdUnidadMedida { get; set; }
        public int? ProductividadDeseada { get; set; }
        public float? Costo { get; set; }
        public string CodigoBarra { get; set; }
        public string Codigo { get; set; }
        public bool? TurnoNoche { get; set; }
        public Guid? Status { get; set; }
        public string Foto { get; set; }
        public Guid? IdActividad { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Actividad IdActividadNavigation { get; set; }
        public virtual GrupoRecurso IdGrupoRecursoPrincipalNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual UnidadDeMedida IdUnidadMedidaNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }

        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }
        public virtual ICollection<Lectura> Lectura { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }
    }
}
