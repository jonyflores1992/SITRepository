using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Componente = new HashSet<Componente>();
            Producto = new HashSet<Producto>();
        }

        public Guid Id { get; set; }
        public string Categoria { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual ICollection<Componente> Componente { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
