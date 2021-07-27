using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Operacion
    {
        public Operacion()
        {
            Actividad = new HashSet<Actividad>();
        }

        public Guid Id { get; set; }
        public string Operacion1 { get; set; }
        public Guid? IdGrupoRecurso { get; set; }
        public Guid? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual GrupoRecurso IdGrupoRecursoNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<PuntoDeControl> PuntoDeControl { get; set; }
        
    }
}
