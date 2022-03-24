using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Areas.SyC.syc_t_hist_recurso_tic.Models
{
    public class syc_t_hist_recurso_ticDAL
    {
        public static string mdl_cambiar_estado_recursoISO(int Cod_estado_recurso, int Cor_recurso_tic, string Rti_observacion)
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            try
            {

                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_xuxx_syc_m_recurso_tic";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();

                
                o_command.Parameters.Add("@cor_recurso_tic", SqlDbType.Int).Value = Cor_recurso_tic;
                o_command.Parameters.Add("@cod_estado_recurso", SqlDbType.Int).Value = Cod_estado_recurso;
                o_command.Parameters.Add("@rti_observacion", SqlDbType.VarChar).Value = Rti_observacion;

                o_command.Connection.Open();

                o_command.ExecuteNonQuery();

                o_command.Connection.Close();

                return "ok";

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return e.Message;
            }

        }

        public static string mdl_agregar_historial_recursoISO(int Cor_recurso_tic, int Cod_estado_recurso, string Htr_observacion)
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            try
            {

                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_xxix_web_historial_recurso";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();

                o_command.Parameters.Add("@cor_recurso_tic", SqlDbType.Int).Value = Cor_recurso_tic;
                o_command.Parameters.Add("@cod_persona", SqlDbType.Int).Value = 0;
                o_command.Parameters.Add("@cod_estado_recurso", SqlDbType.Int).Value = Cod_estado_recurso;
                o_command.Parameters.Add("@hrt_observacion", SqlDbType.VarChar).Value = Htr_observacion;

                o_command.Connection.Open();

                o_command.ExecuteNonQuery();

                o_command.Connection.Close();

                return "ok";

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return e.Message;
            }

        }

        public static syc_m_ListarHistorialIsoCode mdl_Listar_Historial_IsoCode(int cor_recurso_tic)
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_t_hist_recurso_ticDTO isoHistorial;
            syc_m_ListarHistorialIsoCode listar = new syc_m_ListarHistorialIsoCode();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_web_listar_historial_recurso";
                o_command.Parameters.Add(new SqlParameter("@cor_recurso_tic", cor_recurso_tic));

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        isoHistorial = new syc_t_hist_recurso_ticDTO();

                        isoHistorial.Est_descripcion = Convert.IsDBNull(row["est_descripcion"]) ? string.Empty : Convert.ToString(row["est_descripcion"]);
                        isoHistorial.Hrt_fecha = (Convert.IsDBNull(row["hrt_fecha"])) ? DateTime.Today : Convert.ToDateTime(row["hrt_fecha"]);
                        isoHistorial.Hrt_observacion = Convert.IsDBNull(row["hrt_observacion"]) ? string.Empty : Convert.ToString(row["hrt_observacion"]);

                        listar.lista_historial.Add(isoHistorial);

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