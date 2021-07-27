using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Models
{
    public class FileUpload

    {
        public Guid Id { get; set; }
        public string Sector1 { get; set; }
        public int? Orden { get; set; }
        public Guid? Status { get; set; }
        public Guid? IdArea { get; set; }
        public IFormFile rutaFoto { get; set; }
        public string Foto { get; set; }
        public string Grupo { get; set; }
        public Guid? IdSector { get; set; }
        public Guid? IdUnidadMedida { get; set; }
        public string Nombre { get; set; }
        public Guid? IdGrupoRecursoPrincipal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? ProductividadDeseada { get; set; }
        public float? Costo { get; set; }
        public string CodigoBarra { get; set; }
        public string Codigo { get; set; }
        public bool? TurnoNoche { get; set; }
        public Guid? IdActividad { get; set; }


    }
}
