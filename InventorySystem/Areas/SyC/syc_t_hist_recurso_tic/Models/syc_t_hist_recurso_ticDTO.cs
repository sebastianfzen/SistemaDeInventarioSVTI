using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Areas.SyC.syc_t_hist_recurso_tic.Models
{
    public class syc_t_hist_recurso_ticDTO
    {
        public int Cor_recurso_tic { get; set; }
        public int Cod_persona { get; set; }
        public int Cod_estado_recurso { get; set; }
        public DateTime Hrt_fecha { get; set; }
        public string Hrt_observacion { get; set; }
        public string Est_descripcion { get; set; }
    }

    public class syc_m_ListarHistorialIsoCode
    {
        public List<syc_t_hist_recurso_ticDTO> lista_historial = new List<syc_t_hist_recurso_ticDTO>();
    }

}