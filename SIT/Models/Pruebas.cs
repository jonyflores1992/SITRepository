using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Pruebas
    {
        public Pruebas()
        {
            Catalogo2 = new HashSet<Catalogo2>();
        }

        public Guid Id { get; set; }
        public string Prueba { get; set; }

        public virtual ICollection<Catalogo2> Catalogo2 { get; set; }
    }
}
