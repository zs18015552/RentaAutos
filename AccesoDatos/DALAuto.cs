using System;
using System.Collections.Generic;
using System.Data;
using Entidades;

namespace AccesoDatos
{
    public class DALAuto
    {
        public static bool Insertar(VOAuto auto)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, auto.Matricula));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, auto.Nombre));
                parametros.Add(new Parametro("@Cuota", SqlDbType.Decimal, auto.Cuota));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, auto.IdPersona));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, auto.UrlFoto));
                int rows = Consulta.EjecutarSinConsulta("SP_InsertarAuto", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar auto en la base de datos");
            }
        }
        public static bool Actualizar(VOAuto auto)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, auto.IdAuto));
                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, auto.Matricula));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, auto.Nombre));
                parametros.Add(new Parametro("@Cuota", SqlDbType.Decimal, auto.Cuota));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, auto.IdPersona));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, auto.UrlFoto));
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, auto.Disponibilidad));
                int rows = Consulta.EjecutarSinConsulta("SP_ActualizarAuto", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo actualizar auto en la base de datos");
            }
        }

        public static bool Eliminar(int idAuto)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, idAuto));
                int rows = Consulta.EjecutarSinConsulta("SP_EliminarAuto", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos");
            }
      
        }
        public static VOAuto ConsultarAuto(int idAuto)
        {
            VOAuto auto;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, idAuto));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarAutoPorId", parametros);
                string matricula = (string)datos["Matricula"];
                string nombre = (string)datos["Nombre"];
                double cuota = double.Parse(datos["Cuota"].ToString());
                int idOwner = int.Parse(datos["IdOwner"].ToString());
                bool disponibilidad = bool.Parse(datos["Disponibilidad"].ToString());
                string urlFoto = (string)datos["UrlFoto"];
                auto = new VOAuto(idAuto, matricula, nombre, cuota, idOwner, urlFoto, disponibilidad);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return auto;
        }
        public static List<VOAuto> ConsultarAutos(bool? disponibilidad)
        {
            List<VOAuto> autos = new List<VOAuto>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                DataTable datosBarcos = Consulta.EjecutarConLlenado("SP_ConsultarAutos", parametros);
                foreach (DataRow registro in datosBarcos.Rows)
                    autos.Add(new VOAuto(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar los autos en la base de datos");
            }
            return autos;
        }
        public static List<VOAuto> ConsultarAutosPorOwner(int idOwner, bool? disponibilidad)
        {
            List<VOAuto> barcos = new List<VOAuto>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, idOwner));
                DataTable datosBarcos = Consulta.EjecutarConLlenado("SP_ConsultarAutosPorOwner", parametros);
                foreach (DataRow registro in datosBarcos.Rows)
                    barcos.Add(new VOAuto(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return barcos;
        }
    }
}