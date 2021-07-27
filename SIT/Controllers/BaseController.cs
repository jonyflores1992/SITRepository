using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIT.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SIT.Controllers
{
    
    //public enum NotificationPosition
    //{
    //    Top,
    //    TopStart,
    //    TopEnd,
    //    Center,
    //    CenterStart,
    //    CenterEnd,
    //    Bottom,
    //    BottomStart,
    //    BottomEnd
    //}
    public class BaseController : Controller
    {
        //string pos = "";
        //public void BasicNotification(string msj, NotificationType type, string title = "")
        //{
        //    TempData["notification"] = $"Swal.fire('{title}','{msj}', '{type.ToString().ToLower()}')";
        //}
        //// el parametro de timer con valor 0 se deshabilita
        //public void CustomNotification(string msj, NotificationType type, NotificationPosition position, string title = "", bool showConfirmButton = false, int timer = 2000, bool toast = true)
        //{
        //    SetPosition(position.ToString());

        //    TempData["notification"] = "Swal.fire({customClass:{confirmButton:'btn btn-primary',cancelButton:'btn btn-danger'},position:'" + pos + "',type:'" + type.ToString().ToLower() +
        //        "',title:'" + title + "',text: '" + msj + "',showConfirmButton: " + showConfirmButton.ToString().ToLower() + ",confirmButtonColor: '#4F0DA2',toast: "
        //        + toast.ToString().ToLower() + ",timer: " + timer + "}); ";
        //}
        //private void SetPosition(string position)
        //{
        //    if (position == "Top") pos = "top";
        //    if (position == "TopStart") pos = "top-start";
        //    if (position == "TopEnd") pos = "top-end";
        //    if (position == "Center") pos = "center";
        //    if (position == "CenterStart") pos = "center-start";
        //    if (position == "CenterEnd") pos = "center-end";
        //    if (position == "Bottom") pos = "bottom";
        //    if (position == "BottomStart") pos = "bottom-start";
        //    if (position == "BottomEnd") pos = "bottom-end";
        //}
        public void Notify(string message, string title = "Notificacion Registro",
                                    NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }

        public List<object> retornarMainMenu()
        {
            List<object> mainMenuItems = new List<object>();
            mainMenuItems.Add(new
            {
                text = "Registros",
                iconCss = "icon-tag icon",

            //
                items = new List<object>()
                    {
                        new { text = "Sucursales",  url ="https://localhost:44389/Sucursals/index" },
                        new { text = "Areas",  url ="https://localhost:44389/Areas/index" },
                        new { text = "Sectores",  url ="https://localhost:44389/Sectors/index" },
                        new { text = "Grupos de recursos",  url ="https://localhost:44389/GrupoRecursoes/index" },
                        new { text = "Recursos",  url ="https://localhost:44389/Recursoes/index" },
                        new { text = "Productos",  url ="https://localhost:44389/Productoes/index" },
                        new { text = "Componente",  url ="https://localhost:44389/Componentes/index" },
                        new { text = "Operaciones",  url ="https://localhost:44389/Operacions/index" },
                        new { text = "Puntos de control",  url ="https://localhost:44389/PuntoDeControls/index" },
                        new { text = "Lista de Actividades",  url ="https://localhost:44389/Actividads/index" },
                        new { text = "Motivos de paradas",  url ="https://localhost:44389/MotivoDeParadas/index" },
                        new { text = "Detalle de paradas",  url ="https://localhost:44389/DetalleDeParadas/index" },
                        new { text = "Lineas de producción",  url ="https://localhost:44389/Lineas/index" }

                    }
            });
            mainMenuItems.Add(new
            {
                text = "Movimientos",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Movimiento Manual",  url ="https://localhost:44389/TrMovimientosManual/index" },
                        new { text = "Movimiento Online",  url ="https://localhost:44389/TrMovimientoOnline/index" },
                        new { text = "Panel de paradas",  url ="https://localhost:44389/TrParadums/index" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Calidad",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Defectos",url ="https://localhost:44389/DefectosCalidads/index" },
                        new { text = "Control de calidad" },
                        new { text = "Resumen de calidad" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Resumen Gerencial",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Resumen Gerencial " },
                        new { text = "Monitor" },
                        new { text = "Vista administrativa" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Reportes",
                iconCss = "icon-bookmark icon",
                items = new List<object>()
                    {
                        new { text = "Producción" },
                        new { text = "Perdidas" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Mantenimiento de datos",
                iconCss = "icon-eye icon",
                items = new List<object>()
                    {
                        new { text = "Estado Movimientos",  url ="https://localhost:44389/EstadoMovimientoes/index" },
                        new { text = "Estatus",  url ="https://localhost:44389/Estatus/index"  },
                        new { text = "Unidad de medida", url ="https://localhost:44389/UnidadDeMedidas/index"  },
                        new { text = "Categorias", url ="https://localhost:44389/CategoriaProductoes/index"  },
                        new { text = "Tipo de paradas", url ="https://localhost:44389/TipoParadas/index"  },
                }
            });
            mainMenuItems.Add(new
            {
                text = "Configuraciones",
                iconCss = "icon-eye icon",
                items = new List<object>()
                    {
                        new { text = "Permisos" },
                        new { text = "Perfil de usuario" },
                        new { text = "Usuarios" },
                        new { text = "Parametros" },
                        new { text = "Dispositivos Moviles" }
                    }
            });


            return ViewBag.mainMenuItems = mainMenuItems;

        }
        public List<object> retornarUserMenuItems()
        {

            List<object> AccountMenuItems = new List<object>();
            AccountMenuItems.Add(new
            {
                text = "Cuenta",
                items = new List<object>()
                    {
                        new { text = "Perfil" },
                        new { text = "Cerrar sesión" }
                    }
            });
            ViewBag.AccountMenuItems = AccountMenuItems;
            return ViewBag.AccountMenuItems = AccountMenuItems;
        }
    }
}
