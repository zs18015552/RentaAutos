<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleRentas.aspx.cs" Inherits="Frontera.Rentas.DetalleRentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Detalle Renta</h3>
            <h4>ID:
                <asp:Label ID="lblIdRenta" runat="server" Text=""></asp:Label></h4>
            <hr />
        </div>
        <div class="col-md-10 col-md-offset-1">
            <dl class="dl-horizontal">
                <dt>
                    <label for="<%=lblFecha.ClientID %>">Fecha:</label></dt>
                <dd>
                    <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblDestino.ClientID %>">Destino:</label></dt>
                <dd>
                    <asp:Label ID="lblDestino" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblNombreArrendatario.ClientID %>">Arrendatario:</label></dt>
                <dd>
                    <asp:Label ID="lblNombreArrendatario" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=imgFotoArrendatario %>">Foto:</label></dt>
                <dd>
                    <asp:Image ID="imgFotoArrendatario" Width="200" Height="200" runat="server" /></dd>
                <dt>
                    <label for="<%=lblNombreAuto.ClientID %>">Auto:</label></dt>
                <dd>
                    <asp:Label ID="lblNombreAuto" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=imgFotoAuto %>">Foto:</label></dt>
                <dd>
                    <asp:Image ID="imgFotoAuto" Width="200" Height="200" runat="server" /></dd>
                </dl>
           
        </div>
        <div class="row form-group col-md-10 col-md-offset-4" style="padding-top:20px">
            <div class="col-md-4">
                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" CssClass="btn btn-success" OnClick="btnFinalizar_Click" />
            </div>
                    </div>
    </div>
</asp:Content>
