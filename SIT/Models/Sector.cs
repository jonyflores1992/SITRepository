using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIT.Models
{
    public partial class Sector
    {
        public Sector()
        {
            DetalleDeParada = new HashSet<DetalleDeParada>();
            GrupoRecurso = new HashSet<GrupoRecurso>();
            Recurso = new HashSet<Recurso>();
            DefectosCalidad=new HashSet<DefectosCalidad>();
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage ="*Obligatorio"),MaxLength(150,ErrorMessage ="No mas de 150 Caracteres")]
        public string Sector1 { get; set; }
        [Required(ErrorMessage ="*Obligatorio")]
        public int? Orden { get; set; }
        [Required(ErrorMessage = "*Obligatorio")]
        public Guid? Status { get; set; }
        public Guid? IdArea { get; set; }
        public string Foto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Delete { get; set; }

        public virtual Estatus StatusNavigation { get; set; }
        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<DetalleDeParada> DetalleDeParada { get; set; }
        public virtual ICollection<GrupoRecurso> GrupoRecurso { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<Lectura> Lectura { get; set; }
        public virtual ICollection<TrMovimiento> TrMovimiento { get; set; }
        public virtual ICollection<Automatizacion> Automatizacion { get; set; }
        public virtual ICollection<DefectosCalidad> DefectosCalidad { get; set; }

    }
}
