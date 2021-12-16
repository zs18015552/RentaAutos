<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaRentas.aspx.cs" Inherits="Frontera.Rentas.AltaRentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="row">
            <h3>Alta Renta</h3>
            <hr />
        </div>

       

        <div class="row form-group">
            <label for="<%=FechaHoraRenta.ClientID %>">Fecha y Hora de Renta:</label>
            <input id="FechaHoraRenta" runat="server" type="text" class="form-control" /><div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="FechaHoraRenta" ErrorMessage="Fecha de renta requerida"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtDestino.ClientID %>">Destino:</label>
            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control" placeholder="Destino"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtDestino" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtDestino" ErrorMessage="Destino de la renta requerida"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <label for="<%=ddlArrendatario.ClientID %>">Arrendatario:</label>
            <asp:DropDownList ID="ddlArrendatario" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Arrendatario"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlArrendatario" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlArrendatario" InitialValue="0" ErrorMessage="Selecciona el arrendatario"></asp:RequiredFieldValidator>
        </div>

        <div class="row form-group">
            <label for="<%=ddlAuto.ClientID %>">Auto:</label>
            <asp:DropDownList ID="ddlAuto" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Auto"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlAuto" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlAuto" InitialValue="0" ErrorMessage="Selecciona el auto"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click"/>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.datetimepicker.setLocale('es');
            $("#<%=FechaHoraRenta.ClientID%>").datetimepicker({
                format: 'd/m/Y H:i',
                minDate: '0'
            });
        });
    </script>
</asp:Content>