using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Models
{
    public partial class TrMovimientosDetalle
    {

        public Guid Id { get; set; }
        public TimeSpan? PeriodoTiempoInicio { get; set; }
        public TimeSpan? PeriodoTiempoFin { get; set; }
        public TimeSpan? InicioReal { get; set; }
        public TimeSpan? FinReal { get; set; }
        public float? Disponibles { get; set; }
        public Guid? IdMotivoParada { get; set; }
        public Guid? IdDetalleDeParada { get; set; }
        public float? Productiva { get; set; }
        public float? Disponible { get; set; }
        public float? Productividad { get; set; }
        public Guid? IdTrMovimiento { get; set; }
        public Guid? IdTipoProduccion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Cantidad { get; set; }
        public virtual TrMovimiento IdTrMovimientoNavigation { get; set; }
        public virtual MotivoDeParada IdMotivoParadaNavigation { get; set; }
        public virtual TipoProduccion IdTipoProduccionNavigation { get; set; }

        public virtual DetalleDeParada IdDetalleDeParadaNavigation { get; set; }
    }
}
