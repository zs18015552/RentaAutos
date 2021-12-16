using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VORentaExtendida : VORenta
    {
        private string nombreArrendatario;
        private string urlFotoArrendatario;
        private string nombreAuto;
        private string urlFotoAuto;

        public VORentaExtendida(string nombreArrendatario, string urlFotoArrendatario, string nombreAuto, string urlFotoAuto)
        {
            NombreArrendatario = nombreArrendatario;
            UrlFotoArrendatario = urlFotoArrendatario;
            NombreAuto = nombreAuto;
            UrlFotoAuto = urlFotoAuto;
        }

        public VORentaExtendida() : base()
        {
            NombreArrendatario = "";
            UrlFotoArrendatario = "";
            NombreAuto = "";
            UrlFotoAuto = "";
        }

        public VORentaExtendida(DataRow dr) : base(dr)
        {
            NombreArrendatario = dr["NombreArrendatario"].ToString();
            UrlFotoArrendatario = dr["UrlFotoArrendatario"].ToString();
            NombreAuto = dr["NombreAuto"].ToString();
            UrlFotoAuto = dr["UrlFotoAuto"].ToString();
        }

        public VORentaExtendida(int idRenta, DateTime fechaHoraRenta, string destino, string estado, int idAutos, int idArrendatario, string nombreBarco, string urlFotoBarco, string nombreCapitan, string urlFotoCapitan) : base(idRenta, fechaHoraRenta, destino, estado, idAutos, idArrendatario)
        {
            NombreAuto = nombreBarco;
            UrlFotoAuto = urlFotoBarco;
            NombreArrendatario = nombreCapitan;
            UrlFotoArrendatario = urlFotoCapitan;
        }

        public string NombreArrendatario
        {
            get
            {
                return nombreArrendatario;
            }

            set
            {
                nombreArrendatario = value;
            }
        }

        public string UrlFotoArrendatario
        {
            get
            {
                return urlFotoArrendatario;
            }

            set
            {
                urlFotoArrendatario = value;
            }
        }

        public string NombreAuto
        {
            get
            {
                return nombreAuto;
            }

            set
            {
                nombreAuto = value;
            }
        }

        public string UrlFotoAuto
        {
            get
            {
                return urlFotoAuto;
            }

            set
            {
                urlFotoAuto = value;
            }
        }
    }
}