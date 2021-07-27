using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            TrMovimiento = new HashSet<TrMovimiento>();
        }

        public Guid Id { get; set; }
        public string Movimiento1 { get; set; }
        public Guid? IdTipoMovimiento { get; set; }
        public Guid? IdActividad { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Actividad IdActividadNavigation { get; set; }
        public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; }
        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }
    }
}
