using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Componente
    {
        public Componente()
        {
            Actividad = new HashSet<Actividad>();
            DefectosCalidad= new HashSet<DefectosCalidad>();
        }

        public Guid Id { get; set; }
        public string Componente1 { get; set; }
        public Guid? IdProducto { get; set; }
        public float? Kilogramos { get; set; }
        public Guid? Status { get; set; }
        public string Descripcion { get; set; }
        public Guid? IdCategoria { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual CategoriaProducto IdCategoriaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<TrProduccion> TrProduccion { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }

    }
}
