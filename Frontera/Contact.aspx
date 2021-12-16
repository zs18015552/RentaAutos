<%@ Page Title="Contact - " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Frontera.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>¡Contactanos!</h3>
    <address>
        LIS - 701 (S18)<br />
        FCA Coatzacoalcos - Minatitlán<br />
        <abbr title="Phone">P:</abbr>
        (222) 222-2222
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
