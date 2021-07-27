using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TrMovimiento
    {
        public TrMovimiento()
        {
            TrParada = new HashSet<TrParada>();
            // TrProduccion = new HashSet<TrProduccion>();
           
        }

        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime Fecha { get; set; }
        
        public TimeSpan? FechaHoraInicio { get; set; }
        
        public TimeSpan? FechaHoraFin { get; set; }
        public Guid? IdEstado { get; set; }
        public float? Productividad { get; set; }
        public float? Producido { get; set; }
        public float? Disponible { get; set; }
        public Guid? IdRecurso { get; set; }
        public Guid? IdGrupoRecurso { get; set; }
        public Guid? IdSector { get; set; }

        public Guid? IdMovimiento { get; set; }
        public Guid? IdActividad { get; set; }
        public Guid? IdTipoMovimiento { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }
        

        public virtual Movimiento IdMovimientoNavigation { get; set; }
        public virtual EstadoMovimiento IdEstadoNavigation { get; set; }
        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual GrupoRecurso IdGrupoRecursoNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual Actividad IdActividadNavigation { get; set; }
        public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; }
        public virtual ICollection<TrParada> TrParada { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<TrMovimientosDetalle> TrMovimientosDetalle { get; set; }
       
    }
}
