using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Areas.SyC.syc_m_clase_recurso.Controllers
{
    public class syc_m_sub_clase_recursoController : Controller
    {
        public JsonResult Ctrl_ListaSubClaseRecurso_IsoCode()
        {
            Model.syc_m_ListarSubClaseRecursoIsoCode listarSubClaseRecurso = new Model.syc_m_ListarSubClaseRecursoIsoCode();
            try
            {
                listarSubClaseRecurso = Model.syc_m_sub_clase_recursoDAL.mdl_Listar_Sub_Clase_Recurso();
                return Json(listarSubClaseRecurso);
            }
            catch
            {
                return Json(listarSubClaseRecurso);
            }
        }
    }
}
