using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Area
    {
        public Guid Id { get; set; }
        public string Area1 { get; set; }
        public Guid? Status { get; set; }
        public Guid? IdSucursal { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Estatus StatusNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }

        public virtual ICollection<Sector> Sector { get; set; }

   
    }
}
