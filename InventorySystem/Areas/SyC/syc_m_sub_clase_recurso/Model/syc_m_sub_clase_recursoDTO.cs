using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Areas.SyC.syc_m_clase_recurso.Model
{
    public class syc_m_sub_clase_recursoDTO
    {

    }

    public class syc_m_sub_clase_recursoIsoCodeDTO
    {
        public int Cor_sub_clase_recurso { get; set; }
        public string Sbc_descripcion { get; set; }
    }

    public class syc_m_ListarSubClaseRecursoIsoCode
    {
        public List<syc_m_sub_clase_recursoIsoCodeDTO> listar_recurso = new List<syc_m_sub_clase_recursoIsoCodeDTO>();
    }

}