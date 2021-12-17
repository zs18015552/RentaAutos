<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarAuto.aspx.cs" Inherits="Frontera.Catalogo.Autos.EditarAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Edición Auto</h3>
            <h4>ID:
                <asp:Label ID="lblAuto" runat="server" Text=""></asp:Label></h4>
            <hr />
        </div>
        <div class="row form-group">
            <label for="<%=txtMatricula.ClientID %>">Matrícula:</label>
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="XXX-0000"></asp:TextBox>
            <div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula" ErrorMessage="Matrícula del Barco requerida"></asp:RequiredFieldValidator>
            </div>
            <div style="position: absolute; top: 0; left: 0">
                <asp:RegularExpressionValidator ID="revtxtMatricula" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula" ValidationExpression="^[A-Z]{3}-[0-9]{4}$" ErrorMessage="El formato de matrícula es XXX-0000 (Mayúsculas)"></asp:RegularExpressionValidator>
            </div>
        </div>
         <div class="row form-group">
            <label for="<%=txtNombre.ClientID %>">Modelo:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtNombre" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtNombre" ErrorMessage="Nombre del barco requerido"></asp:RequiredFieldValidator>
        </div>
        <div class="row form-group">
            <label for="<%=txtCuota.ClientID %>">Cuota:</label>
            <asp:TextBox ID="txtCuota" runat="server" CssClass="form-control" placeholder="0.0"></asp:TextBox>
            <div class="col-md-12" style="margin-bottom: 20px;">
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RequiredFieldValidator ID="rfvtxtCuota" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtCuota" ErrorMessage="Cuota requerida"></asp:RequiredFieldValidator>
                </div>
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RegularExpressionValidator ID="revtxtCuota" runat="server" CssClass="text-danger" ControlToValidate="txtCuota" ValidationExpression="^[0-9]+(\.[0-9][0-9]?)?$" ErrorMessage="La cuota es un valor decimal"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        <div class="row form-inline">
            <div class="colo-md-12">
                <label>Selecciona Foto:</label>
                <input type="file" class="btn btn-default btn-file" runat="server" id="SubeImagen" style="display: inline-block;" />
                <asp:Button ID="btnSubeImagen" runat="server" Text="Subir Imagen" CssClass="btn btn-primary btn-xs" OnClick="btnSubeImagen_Click" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3" style="text-align: center;">
                <label for="<%=SubeImagen.ClientID %>">Foto:</label>
                <asp:Image ID="imgFotoPersona" Width="200" Height="200" runat="server" />
                <label id="lblUrlFoto" runat="server"></label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-2">
                <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
