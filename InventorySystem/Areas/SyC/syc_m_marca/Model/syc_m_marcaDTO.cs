using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Areas.SyC.Model.syc_m_marca
{
    public class syc_m_marcaDTO
    {
    }

    public class syc_m_marcaIsoCodeDTO
    {
        public int Cod_marca { get; set; }
        public string Mar_nombre { get; set; }
    }

    public class syc_m_ListarMarcaIsoCode
    {
        public List<syc_m_marcaIsoCodeDTO> lista_marca = new List<syc_m_marcaIsoCodeDTO>();
    }

}