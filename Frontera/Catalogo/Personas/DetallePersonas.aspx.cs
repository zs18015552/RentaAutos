﻿using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Frontera.Utilerias.Enumeradores;

namespace Frontera.Catalogo.Personas
{
    public partial class DetallePersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("ListaPersonas.aspx");
                else
                {
                    bool disponibilidad = true;
                    string idPersona = Request.QueryString["id"].ToString();
                    VOPersona persona = BLLPersona.ConsultarPersonaPorId(idPersona);
                    CargarFormulario(persona);
                    CargarGrid(idPersona);
                    disponibilidad = (bool)persona.Disponibilidad;
                    if (disponibilidad)
                    {
                        lblIdPersona.ForeColor = System.Drawing.Color.Green;
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        lblIdPersona.ForeColor = System.Drawing.Color.Red;
                        btnEliminar.Visible = false;
                    }
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPersonas.aspx?Id=" + lblIdPersona.Text);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BLLPersona.Eliminar(lblIdPersona.Text);
            Response.Redirect("ListaPersonas.aspx");
        }
        public void CargarGrid(string owner)
        {
            gvAutos.DataSource = BLLAuto.ConsultarAutosPorOwner(owner, true);
            gvAutos.DataBind();
        }
        public void CargarFormulario(VOPersona persona)
        {
            lblIdPersona.Text = persona.IdPersona.ToString();
            lblNombre.Text = persona.Nombre;
            lblDireccion.Text = persona.Direccion;
            lblTelefono.Text = persona.Telefono;
            lblCorreo.Text = persona.Correo;
            lblPuesto.Text = Enum.GetName(typeof(PuestoPersona), (int)persona.Puesto);
            chkPersonaDisponible.Checked = (bool)persona.Disponibilidad;
            imgFotoPersona.ImageUrl = persona.UrlFoto;
        }
    }
}