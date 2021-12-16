﻿using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontera.Catalogo.Autos
{
    public partial class ListaAutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        protected void gvAutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string idAutos = gvAutos.DataKeys[index].Values["IdAuto"].ToString();
                Response.Redirect("EditarAuto.aspx?Id=" + idAutos);
            }
        }
        public void CargarGrid()
        {
            gvAutos.DataSource = BLLAuto.ConsultarAutos(null);
            gvAutos.DataBind();
        }

        protected void gvAutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}