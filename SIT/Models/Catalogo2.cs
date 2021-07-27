using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Catalogo2
    {
        public Guid Id { get; set; }
        public Guid? IdPruebas { get; set; }
        public string Texto { get; set; }

        public virtual Pruebas IdPruebasNavigation { get; set; }
    }
}
