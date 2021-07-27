using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class UnidadDeMedida
    {
        public UnidadDeMedida()
        {
            Actividad = new HashSet<Actividad>();
            Recurso = new HashSet<Recurso>();
        }

        public Guid Id { get; set; }
        public string UnidadDeMedida1 { get; set; }
        public Guid? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<GrupoRecurso> GrupoRecurso { get; set; }
    }
}
