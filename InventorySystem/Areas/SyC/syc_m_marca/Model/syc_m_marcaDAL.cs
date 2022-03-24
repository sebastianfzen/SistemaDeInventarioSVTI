using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Areas.SyC.Model.syc_m_marca
{
    public class syc_m_marcaDAL
    {
        public static syc_m_ListarMarcaIsoCode mdl_Listar_Marca_IsoCode()
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_marcaIsoCodeDTO isoMarca;
            syc_m_ListarMarcaIsoCode listar = new syc_m_ListarMarcaIsoCode();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_m_marca";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        isoMarca = new syc_m_marcaIsoCodeDTO();

                        isoMarca.Cod_marca = Convert.IsDBNull(row["cod_marca"]) ? 0 : Convert.ToInt32(row["cod_marca"]);
                        isoMarca.Mar_nombre = Convert.IsDBNull(row["mar_nombre"]) ? string.Empty : Convert.ToString(row["mar_nombre"]);

                        listar.lista_marca.Add(isoMarca);

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