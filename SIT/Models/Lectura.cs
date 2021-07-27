using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Lectura
    {
        public Guid Id { get; set; }

        public string CodigoBarra { get; set; }
        public string Linea { get; set; }
        public string SerialDispositivo { get; set; }
        
        public DateTime FechaHora { get; set; }
        public DateTime FechaHoraLector { get; set; }
        public Guid IdRecurso { get; set; }
        public Guid IdGrupoRecurso { get; set; }

        public double Cantidad { get; set; }
        public Guid IdSector { get; set; }
        public Guid IdActividad { get; set; }
        public Guid IdPuntoDeControl { get; set; }

        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual GrupoRecurso IdGrupoRecursoNavigation { get; set; }
        public virtual Actividad IdActividadNavigation { get; set; }

       public virtual Sector IdSectorNavigation { get; set; }

        public virtual PuntoDeControl IdPuntoDeControlNavigation { get; set; }

    }
}
