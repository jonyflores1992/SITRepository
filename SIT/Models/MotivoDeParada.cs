using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class MotivoDeParada
    {
        public MotivoDeParada()
        {
            DetalleDeParada = new HashSet<DetalleDeParada>();
        }

        public Guid Id { get; set; }
        public string MotivoDeParada1 { get; set; }
        public Guid? IdTipoParada { get; set; }
        public Guid? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual TipoParada IdTipoParadaNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<DetalleDeParada> DetalleDeParada { get; set; }
        public virtual ICollection<TrParada> TrParada { get; set; }
        public virtual ICollection<TrMovimientosDetalle> TrMovimientosDetalle { get; set; }
       
    }
}
