using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class DALPersona
    {
        public static bool Insertar(VOPersona persona)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, persona.Nombre));
                parametros.Add(new Parametro("@Direccion", SqlDbType.VarChar, persona.Direccion));
                parametros.Add(new Parametro("@Telefono", SqlDbType.VarChar, persona.Telefono));
                parametros.Add(new Parametro("@Correo", SqlDbType.VarChar, persona.Correo));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, persona.UrlFoto));
                int rows = Consulta.EjecutarSinConsulta("SP_InsertarPersona", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }
        public static bool Actualizar(VOPersona persona)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdPersona", SqlDbType.Int, persona.IdPersona));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, persona.Nombre));
                parametros.Add(new Parametro("@Direccion", SqlDbType.VarChar, persona.Direccion));
                parametros.Add(new Parametro("@Telefono", SqlDbType.VarChar, persona.Telefono));
                parametros.Add(new Parametro("@Correo", SqlDbType.VarChar, persona.Correo));
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, persona.Disponibilidad));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, persona.UrlFoto));
                int rows = Consulta.EjecutarSinConsulta("SP_ActualizarPersona", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo actualizar en la base de datos");
            }
        }
        public static bool EliminarPersona(int idPersona)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdPersona", SqlDbType.Int, idPersona));
                int rows = Consulta.EjecutarSinConsulta("SP_EliminarPersona", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos");
            }
        }
        public static VOPersona ConsultarPersonaPorId(int idPersona)
        {
            VOPersona persona;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdPersona", SqlDbType.Int, idPersona));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarPersonaPorId", parametros);
                string telefono = (string)datos["Telefono"];
                string direccion = (string)datos["Direccion"];
                string nombre = (string)datos["Nombre"];
                string correo = (string)datos["Correo"];
                bool disponibilidad = bool.Parse(datos["Disponibilidad"].ToString());
                string urlFoto = (string)datos["UrlFoto"];
                persona = new VOPersona(idPersona, telefono, direccion, nombre, correo, disponibilidad, urlFoto);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return persona;
        }
   
        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            List<VOPersona> personas = new List<VOPersona>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                DataTable datosPersonas = Consulta.EjecutarConLlenado("SP_ConsultarPersonas", parametros);
                foreach (DataRow registro in datosPersonas.Rows)
                    personas.Add(new VOPersona(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return personas;
        }
    }
}
