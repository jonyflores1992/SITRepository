using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace SIT.Models
{
    public partial class DefectosCalidad
    {
         public Guid Id { get; set; }
        [Required(ErrorMessage ="Este Campo es requerido")]
        [DisplayName("Sector")]
        public Guid? IdSector { get; set; }
        public Guid? IdgrupoRecurso { get; set; }
        public Guid? IdRecurso { get; set; }
        public Guid? IdProducto { get; set; }
        public Guid? IdComponente { get; set; }
        public string Codigo { get; set; }
        public string Defecto { get; set; }
        public Guid? Status { get; set; }
        public string DescripcionDefecto { get; set; }
        [NotMapped]
        public List<Sector> sectorCollection { get; set; }
        [NotMapped]
        public List<Producto> productoCollection { get; set; }
        
        public virtual Estatus StatusNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual GrupoRecurso IdgruporecursoNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
        public virtual Recurso IdrecurosNavigation { get; set; }
        public virtual Componente IdcomponenteNavigation { get; set; }

    }
}
