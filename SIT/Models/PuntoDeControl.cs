using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Models
{
    public partial class PuntoDeControl
    {
        public Guid Id { get; set; }
        public string PuntoDeControl1 { get; set; }
        public string DescripcionUbicacion { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }

        public Guid? IdOperacion { get; set; }



        public virtual Operacion IdOperacionNavigation { get; set; }
       

        //
      public virtual ICollection<Lectura> Lectura { get; set; }


    }
}
