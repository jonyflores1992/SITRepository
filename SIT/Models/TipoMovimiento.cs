using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Movimiento = new HashSet<Movimiento>();
        }

        public Guid Id { get; set; }
        public string TipoMovimiento1 { get; set; }
        public string Foto { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual ICollection<Movimiento> Movimiento { get; set; }
        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }

    }
}
