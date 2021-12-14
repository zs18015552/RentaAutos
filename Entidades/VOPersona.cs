using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VOPersona
    {
        private int idPersona;
        private string telefono;
        private string direccion;
        private string nombre;
        private string correo;
        private int? puesto;
        private bool? disponibilidad;
        private string urlFoto;

        public VOPersona(int persona, string telefono, string direccion, string nombre, string correo, int? puesto, bool? disponibilidad, string urlFoto)
        {
            this.IdPersona = persona;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Puesto = puesto;
            this.Disponibilidad = disponibilidad;
            this.UrlFoto = urlFoto;
        }
        public VOPersona(string telefono, string direccion, string nombre, string correo, int? puesto, bool? disponibilidad, string urlFoto)
        {
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Puesto = puesto;
            this.Disponibilidad = disponibilidad;
            this.UrlFoto = urlFoto;
        }
        public VOPersona(DataRow fila)
        {
            IdPersona = int.Parse(fila["IdPersona"].ToString());
            Nombre = fila["Nombre"].ToString();
            Direccion = fila["Direccion"].ToString();
            Telefono = fila["Telefono"].ToString();
            Correo = fila["Correo"].ToString();
            Puesto = int.Parse(fila["Puesto"].ToString());
            UrlFoto = fila["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
        }

        public int IdPersona
        {
            get
            {
                return idPersona;
            }

            set
            {
                idPersona = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
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

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public int? Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
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
    }
}