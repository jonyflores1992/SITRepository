using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Models
{
    public partial class Automatizacion
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid? IdSector { get; set; }
  

        public virtual Sector IdSectorNavigation { get; set; }
    }
}
