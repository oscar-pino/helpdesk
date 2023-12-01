<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleSDS.aspx.cs" Inherits="HelpDesk.DetalleSDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:Label ID="lblDetalles" runat="server"></asp:Label>
</p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataKeyNames="IdSDS" 
            ForeColor="White" GridLines="None" Height="16px" 
            FieldHeaderStyle-Width="120px" Width="800px" 
            style="margin-right: 0px">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="IdSds" HeaderText="SDS" InsertVisible="False" 
                    ReadOnly="True" SortExpression="IdSds" />
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" 
                    SortExpression="Asunto" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" 
                    SortExpression="Detalle" />
                <asp:BoundField DataField="Fec_Crea" HeaderText="Fecha Creación" 
                    SortExpression="Fec_Crea" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" 
                    SortExpression="Estado" />
                <asp:BoundField DataField="Fec_Cierre" HeaderText="Fecha Cierre" 
                    SortExpression="Fec_Cierre" />
                <asp:BoundField DataField="Fec_Comp" HeaderText="Fecha Compromiso" 
                    SortExpression="Fec_Comp" />
                <asp:BoundField DataField="Nom_Usu_Crea" HeaderText="Creador" 
                    SortExpression="Nom_Usu_Crea" />
                <asp:BoundField DataField="Nom_Usu_Resp" HeaderText="Responsable" 
                    SortExpression="Nom_Usu_Resp" />
            </Fields>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" ForeColor="Black" />
        </asp:DetailsView>
       
</p>
    <p>
        <asp:Label ID="lblSeguimiento" runat="server"></asp:Label>
</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="IdSeg"  
            ForeColor="#333333" GridLines="None" Width="800px" style="text-align: center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IdSDS" HeaderText="SDS" SortExpression="IdSDS" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Numero Seguimiento" InsertVisible="False" 
                    SortExpression="IdSeg">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("IdSeg") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Fec_Seg" HeaderText="Fecha Ingreso" 
                    SortExpression="Fec_Seg" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" 
                    SortExpression="Detalle" >
                <HeaderStyle HorizontalAlign="Center" Width="400px" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Nom_Usu_Seg" HeaderText="UsuarioDTO Creador" 
                    SortExpression="Nom_Usu_Seg" >
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
        &nbsp;</p>
</asp:Content>
