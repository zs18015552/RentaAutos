using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.IO;

namespace Frontera.Catalogo.Autos
{
    public partial class AltaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoOwners(ddlOwner);
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (SubeImagen.Value != "")
            {
                string fileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    lblUrlFoto.InnerText = "Archivo no valido";
                }
                else
                {
                    string path = Server.MapPath("~/Imagenes/Autos/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Autos/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoPersona.ImageUrl = url;
                    btnGuardar.Visible = true;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOAuto barco = new VOAuto(txtMatricula.Text, txtNombre.Text,
                    Convert.ToDouble(txtCuota.Text), Convert.ToInt32(ddlOwner.SelectedValue),
                    lblUrlFoto.InnerText, true);
                BLLAuto.Insertar(barco);
                LimpiarFormulario();
                Response.Redirect("ListaAutos.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de error",
                    "alert('Se registro un error al realizar la operacion." + ex.Message + "');", true);
            }
        }
        public void CatalogoOwners(DropDownList ddl)
        {
            int[] puesto = { 1 };
            List<VOPersona> owners = BLLPersona.CatalogoPersona(puesto, true);
            foreach (VOPersona persona in owners)
            {
                ddl.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString()));
            }
        }
        public void LimpiarFormulario()
        {
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtCuota.Text = "";
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoPersona.ImageUrl = "";
            btnGuardar.Visible = false;
        }
    }
}