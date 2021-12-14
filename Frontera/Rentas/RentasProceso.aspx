<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RentasProceso.aspx.cs" Inherits="Frontera.Rentas.RentasProceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <h3>Rentas en Proceso</h3>
            <hr />
        </div>

        <div class="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvRentas"
                runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdRenta"
                OnRowCommand="gvRentas_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto Auto" ReadOnly="true" DataImageUrlField="UrlFotoAuto" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:ImageField HeaderText="Foto Arrendatario" ReadOnly="true" DataImageUrlField="UrlFotoArrendatario" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdRenta" ReadOnly="true" />
                    <asp:BoundField HeaderText="Fecha" ItemStyle-Width="150px" DataField="FechaHoraRenta" />
                    <asp:BoundField HeaderText="Destino" ItemStyle-Width="200px" DataField="Destino" />
                    <asp:BoundField HeaderText="Arrendatario" ItemStyle-Width="200px" DataField="NombreArrendatario" />
                    <asp:BoundField HeaderText="Auto" ItemStyle-Width="200px" DataField="NombreAuto" />
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
