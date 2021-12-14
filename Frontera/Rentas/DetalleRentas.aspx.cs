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
    public partial class DetalleRentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("RentasProceso.aspx");
                else
                {
                    string idRenta = Request.QueryString["Id"].ToString();
                    VORentaExtendida renta = BLLRenta.ConsultarRentaPorIdExtendida(idRenta);
                    CargarFormulario(renta);
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLRenta.FinalizarRenta(lblIdRenta.Text);
                LimpiarFormulario();
                Response.Redirect("RentasFinalizadas.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de error",
                    "alert('Se registro un error al realizar la operacion." + ex.Message + "');", true);
            }
        }
        public void CargarFormulario(VORentaExtendida renta)
        {
            lblIdRenta.Text = renta.IdRenta.ToString();
            lblFecha.Text = renta.FechaHoraRenta.ToString();
            lblDestino.Text = renta.Destino;
            lblNombreArrendatario.Text = renta.NombreArrendatario;
            imgFotoArrendatario.ImageUrl = renta.UrlFotoArrendatario;
            lblNombreAuto.Text = renta.NombreAuto;
            imgFotoAuto.ImageUrl = renta.UrlFotoAuto;
        }
        public void LimpiarFormulario()
        {
            lblIdRenta.Text = "";
            lblFecha.Text = "";
            lblDestino.Text = "";
            lblNombreArrendatario.Text = "";
            imgFotoArrendatario.ImageUrl = "";
            lblNombreAuto.Text = "";
            imgFotoAuto.ImageUrl = "";
        }
    }
}