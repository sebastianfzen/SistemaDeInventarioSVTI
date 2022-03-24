using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Areas.SyC.syc_m_recurso_tic.Model
{
    public class syc_m_filtroDAL
    {
        private syc_m_recurso_ticDAL recDAL = new syc_m_recurso_ticDAL();

        public List<syc_m_recurso_tic_IsoCodeDTO> mdl_Listar_Recursos_IsoCode(int cor)
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_recurso_tic_IsoCodeDTO iso;
            List<syc_m_recurso_tic_IsoCodeDTO> lista = new List<syc_m_recurso_tic_IsoCodeDTO>();

            //try
            //{
            o_command.Parameters.Clear();
            o_command.Connection = o_sql_conexion;
            o_command.CommandTimeout = 360;
            o_command.CommandType = CommandType.StoredProcedure;
            o_command.CommandText = "up_sxxx_syc_web_seleccionar_recurso";
            o_command.Parameters.Add(new SqlParameter("@cor_recurso_tic", cor));
            o_adapter.SelectCommand = o_command;
            o_ds.Clear();
            o_adapter.Fill(o_ds);

            if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in o_ds.Tables[0].Rows)
                {

                    iso = new syc_m_recurso_tic_IsoCodeDTO();

                    iso.Cor_recurso_tic = cor;//(Convert.IsDBNull(row["cor_recurso_tic"])) ? 0 : Convert.ToInt32(row["cor_recurso_tic"]);
                    iso.Sbc_descripcion = (Convert.IsDBNull(row["sbc_descripcion"])) ? string.Empty : Convert.ToString(row["sbc_descripcion"]);
                    iso.Rti_cantidad = (Convert.IsDBNull(row["rti_cantidad"])) ? 0 : Convert.ToInt32(row["rti_cantidad"]);
                    iso.Mar_nombre = (Convert.IsDBNull(row["mar_nombre"])) ? string.Empty : Convert.ToString(row["mar_nombre"]);
                    iso.Rti_modelo = (Convert.IsDBNull(row["rti_modelo"])) ? string.Empty : Convert.ToString(row["rti_modelo"]);
                    iso.Rti_serie = (Convert.IsDBNull(row["rti_serie"])) ? string.Empty : Convert.ToString(row["rti_serie"]);
                    iso.Est_descripcion = (Convert.IsDBNull(row["est_descripcion"])) ? string.Empty : Convert.ToString(row["est_descripcion"]);

                    lista.Add(iso);
                }
            }

            return lista;


            //catch
            //{
            //    return lista;
            //}
        }
        public List<syc_m_recurso_tic_IsoCodeDTO> mdl_filtrar_recursos(int id_equipo, int id_marca, string desc_modelo, List<int> arreglo)
        {

            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();
            if (desc_modelo.Length < 1)
            {
                desc_modelo = null;
            }
            //syc_m_recurso_tic_IsoCodeDTO iso;
            syc_cls_ListarIsoCodeDTO lista = new syc_cls_ListarIsoCodeDTO();
            List<syc_cls_SeleccionadoIsoCodeDTO> list = new List<syc_cls_SeleccionadoIsoCodeDTO>();
            List<syc_m_recurso_tic_IsoCodeDTO> l = new List<syc_m_recurso_tic_IsoCodeDTO>();
            List<syc_m_recurso_tic_IsoCodeDTO> l2 = new List<syc_m_recurso_tic_IsoCodeDTO>();
            int x = 0;
            // try
            //  {

            int xx = id_equipo;


            if (arreglo != null)
            {
                foreach (var id_estado in arreglo)
                {
                    o_command.Parameters.Clear();
                    o_command.Connection = o_sql_conexion;
                    o_command.CommandTimeout = 360;
                    o_command.CommandType = CommandType.StoredProcedure;
                    o_command.CommandText = "up_sxxx_syc_web_filtrar_recursos";
                    o_command.Parameters.Add(new SqlParameter("@id_equipo", Int32.Parse(id_equipo.ToString())));

                    o_command.Parameters.Add(new SqlParameter("@id_marca", Int32.Parse(id_marca.ToString())));

                    o_command.Parameters.AddWithValue("@desc_modelo", desc_modelo ?? Convert.DBNull);

                    o_command.Parameters.Add(new SqlParameter("@id_estado", Int32.Parse(id_estado.ToString())));
                    o_adapter.SelectCommand = o_command;
                    o_ds.Clear();
                    o_adapter.Fill(o_ds);
                    if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in o_ds.Tables[0].Rows)
                        {
                            syc_m_recurso_seleccionadoDTO listo = new syc_m_recurso_seleccionadoDTO();
                            x = (Convert.IsDBNull(row["cor_recurso_tic"])) ? 0 : Convert.ToInt32(row["cor_recurso_tic"]);


                            l = this.mdl_Listar_Recursos_IsoCode(x);
                            foreach (syc_m_recurso_tic_IsoCodeDTO item in l)
                            {
                                l2.Add(item);
                            }

                        }
                    }

                }
            }
            else
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_web_filtrar_recursos";
                o_command.Parameters.Add(new SqlParameter("@id_equipo", id_equipo));

                o_command.Parameters.Add(new SqlParameter("@id_marca", id_marca));

                o_command.Parameters.AddWithValue("@desc_modelo", desc_modelo ?? Convert.DBNull);

                o_command.Parameters.Add(new SqlParameter("@id_estado", Convert.DBNull));
                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);
                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {
                        syc_m_recurso_seleccionadoDTO listo = new syc_m_recurso_seleccionadoDTO();
                        x = (Convert.IsDBNull(row["cor_recurso_tic"])) ? 0 : Convert.ToInt32(row["cor_recurso_tic"]);


                        l = this.mdl_Listar_Recursos_IsoCode(x);
                        foreach (syc_m_recurso_tic_IsoCodeDTO item in l)
                        {
                            l2.Add(item);
                        }

                    }
                }

            }


            return l2;


        }
    }
}