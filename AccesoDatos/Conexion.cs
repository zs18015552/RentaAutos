using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Conexion
    {
        private string cadenaConexion;
        public Conexion()
        {
            Configurar();
        }

        public string CadenaConexion
        {
            get
            {
                return this.cadenaConexion;
            }
        }
        public void Configurar()
        {
            try
            {
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
                //DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al configurar la cadena de conexión");
            }
        }
    }
}
