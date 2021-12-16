using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOAuto
    {

        private int idAuto;
        private string matricula;
        private string nombre;
        private double? cuota;
        private string urlFoto;
        private bool? disponibilidad;

        public VOAuto(int idAutos, string matricula, string nombre, double? cuota, string urlFoto, bool? disponibilidad)
        {
            this.IdAuto = idAutos;
            this.Matricula = matricula;
            this.Nombre = nombre;
            this.Cuota = cuota;
            this.UrlFoto = urlFoto;
            this.Disponibilidad = disponibilidad;
        }
        public VOAuto(string matricula, string nombre, double? cuota, string urlFoto, bool? disponibilidad)
        {
            this.Matricula = matricula;
            this.Nombre = nombre;
            this.Cuota = cuota;
            this.UrlFoto = urlFoto;
            this.Disponibilidad = disponibilidad;
        }
        public VOAuto(DataRow fila)
        {
            IdAuto = int.Parse(fila["IdAutos"].ToString());
            this.Matricula = fila["Matricula"].ToString();
            this.Nombre = fila["Nombre"].ToString();
            this.Cuota = double.Parse(fila["Cuota"].ToString());
            this.UrlFoto = fila["UrlFoto"].ToString();
            this.Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
        }
        public int IdAuto
        {
            get
            {
                return idAuto;
            }

            set
            {
                idAuto = value;
            }
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }


        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public double? Cuota
        {
            get
            {
                return cuota;
            }

            set
            {
                cuota = value;
            }
        }

        public string UrlFoto
        {
            get
            {
                return urlFoto;
            }

            set
            {
                urlFoto = value;
            }
        }

        public bool? Disponibilidad
        {
            get
            {
                return disponibilidad;
            }

            set
            {
                disponibilidad = value;
            }
        }
    }
}
