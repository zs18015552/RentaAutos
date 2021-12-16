using AccesoDatos;
using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Frontera.Rentas
{
    public partial class AltaRentas : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoPersonas(ddlArrendatario);
                CatalogoAutos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime localDate = DateTime.Now;
                VORenta renta = new VORenta(localDate, txtDestino.Text,
                   "EN_PROCESO", int.Parse(ddlAuto.SelectedValue), int.Parse(ddlArrendatario.SelectedValue));
                BLLRenta.InsertarRenta(renta);
                LimpiarFormulario();
                Response.Redirect("RentasProceso.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de error",
                    "alert('Se registro un error al realizar la operacion." + ex.Message + "');", true);
            }
        }
        public void CatalogoPersonas(DropDownList ddl)
        {
            List<VOPersona> personas = BLLPersona.ConsultarPersonas(true);
            foreach (VOPersona persona in personas)
            {
                ddl.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }
        public void CatalogoAutos()
        {
            ddlAuto.Items.Clear();
            List<VOAuto> autos = BLLAuto.ConsultarAutos(true);
            foreach (VOAuto auto in autos)
            {
                ddlAuto.Items.Add(new ListItem(auto.Matricula, auto.IdAuto.ToString()));
            }
        }
        public void LimpiarFormulario()
        {
            txtDestino.Text = "";
            FechaHoraRenta.Value = "";
            ddlArrendatario.SelectedIndex = 0;
            ddlAuto.SelectedIndex = 0;
        }
    }
}