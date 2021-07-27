using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TipoProduccion
    {
        public TipoProduccion()
        {
        }

        public Guid Id { get; set; }
        public string TipoProduccion1 { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<TrMovimientosDetalle> TrMovimientosDetalle { get; set; }

       
    }
}
