using Frontera.Utilerias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Frontera.Utilerias.Enumeradores;
using Entidades;
using LogicaNegocio;

namespace Frontera.Catalogo.Personas
{
    public partial class EditarPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Enumeradores.EnumToListBox(typeof(PuestoPersona), ddlPuesto, true);

                if (Request.QueryString["id"] == null)
                    Response.Redirect("ListaPersonas.aspx");
                else
                {
                    bool disponibilidad = true;
                    string idPersona = Request.QueryString["id"].ToString();
                    VOPersona persona = BLLPersona.ConsultarPersonaPorId(idPersona);
                    CargarFormulario(persona);
                    disponibilidad = (bool)persona.Disponibilidad;
                    if (disponibilidad)
                    {
                        lblIdPersona.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblIdPersona.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOPersona persona = new VOPersona(int.Parse(lblIdPersona.Text), txtTelefono.Text, txtDireccion.Text, txtNombre.Text, txtCorreo.Text, int.Parse(ddlPuesto.SelectedValue), null, lblUrlFoto.InnerText);
                BLLPersona.Actualizar(persona);
                LimpiarFormulario();
                Response.Redirect("ListaPersonas.aspx", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Mensaje de Error", "alert('Se registró un error al realizar la operación');", true);
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
                    lblUrlFoto.InnerText = "Archivo no válido";
                }
                else
                {
                    string path = Server.MapPath("~/Imagenes/Personas/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    SubeImagen.PostedFile.SaveAs(path + fileName);
                    string url = "/Imagenes/Personas/" + fileName;
                    lblUrlFoto.InnerText = url;
                    imgFotoPersona.ImageUrl = url;
                    btnGuardar.Visible = true;
                }
            }
        }
        public void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            ddlPuesto.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoPersona.ImageUrl = "";
        }
        public void CargarFormulario(VOPersona persona)
        {
            lblIdPersona.Text = persona.IdPersona.ToString();
            txtNombre.Text = persona.Nombre;
            txtDireccion.Text = persona.Direccion;
            txtTelefono.Text = persona.Telefono;
            txtCorreo.Text = persona.Correo;
            ddlPuesto.SelectedIndex = (int)persona.Puesto;
            lblUrlFoto.InnerText = persona.UrlFoto;
            imgFotoPersona.ImageUrl = persona.UrlFoto;
        }
    }
}