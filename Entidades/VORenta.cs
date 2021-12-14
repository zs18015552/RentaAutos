using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class VORenta
    {
        private int idRenta;
        private DateTime fechaHoraRenta;
        private string destino;
        private string estado;
        private int idAutos;
        private int idArrendatario;

        public VORenta(int idRenta, DateTime fechaHoraRenta, string destino, string estado, int idAutos, int idArrendatario)
        {
            this.idRenta = idRenta;
            this.fechaHoraRenta = fechaHoraRenta;
            this.destino = destino;
            this.estado = estado;
            this.idAutos = idAutos;
            this.idArrendatario = idArrendatario;
        }

        public VORenta(DateTime fechaHoraRenta, string destino, string estado, int idAutos, int idArrendatario)
        {
            FechaHoraRenta = fechaHoraRenta;
            Destino = destino;
            Estado = estado;
            IdAutos = idAutos;
            IdArrendatario = idArrendatario;
        }
        public VORenta()
        {
            IdRenta = 0;
            FechaHoraRenta = DateTime.Now;
            Destino = "";
            Estado = "";
            IdAutos = 0;
            IdArrendatario = 0;
        }
        public VORenta(DataRow dr)
        {
            IdRenta = int.Parse(dr["IdRenta"].ToString()); ;
            FechaHoraRenta = DateTime.Parse(dr["FechaHoraRenta"].ToString());
            Destino = dr["Destino"].ToString(); ;
            Estado = dr["Estado"].ToString();
            IdAutos = int.Parse(dr["IdAutos"].ToString());
            IdArrendatario = int.Parse(dr["IdPersona"].ToString());
        }

        public int IdRenta
        {
            get
            {
                return idRenta;
            }

            set
            {
                idRenta = value;
            }
        }

        public DateTime FechaHoraRenta
        {
            get
            {
                return fechaHoraRenta;
            }

            set
            {
                fechaHoraRenta = value;
            }
        }

        public string Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int IdAutos
        {
            get
            {
                return idAutos;
            }

            set
            {
                idAutos = value;
            }
        }

        public int IdArrendatario
        {
            get
            {
                return idArrendatario;
            }

            set
            {
                idArrendatario = value;
            }
        }
    }
}