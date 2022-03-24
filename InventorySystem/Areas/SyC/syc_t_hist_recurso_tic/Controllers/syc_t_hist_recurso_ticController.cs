using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Areas.SyC.syc_t_hist_recurso_tic.Controllers
{
    public class syc_t_hist_recurso_ticController : Controller
    {
        public JsonResult Ctrl_Modificar_Estado_Recurso(int Cod_estado_recurso, int Cor_recurso_tic, string Rti_observacion)
        {
            return Json(Models.syc_t_hist_recurso_ticDAL.mdl_cambiar_estado_recursoISO(Cod_estado_recurso, Cor_recurso_tic, Rti_observacion));
        }

        public JsonResult Ctrl_Agregar_Historial_Recurso(int Cor_recurso_tic, int Cod_estado_recurso, string Htr_observacion)
        {
            return Json(Models.syc_t_hist_recurso_ticDAL.mdl_agregar_historial_recursoISO(Cor_recurso_tic, Cod_estado_recurso, Htr_observacion));
        }

        public JsonResult Ctrl_Listar_Historial_IsoCode(int cor_recurso_tic)
        {

            Models.syc_m_ListarHistorialIsoCode listarHistorial = new Models.syc_m_ListarHistorialIsoCode();

            try
            {
                listarHistorial = Models.syc_t_hist_recurso_ticDAL.mdl_Listar_Historial_IsoCode(cor_recurso_tic);
                return Json(listarHistorial);
            }
            catch
            {
                return Json(listarHistorial);
            }

        }

    }
}
