<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HelpDesk._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="pnLogin" Width="35%" Style="margin:3% 33.5%;">
        <asp:Label Text="Iniciar Sesión" runat="server" Font-Size="X-Large" Style="text-align:center;display:block" /><br /><br />
        <asp:Label runat="server" AssociatedControlID="txtUser" ID="lblUsername" Text="Nombre de Usuario:" Font-Size="Medium" />
        <asp:TextBox runat="server" ID="txtUser" Width="150" Height="5%" Font-Size="Medium" /><br />
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
            ErrorMessage="El nombre de Usuario es obligatorio." ControlToValidate="txtUser"
            ForeColor="Red" Font-Size="Medium" /><br />
        <br />
        <asp:Label runat="server" AssociatedControlID="txtPassword" ID="lblPassword" Text="Contraseña:" Width="44.6%" Style="display:inline-block;text-align:right" Font-Size="Medium" />
        <asp:TextBox runat="server" TextMode="SingleLine" ID="txtPassword" Width="150" Height="5%" Font-Size="Medium" /><br />
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                    ErrorMessage="La contrase&#241;a es obligatoria."
                     ForeColor="Red" Style="text-align: center" ControlToValidate="txtPassword" Font-Size="Medium" /><br />
        <br />
        <asp:Literal runat="server" ID="lblAuth" Mode="PassThrough" /><br />
        <br />
        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="imgs/boton.png" OnClick="btnLogin_Click" BorderColor="#3333FF" BorderStyle="Groove" Height="35" Width="150" Style="display:block;margin-left:20%"/>
    </asp:Panel>
</asp:Content>
