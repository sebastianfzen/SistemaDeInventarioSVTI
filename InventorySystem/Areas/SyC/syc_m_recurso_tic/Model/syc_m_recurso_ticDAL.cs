using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Areas.SyC.syc_m_recurso_tic.Model
{

    public class syc_m_recurso_ticDAL
    {
        public static string mdl_agregar_recurso_isoCode(int Cor_suc_clase_recurso, int Cod_marca, int Cod_persona, string Rti_modelo, string Rti_descripcion, string Rti_descripcion_corta, string Rti_num_parte, string Rti_serie, string Rti_licencia, int Rti_cantidad, string Rti_observacion, int Cod_estado_recurso, DateTime Rti_fecha_ingreso, DateTime Rti_fecha_adquisicion)
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
                o_command.CommandText = "up_xxix_syc_web_ingresar_recursos";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();

                o_command.Parameters.Add("@cor_suc_clase_recurso", SqlDbType.Int).Value = Cor_suc_clase_recurso;
                o_command.Parameters.Add("@cod_marca", SqlDbType.Int).Value = Cod_marca;
                o_command.Parameters.Add("@rti_modelo", SqlDbType.VarChar).Value = Rti_modelo;
                o_command.Parameters.Add("@rti_serie", SqlDbType.VarChar).Value = Rti_serie;
                o_command.Parameters.Add("@rti_descripcion", SqlDbType.VarChar).Value = Rti_descripcion;
                o_command.Parameters.Add("@rti_descripcion_corta", SqlDbType.VarChar).Value = Rti_descripcion_corta;
                o_command.Parameters.Add("@cod_estado_recurso", SqlDbType.Int).Value = Cod_estado_recurso;
                o_command.Parameters.Add("@rti_cantidad", SqlDbType.Int).Value = Rti_cantidad;
                o_command.Parameters.Add("@rti_licencia", SqlDbType.VarChar).Value = Rti_licencia;
                o_command.Parameters.Add("@rti_num_parte", SqlDbType.VarChar).Value = Rti_num_parte;
                o_command.Parameters.Add("@rti_observacion", SqlDbType.VarChar).Value = Rti_observacion;
                o_command.Parameters.Add("@cod_persona", SqlDbType.Int).Value = Cod_persona;
                o_command.Parameters.Add("@rti_fecha_ingreso", SqlDbType.DateTime).Value = Rti_fecha_ingreso;
                o_command.Parameters.Add("@rti_fecha_adquisicion", SqlDbType.DateTime).Value = Rti_fecha_adquisicion;

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

        public static syc_cls_ListarIsoCodeDTO mdl_Listar_Recursos_IsoCode()
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_recurso_tic_IsoCodeDTO iso;
            syc_cls_ListarIsoCodeDTO lista = new syc_cls_ListarIsoCodeDTO();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_web_listar_recursos";

                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        iso = new syc_m_recurso_tic_IsoCodeDTO();

                        iso.Cor_recurso_tic = (Convert.IsDBNull(row["cor_recurso_tic"])) ? 0 : Convert.ToInt32(row["cor_recurso_tic"]);
                        iso.Sbc_descripcion = (Convert.IsDBNull(row["sbc_descripcion"])) ? string.Empty : Convert.ToString(row["sbc_descripcion"]);
                        iso.Rti_cantidad = (Convert.IsDBNull(row["rti_cantidad"])) ? 0 : Convert.ToInt32(row["rti_cantidad"]);
                        iso.Mar_nombre = (Convert.IsDBNull(row["mar_nombre"])) ? string.Empty : Convert.ToString(row["mar_nombre"]);
                        iso.Rti_modelo = (Convert.IsDBNull(row["rti_modelo"])) ? string.Empty : Convert.ToString(row["rti_modelo"]);
                        iso.Rti_serie = (Convert.IsDBNull(row["rti_serie"])) ? string.Empty : Convert.ToString(row["rti_serie"]);
                        iso.Est_descripcion = (Convert.IsDBNull(row["est_descripcion"])) ? string.Empty : Convert.ToString(row["est_descripcion"]);

                        lista.lista_iso.Add(iso);
                    }
                }

                return lista;

            }
            catch
            {
                return lista;
            }
        }

        public static syc_cls_SeleccionadoIsoCodeDTO mdl_Listar_Recurso_Seleccionado_IsoCode(int cor_recurso_tic)
        {
            SqlConnection o_sql_conexion = new SqlConnection("Server=SVTIBUILDSQL; DataBase=SyC; User Id=usuariopractica; Password=Usr#D3s4.8");
            SqlDataAdapter o_adapter = new SqlDataAdapter();
            SqlCommand o_command = new SqlCommand();
            DataSet o_ds = new DataSet();

            syc_m_recurso_seleccionadoDTO iso;
            syc_cls_SeleccionadoIsoCodeDTO lista = new syc_cls_SeleccionadoIsoCodeDTO();

            try
            {
                o_command.Parameters.Clear();
                o_command.Connection = o_sql_conexion;
                o_command.CommandTimeout = 360;
                o_command.CommandType = CommandType.StoredProcedure;
                o_command.CommandText = "up_sxxx_syc_web_seleccionar_recurso";
                o_command.Parameters.Add(new SqlParameter("@cor_recurso_tic", cor_recurso_tic ));
                o_adapter.SelectCommand = o_command;
                o_ds.Clear();
                o_adapter.Fill(o_ds);

                if (o_ds.Tables.Count > 0 && o_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in o_ds.Tables[0].Rows)
                    {

                        iso = new syc_m_recurso_seleccionadoDTO();

                        iso.Sbc_descripcion = (Convert.IsDBNull(row["sbc_descripcion"])) ? string.Empty : Convert.ToString(row["sbc_descripcion"]);
                        iso.Cod_estado_recurso = (Convert.IsDBNull(row["cod_estado_recurso"])) ? 0 : Convert.ToInt32(row["cod_estado_recurso"]);
                        iso.Mar_nombre = (Convert.IsDBNull(row["mar_nombre"])) ? string.Empty : Convert.ToString(row["mar_nombre"]);
                        iso.Rti_modelo = (Convert.IsDBNull(row["rti_modelo"])) ? string.Empty : Convert.ToString(row["rti_modelo"]);
                        iso.Rti_serie = (Convert.IsDBNull(row["rti_serie"])) ? string.Empty : Convert.ToString(row["rti_serie"]);
                        iso.Rti_fecha_ingreso = (Convert.IsDBNull(row["rti_fecha_ingreso"])) ? DateTime.Today : Convert.ToDateTime(row["rti_fecha_ingreso"]);
                        iso.Rti_fecha_adquisicion = (Convert.IsDBNull(row["rti_fecha_adquisicion"])) ? DateTime.Today : Convert.ToDateTime(row["rti_fecha_adquisicion"]);
                        iso.Rti_descripcion = (Convert.IsDBNull(row["rti_descripcion"])) ? string.Empty : Convert.ToString(row["rti_descripcion"]);
                        iso.Rti_descripcion_corta = (Convert.IsDBNull(row["rti_descripcion_corta"])) ? string.Empty : Convert.ToString(row["rti_descripcion_corta"]);
                        iso.Est_descripcion = (Convert.IsDBNull(row["est_descripcion"])) ? string.Empty : Convert.ToString(row["est_descripcion"]);
                        iso.Rti_cantidad = (Convert.IsDBNull(row["rti_cantidad"])) ? 0 : Convert.ToInt32(row["rti_cantidad"]);
                        iso.Rti_licencia = (Convert.IsDBNull(row["rti_licencia"])) ? string.Empty : Convert.ToString(row["rti_licencia"]);
                        iso.Rti_num_parte = (Convert.IsDBNull(row["rti_num_parte"])) ? string.Empty : Convert.ToString(row["rti_num_parte"]);
                        iso.Rti_observacion = (Convert.IsDBNull(row["rti_observacion"])) ? string.Empty : Convert.ToString(row["rti_observacion"]);

                        lista.lista_iso_seleccion.Add(iso);
                    }
                }

                return lista;

            }
            catch
            {
                return lista;
            }
        }



    }
}