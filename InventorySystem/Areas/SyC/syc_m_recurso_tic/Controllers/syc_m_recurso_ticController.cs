using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InventorySystem.Areas.SyC.syc_m_recurso_tic.Controllers
{
    public class syc_m_recurso_ticController : Controller
    {
        public JsonResult AgregarRecurso(int Cor_suc_clase_recurso, int Cod_marca, int Cod_persona, string Rti_modelo, string Rti_descripcion, string Rti_descripcion_corta, string Rti_num_parte, string Rti_serie, string Rti_licencia, int Rti_cantidad, string Rti_observacion, int Cod_estado_recurso, DateTime Rti_fecha_ingreso, DateTime Rti_fecha_adquisicion)
        {
            return Json(Model.syc_m_recurso_ticDAL.mdl_agregar_recurso_isoCode(Cor_suc_clase_recurso, Cod_marca, Cod_persona, Rti_modelo, Rti_descripcion, Rti_descripcion_corta, Rti_num_parte, Rti_serie, Rti_licencia, Rti_cantidad, Rti_observacion, Cod_estado_recurso, Rti_fecha_ingreso, Rti_fecha_adquisicion));
        }

        public JsonResult Ctrl_Listar_Recursos_Isocode()
        {
            Model.syc_cls_ListarIsoCodeDTO lista = new Model.syc_cls_ListarIsoCodeDTO();

            try
            {
                lista = Model.syc_m_recurso_ticDAL.mdl_Listar_Recursos_IsoCode();
                return Json(lista);
            }
            catch
            {
                return Json(lista);
            }

        }

        public JsonResult Ctrl_Listar_Recurso_SeleccionadoIsocode(int cor_recurso_tic)
        {
            Model.syc_cls_SeleccionadoIsoCodeDTO lista = new Model.syc_cls_SeleccionadoIsoCodeDTO();

            try
            {
                
                lista = Model.syc_m_recurso_ticDAL.mdl_Listar_Recurso_Seleccionado_IsoCode(cor_recurso_tic);
                return Json(lista);
                
            }
            catch
            {
                return Json(lista);
            }

        }

        public JsonResult Ctrl_Filtrar_Recursos(int id_equipo, int id_marca, string desc_modelo, List<int> arreglo)
        {

            Model.syc_m_filtroDAL lista = new Model.syc_m_filtroDAL();
            List<Model.syc_m_recurso_tic_IsoCodeDTO> l = new List<Model.syc_m_recurso_tic_IsoCodeDTO>();

            l = lista.mdl_filtrar_recursos(id_equipo, id_marca, desc_modelo, arreglo);
            return Json(l, JsonRequestBehavior.AllowGet);


        }

    }
}
