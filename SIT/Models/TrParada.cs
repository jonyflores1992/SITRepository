using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TrParada
    {
        public Guid Id { get; set; }
        public Guid? IdMotivoParada { get; set; }
        public TimeSpan? PeriodoTiempoInicio { get; set; }
        public TimeSpan? PeriodoTiempoFin { get; set; }
        public TimeSpan? InicioReal { get; set; }
        public TimeSpan? FinReal { get; set; }
        public Guid? IdDetalleDeParada { get; set; }
        public float? Horas { get; set; }
        public bool? Retroactiva { get; set; }
        public Guid? IdTrMovimiento { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual TrMovimiento IdTrMovimientoNavigation { get; set; }
        public virtual MotivoDeParada IdMotivoParadaNavigation { get; set; }

        public virtual DetalleDeParada IdDetalleDeParadaNavigation { get; set; }

    }
}
