using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace Frontera.Rentas
{
    public partial class RentasFinalizadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }
        public void CargarGrid()
        {
            List<VORentaExtendida> lstRenta = BLLRenta.ConsultarRentaPorEstadoExtendida("FINALIZADA");
            gvRentas.DataSource = lstRenta;
            gvRentas.DataBind();
        }
    }
}