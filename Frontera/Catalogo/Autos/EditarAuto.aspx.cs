using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Autos
{
    public partial class EditarAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoOwners(ddlOwner);
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("ListaAutos.aspx");
                else
                {
                    bool disponibilidad = true;
                    string idAutos = Request.QueryString["Id"].ToString();
                    VOAuto auto = BLLAuto.ConsultarAuto(idAutos);
                    CargarFormulario(auto);
                    disponibilidad = (bool)auto.Disponibilidad;
                    if (disponibilidad)
                    {
                        lblAuto.ForeColor = System.Drawing.Color.Green;
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        lblAuto.ForeColor = System.Drawing.Color.Red;
                        btnEliminar.Visible = false;
                    }
                }
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
                VOAuto auto = new VOAuto(int.Parse(lblAuto.Text), txtMatricula.Text,
                    txtNombre.Text, double.Parse(txtCuota.Text), int.Parse(ddlOwner.SelectedValue),
                    lblUrlFoto.InnerText, null);
                BLLAuto.Actualizar(auto);
                LimpiarFormulario();
                Response.Redirect("ListaAutos.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de error",
                    "alert('Se registro un error al realizar la operacion." + ex.Message + "');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLAuto.Eliminar(lblAuto.Text);
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
            lblAuto.Text = "";
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtCuota.Text = "";
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoPersona.ImageUrl = "";
        }
        public void CargarFormulario(VOAuto auto)
        {
            lblAuto.Text = auto.IdAuto.ToString();
            txtMatricula.Text = auto.Matricula;
            txtNombre.Text = auto.Nombre;
            txtCuota.Text = auto.Cuota.ToString();
            ddlOwner.SelectedValue = auto.IdPersona.ToString();
            lblUrlFoto.InnerText = auto.UrlFoto;
            imgFotoPersona.ImageUrl = auto.UrlFoto;
        }
    }
}