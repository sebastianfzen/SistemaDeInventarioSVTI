using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Areas.SyC.syc_m_estado_recurso.Model
{
    public class syc_m_estado_recursoDAL
    {
        public static syc_m_ListarEstadoIsoCode mdl_Listar_Estado_IsoCode()
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_estado_recursoIsoCode isoEstado;
            syc_m_ListarEstadoIsoCode listar = new syc_m_ListarEstadoIsoCode();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_m_estado_recurso";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        isoEstado = new syc_m_estado_recursoIsoCode();

                        isoEstado.Cod_estado_recurso = Convert.IsDBNull(row["cod_estado_recurso"]) ? 0 : Convert.ToInt32(row["cod_estado_recurso"]);
                        isoEstado.Est_descripcion = Convert.IsDBNull(row["est_descripcion"]) ? string.Empty : Convert.ToString(row["est_descripcion"]);

                        listar.listar_estado.Add(isoEstado);

                    }
                }

                return listar;

            }
            catch
            {
                return listar;
            }

        }
    }
}