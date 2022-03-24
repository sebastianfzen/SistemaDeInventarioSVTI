using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Areas.SyC.syc_m_estado_recurso.Model
{
    public class syc_m_estado_recursoDTO
    {
    }

    public class syc_m_estado_recursoIsoCode
    {
        public int Cod_estado_recurso { get; set; }
        public string Est_descripcion { get; set; }
    }

    public class syc_m_ListarEstadoIsoCode
    {
        public List<syc_m_estado_recursoIsoCode> listar_estado = new List<syc_m_estado_recursoIsoCode>();
    }

}