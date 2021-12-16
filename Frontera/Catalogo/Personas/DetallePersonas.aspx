<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePersonas.aspx.cs" Inherits="Frontera.Catalogo.Personas.DetallePersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <h3>Detalle Personas</h3>
            <h4>ID:
                <asp:Label ID="lblIdPersona" runat="server" Text=""></asp:Label></h4>
            <hr />
        </div>
        <div class="col-md-10 col-md-offset-1">
            <dl class="dl-horizontal">
                <dt>
                    <label for="<%=lblNombre.ClientID %>">Nombre:</label></dt>
                <dd>
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblDireccion.ClientID %>">Dirección:</label></dt>
                <dd>
                    <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblTelefono.ClientID %>">Teléfono:</label></dt>
                <dd>
                    <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblCorreo.ClientID %>">Correo:</label></dt>
                <dd>
                    <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=chkPersonaDisponible.ClientID %>">Disponibilidad:</label></dt>
                <dd>
                    <asp:CheckBox ID="chkPersonaDisponible" runat="server" Enabled="false" Checked="true" /></dd>
                <dt>
                    <label for="<%=imgFotoPersona %>">Foto:</label></dt>
                <dd>
                    <asp:Image ID="imgFotoPersona" Width="200" Height="200" runat="server" /></dd>
            </dl>
        </div>
        <div class="row form-group col-md-10 col-md-offset-4" style="padding-top:20px">
            <div class="col-md-4">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success" OnClick="btnEditar_Click" />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
