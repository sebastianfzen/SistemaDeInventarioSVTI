using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Areas.SyC.syc_m_estado_recurso.Controllers
{
    public class syc_m_estado_recursoController : Controller
    {
        public JsonResult Ctrl_ListaEstado_IsoCode()
        {
            Model.syc_m_ListarEstadoIsoCode listarEstado = new Model.syc_m_ListarEstadoIsoCode();

            try
            {
                listarEstado = Model.syc_m_estado_recursoDAL.mdl_Listar_Estado_IsoCode();
                return Json(listarEstado);
            }
            catch
            {
                return Json(listarEstado);
            }

        }
    }
}
