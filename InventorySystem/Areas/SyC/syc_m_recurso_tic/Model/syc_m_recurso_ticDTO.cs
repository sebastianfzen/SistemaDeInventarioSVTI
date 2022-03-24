using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Areas.SyC.syc_m_recurso_tic.Model
{
    public class syc_m_recurso_ticDTO
    {
        public int Cor_suc_clase_recurso { get; set; }
        public int Cod_marca { get; set; }
        public int Cod_persona { get; set; }
        public string Rti_modelo { get; set; }
        public string Rti_descripcion { get; set; }
        public string Rti_descripcion_corta { get; set; }
        public string Rti_num_parte { get; set; }
        public string Rti_serie { get; set; }
        public string Rti_licencia { get; set; }
        public int Rti_cantidad { get; set; }
        public string Rti_observacion { get; set; }
        public int Cod_estado_recurso { get; set; }
        public DateTime Rti_fecha_ingreso { get; set; }
        public DateTime Rti_fecha_adquisicion { get; set; }
    }

    public class syc_m_recurso_tic_IsoCodeDTO
    {
        public int Cor_recurso_tic { get; set; }
        public string Sbc_descripcion { get; set; }
        public int Rti_cantidad { get; set; }
        public string Mar_nombre { get; set; }
        public string Rti_modelo { get; set; }
        public string Rti_serie { get; set; }
        public string Est_descripcion { get; set; }

    }

    public class syc_m_recurso_seleccionadoDTO
    {
        public string Sbc_descripcion { get; set; }
        public string Mar_nombre { get; set; }
        public string Rti_modelo { get; set; }
        public string Rti_serie { get; set; }
        public DateTime Rti_fecha_ingreso { get; set; }
        public DateTime Rti_fecha_adquisicion { get; set; }
        public string Rti_descripcion { get; set; }
        public string Rti_descripcion_corta { get; set; }
        public string Est_descripcion { get; set; }
        public int Rti_cantidad { get; set; }
        public string Rti_licencia { get; set; }
        public string Rti_num_parte { get; set; }
        public string Rti_observacion { get; set; }
        public int Cod_estado_recurso { get; set; }
    }

    public class syc_cls_ListarIsoCodeDTO
    {
        public List<syc_m_recurso_tic_IsoCodeDTO> lista_iso = new List<syc_m_recurso_tic_IsoCodeDTO>();
    }

    public class syc_cls_SeleccionadoIsoCodeDTO
    {
        public List<syc_m_recurso_seleccionadoDTO> lista_iso_seleccion = new List<syc_m_recurso_seleccionadoDTO>();
    }
}