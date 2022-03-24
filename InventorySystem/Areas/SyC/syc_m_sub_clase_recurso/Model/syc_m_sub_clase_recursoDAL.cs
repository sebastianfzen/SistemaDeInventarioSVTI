using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Areas.SyC.syc_m_clase_recurso.Model
{
    public class syc_m_sub_clase_recursoDAL
    {
        public static syc_m_ListarSubClaseRecursoIsoCode mdl_Listar_Sub_Clase_Recurso()
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_sub_clase_recursoIsoCodeDTO subrecursoIsoCode;
            syc_m_ListarSubClaseRecursoIsoCode listar = new syc_m_ListarSubClaseRecursoIsoCode();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_m_sub_clase_recurso";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        subrecursoIsoCode = new syc_m_sub_clase_recursoIsoCodeDTO();

                        subrecursoIsoCode.Cor_sub_clase_recurso = Convert.IsDBNull(row["cor_sub_clase_recurso"]) ? 0 : Convert.ToInt32(row["cor_sub_clase_recurso"]);
                        subrecursoIsoCode.Sbc_descripcion = Convert.IsDBNull(row["sbc_descripcion"]) ? string.Empty : Convert.ToString(row["sbc_descripcion"]);

                        listar.listar_recurso.Add(subrecursoIsoCode);

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