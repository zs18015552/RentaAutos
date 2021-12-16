<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutos.aspx.cs" Inherits="Frontera.Catalogo.Autos.ListaAutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .fotogv {
            padding:5px;
        }
    </style>
    <div class="container">
        <div class="row" style="margin-bottom:18px">
            <h3>Lista Autos</h3>
            <hr />
        </div>
        <div align="center" class ="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvAutos" runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdAuto" OnRowCommand="gvAutos_RowCommand" Width="703px" OnSelectedIndexChanged="gvAutos_SelectedIndexChanged">
                <Columns>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true"
                        DataImageUrlField="UrlFoto" ControlStyle-Width="200px"
                        ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="80px"
                        DataField="IdAuto" ReadOnly="true" />
                    <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px"
                        DataField="Nombre" />
                    <asp:BoundField HeaderText="Matricula" ItemStyle-Width="80px"
                        DataField="Matricula" />
                    <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%;margin:0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server" Enabled="false" Checked='<%#Eval("Disponibilidad") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" 
                        Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </>
    </div>
</asp:Content>
