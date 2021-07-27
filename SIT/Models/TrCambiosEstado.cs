using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class TrCambiosEstado
    {
        public Guid Id { get; set; }
        public Guid? IdEstadoInicial { get; set; }
        public Guid? IdEstadoFinal { get; set; }
        public TimeSpan? InicioReal { get; set; }
        public TimeSpan? FinReal { get; set; }
        public float? Horas { get; set; }
        public Guid? IdTrMovimiento { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual EstadoMovimiento IdEstadoFinalNavigation { get; set; }
        public virtual EstadoMovimiento IdEstadoInicialNavigation { get; set; }
    }
}
