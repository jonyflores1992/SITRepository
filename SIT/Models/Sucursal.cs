using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Area = new HashSet<Area>();
        }

        public Guid Id { get; set; }
        public string Sucursal1 { get; set; }
        public int idSinAgro { get; set; }

        public virtual ICollection<Area> Area { get; set; }
        
    }
}
