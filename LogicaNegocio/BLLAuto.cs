using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;


namespace LogicaNegocio
{
    public class BLLAuto
    {
        public static void Insertar(VOAuto auto)
        {
            try
            {
                DALAuto.Insertar(auto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al insertar el registro");
            }
        }
        public static void Actualizar(VOAuto auto)
        {
            try
            {
                DALAuto.Actualizar(auto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al insertar el registro");
            }
        }
        public static void Eliminar(string idAutos)
        {
            try
            {
                DALAuto.Eliminar(int.Parse(idAutos));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al eliminar el registro");
            }
        }
        public static VOAuto ConsultarAuto(string idAutos)
        {
            VOAuto auto = null;
            try
            {
                auto = DALAuto.ConsultarAuto(int.Parse(idAutos));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro");
            }
            return auto;
        }
        public static List<VOAuto> ConsultarAutos(bool? disponibilidad)
        {
            List<VOAuto> autos = null;
            try
            {
                autos = DALAuto.ConsultarAutos(disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro");
            }
            return autos;
        }
        public static List<VOAuto> ConsultarAutosPorOwner(string idOwner, bool? disponibilidad)
        {
            List<VOAuto> autos = null;
            try
            {
                autos = DALAuto.ConsultarAutosPorOwner(int.Parse(idOwner), disponibilidad);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro");
            }
            return autos;
        }
    }
}
