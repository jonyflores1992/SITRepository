using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class DetalleDeParada
    {
        public Guid Id { get; set; }
        public string DetalleDeParada1 { get; set; }
        public string Codigo { get; set; }
        public Guid? IdSector { get; set; }
        public Guid IdGrupoDeRecurso { get; set; }
        public Guid? IdMotivoParada { get; set; }
        public Guid? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual GrupoRecurso IdGrupoDeRecursoNavigation { get; set; }
        public virtual MotivoDeParada IdMotivoParadaNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<TrParada> TrParada { get; set; }
        public virtual ICollection<TrMovimientosDetalle> TrMovimientosDetalle { get; set; }
     
    }
}
