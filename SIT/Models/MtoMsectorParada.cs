using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class MtoMsectorParada
    {
        public Guid? IdSector { get; set; }
        public Guid? IdMotivoParada { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual MotivoDeParada IdMotivoParadaNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
    }
}
