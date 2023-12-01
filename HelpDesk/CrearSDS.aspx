<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearSDS.aspx.cs" Inherits="HelpDesk.CrearSDS" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:Panel ID="pnlSDS" runat="server" Width="50%" Style="padding-top:3%;margin:3% auto;padding-bottom:3%">

        <asp:Label Text="Crear Solicitud de Servicio" ID="lblTitulo" runat="server" Style="display:block;text-align:center" Font-Size="X-Large"/><br /><br />
        
        <asp:Label Text="Asunto" ID="lblAsunto" runat="server" Font-Size="Medium"/><br />
        <asp:TextBox ID="txtAsunto" runat="server" Font-Size="Medium" Width="100%" Height="5%"/><br />
        <%--<asp:RequiredFieldValidator ID="rfvAsunto" runat="server"
            ErrorMessage="El nombre de Usuario es obligatorio." ControlToValidate="txtUser"
            ForeColor="Red" />--%><br /><br />

        <asp:Label Text="Detalle" runat="server" ID="lblDetalle" Style="margin:3% auto" Font-Size="Medium"/><br />
        <asp:TextBox ID="txtDetalle" runat="server" Height="40%" Width="100%" TextMode="MultiLine" Style="resize:none" Font-Size="X-Large" /><br />
        <%--<asp:RequiredFieldValidator ID="rfvDetalle" runat="server"
            ErrorMessage="El nombre de Usuario es obligatorio." ControlToValidate="txtUser"
            ForeColor="Red" />--%>
        <br />
        <br />
        <asp:Panel runat="server" ID="pnlUsuario">
        <asp:Label ID="lblAsignarSDS" runat="server" Text="Seleccione Usuario Creador:" Font-Size="Medium" />
        <br />
        <br />
        <asp:DropDownList ID="ddADUsers" runat="server" 
            onselectedindexchanged="ddADUsers_SelectedIndexChanged" Font-Size="Medium" Width="60%" Height="5%" />              
            </asp:Panel>
        <br />
        <asp:Literal runat="server" ID="lblError" Mode="PassThrough"/><br />
        <br />
        <asp:Button ID="InsertarSDS" runat="server" onclick="InsertarSDS_Click" Text="Insertar SDS" Font-Size="Medium" Width="60%" Height="8%" BackColor="#66ff66" ForeColor="White" />
    </asp:Panel>
    </asp:Content>
    
