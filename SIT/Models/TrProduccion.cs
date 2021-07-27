using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TrProduccion
    {
        public Guid Id { get; set; }
        public TimeSpan? PeriodoTiempoInicio { get; set; }
        public TimeSpan? PeriodoTiempoFin { get; set; }
        public TimeSpan? InicioReal { get; set; }
        public TimeSpan? FinReal { get; set; }
        public Guid? IdProducto { get; set; }
        public Guid? IdComponente { get; set; }
        public Guid? IdOperacion { get; set; }
        public float? Productiva { get; set; }
        public float? Disponibles { get; set; }
        public float? Productividad { get; set; }
        public int Cantidad { get; set; }
        public Guid? IdRecurso { get; set; }
        public Guid? IdGrupoRecurso { get; set; }
        public Guid? IdTrMovimiento { get; set; }
        public Guid? IdTipoProduccion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual TipoProduccion IdTipoProduccionNavigation { get; set; }
        public virtual GrupoRecurso IdGrupoRecursoNavigation { get; set; }
        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Recurso IdRecursoNavigation { get; set; }


        public virtual TrMovimiento IdTrMovimientoNavigation { get; set; }
    }
}
