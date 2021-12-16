using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class BLLPersona
    {
        public static void Insertar(VOPersona persona)
        {
            try
            {
                DALPersona.Insertar(persona);
            }
            catch
            {
                throw new ArgumentException("No se pudo insertar el dato");
            }
        }
        public static void Eliminar(string idPersona)
        {
            try
            {
                DALPersona.EliminarPersona(int.Parse(idPersona));
            }
            catch
            {
                throw new ArgumentException("No se pudo eliminar el dato");
            }
        }
        public static void Actualizar(VOPersona persona)
        {
            try
            {
                DALPersona.Actualizar(persona);
            }
            catch
            {
                throw new ArgumentException("No se pudo actualizar el dato");
            }
        }

        public static VOPersona ConsultarPersonaPorId(string idPersona)
        {
            try
            {
                return DALPersona.ConsultarPersonaPorId(int.Parse(idPersona));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de persona");
            }
        }
        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            try
            {
                return DALPersona.ConsultarPersonas(disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de persona");
            }
        }
    }
}
