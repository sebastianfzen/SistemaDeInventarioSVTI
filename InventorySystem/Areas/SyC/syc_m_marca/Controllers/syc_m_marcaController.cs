using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Areas.SyC.syc_m_marca.Controllers
{
    public class syc_m_marcaController : Controller
    {
        public JsonResult Ctrl_ListarMarca_IsoCode()
        {
            Model.syc_m_marca.syc_m_ListarMarcaIsoCode listarmarca = new Model.syc_m_marca.syc_m_ListarMarcaIsoCode();

            try
            {
                listarmarca = Model.syc_m_marca.syc_m_marcaDAL.mdl_Listar_Marca_IsoCode();
                return Json(listarmarca);
            }
            catch
            {
                return Json(listarmarca);
            }

        }
    }
}
