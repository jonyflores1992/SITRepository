using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Actividad = new HashSet<Actividad>();
            Componente = new HashSet<Componente>();
            DefectosCalidad = new HashSet<DefectosCalidad>();
        }

        public Guid Id { get; set; }
        public string Producto1 { get; set; }
        public Guid? Status { get; set; }
        public Guid? IdCategoria { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual CategoriaProducto IdCategoriaNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<Componente> Componente { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }

    }
}
