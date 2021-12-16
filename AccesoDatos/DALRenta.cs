using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class DALRenta
    {
        public static bool InsertarRenta(VORenta renta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@FechaHoraRenta", SqlDbType.DateTime, renta.FechaHoraRenta));
                parametros.Add(new Parametro("@Destino", SqlDbType.VarChar, renta.Destino));
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, renta.Estado));
                parametros.Add(new Parametro("@IdAutos", SqlDbType.Int, renta.IdAutos));
                parametros.Add(new Parametro("@IdArrendatario", SqlDbType.Int, renta.IdArrendatario));
                int rows = Consulta.EjecutarSinConsulta("SP_InsertarRenta", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static bool FinalizarRenta(int idRenta, string estado)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, estado));
                int rows = Consulta.EjecutarSinConsulta("SP_FinalizarRenta", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo finalizar el regreso del vehículo");
            }
        }

        public static List<VORenta> ConsultarRentaPorEstado(string estado)
        {
            List<VORenta> rentas = new List<VORenta>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, estado));
                DataTable datosRentas = Consulta.EjecutarConLlenado("SP_ConsultarRentasPorEstado", parametros);
                foreach (DataRow registro in datosRentas.Rows)
                    rentas.Add(new VORenta(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return rentas;
        }

        public static List<VORentaExtendida> ConsultarRentasPorEstadoExtendida(string estado)
        {
            List<VORentaExtendida> lista = new List<VORentaExtendida>();
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarRentasPorEstadoExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Renta");
                foreach (DataRow registro in ds.Tables[0].Rows)
                {
                    lista.Add(new VORentaExtendida(registro));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta: " + ex.Message);
            }
        }
        
        public static VORenta ConsultarRentasPorId(int idRenta)
        {
            VORenta renta;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarRentasPorId", parametros);
                DateTime fechaHoraRenta = (DateTime)datos["FechaHoraRenta"];
                string destino = (string)datos["Destino"];
                string estado = (string)datos["Estado"];
                int idAutos = int.Parse(datos["IdAutos"].ToString());
                int idArrendatario = int.Parse(datos["IdPersona"].ToString());
                renta = new VORenta(idRenta, fechaHoraRenta, destino, estado, idAutos, idArrendatario);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return renta;
        }

        public static VORentaExtendida ConsultarRentasPorIdExtendida(int idRenta)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarRentasPorIdExtendida", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRenta", SqlDbType.Int).Value = idRenta;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Renta");
                return new VORentaExtendida(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta: " + ex.Message);
            }
        }
        
    }
}
