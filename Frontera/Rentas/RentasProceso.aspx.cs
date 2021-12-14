using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Rentas
{
    public partial class RentasProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void gvRentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string idRenta = gvRentas.DataKeys[index].Values["IdRenta"].ToString();
                Response.Redirect("DetalleRentas.aspx?Id=" + idRenta);
            }
        }
        public void CargarGrid()
        {
            List<VORentaExtendida> lsRenta = BLLRenta.ConsultarRentaPorEstadoExtendida("EN_PROCESO");
            gvRentas.DataSource = lsRenta;
            gvRentas.DataBind();
        }
    }
}