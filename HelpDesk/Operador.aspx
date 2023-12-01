<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Operador.aspx.cs" Inherits="HelpDesk.Operador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type ="text/javascript">
    function CheckOne(obj) {
        var grid = obj.parentNode.parentNode.parentNode;
        var inputs = grid.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "checkbox") {
                if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                    inputs[i].checked = false;
                }
            }
        }
    }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Solicitudes de Servicio Sin Asignar</p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="IdSds" ForeColor="#333333" GridLines="None" 
        style="margin-top: 20px; text-align: center;" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Height="16px" 
        Width="800px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkSdS" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSdS" runat="server" OnClick ="CheckOne(this)"/>
                </ItemTemplate>
                <HeaderStyle Width="30px" />
            </asp:TemplateField>
            <asp:BoundField DataField="IdSds" HeaderText="SDS" InsertVisible="False" 
                ReadOnly="True" SortExpression="IdSds" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Asunto" HeaderText="Asunto" 
                SortExpression="Asunto" >
            <HeaderStyle Width="370px" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Fec_Crea" HeaderText="Fecha Creación" 
                SortExpression="Fec_Crea" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" 
                SortExpression="Estado" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Nom_Usu_Crea" HeaderText="Creador" 
                SortExpression="Nom_Usu_Crea" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</p>
    <p>
        Seleccione Usuario a Asignar la SDS</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="ddADUsers" runat="server" 
            onselectedindexchanged="ddADUsers_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="btnAsignarSDS" runat="server" Text="Asignar SDS" 
            onclick="btnAsignarSDS_Click" OnClientClick="return confirm('¿Asignar Solicitud?');"/>
</p>
</asp:Content>
