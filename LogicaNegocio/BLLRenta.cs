using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class BLLRenta
    {
        public static void InsertarRenta(VORenta renta)
        {
            try
            {
                VOPersona arrendatario = new VOPersona(renta.IdArrendatario, null, null, null, null, null, false, null);
                BLLPersona.Actualizar(arrendatario);
                VOAuto auto = new VOAuto(renta.IdAutos, null, null, null, null, null, false);
                BLLAuto.Actualizar(auto);
                DALRenta.InsertarRenta(renta);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al insertar el registro de renta");
            }
        }
        public static void FinalizarRenta(string idRenta)
        {
            try
            {
                int id = int.Parse(idRenta);
                DALRenta.FinalizarRenta(id, Enum.GetName(typeof(EstadoRenta), EstadoRenta.FINALIZADA));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al finalizar la renta");
            }
        }
        public static List<VORenta> ConsultarRentaPorEstado(string estado)
        {
            try
            {
                return DALRenta.ConsultarRentaPorEstado(estado);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta");
            }
        }
        public static List<VORentaExtendida> ConsultarRentaPorEstadoExtendida(string estado)
        {
            try
            {
                return DALRenta.ConsultarRentasPorEstadoExtendida(estado);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta");
            }
        }
        public static VORentaExtendida ConsultarRentaPorIdExtendida(string idRenta)
        {
            try
            {
                int id = int.Parse(idRenta);
                return DALRenta.ConsultarRentasPorIdExtendida(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta");
            }
        }
        public static VORenta ConsultarRentaPorId(string idRenta)
        {

            try
            {
                int id = int.Parse(idRenta);
                return DALRenta.ConsultarRentasPorId(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de renta");
            }
        }
        public enum EstadoRenta
        {
            EN_PROCESO,
            FINALIZADA
        }
    }
}
