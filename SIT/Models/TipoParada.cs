using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TipoParada
    {
        public TipoParada()
        {
            MotivoDeParada = new HashSet<MotivoDeParada>();
        }

        public string TipoParada1 { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<MotivoDeParada> MotivoDeParada { get; set; }
    }
}
