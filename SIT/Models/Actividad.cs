using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Movimiento = new HashSet<Movimiento>();
            Recurso = new HashSet<Recurso>();
        }

        public Guid Id { get; set; }
        public string Actividad1 { get; set; }
        public string Codigo { get; set; }
        public Guid? IdProducto { get; set; }
        public Guid? IdComponente { get; set; }
        public Guid? IdGrupoRecurso { get; set; }
        public Guid? IdOperacion { get; set; }
        public string Instrucciones { get; set; }
        public string CodigoBarra { get; set; }
        public Guid? IdUnidadMedida { get; set; }
        public float? FactorConversion { get; set; }
        public float? Er { get; set; }
        public Guid? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual GrupoRecurso IdGrupoRecursoNavigation { get; set; }
        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual UnidadDeMedida IdUnidadMedidaNavigation { get; set; }
        public virtual Estatus StatusNavigation { get; set; }
        public virtual ICollection<Movimiento> Movimiento { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }
        public virtual ICollection<Lectura> Lectura { get; set; }
       
    }
}
