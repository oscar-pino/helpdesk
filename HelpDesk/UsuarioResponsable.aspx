<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioResponsable.aspx.cs" Inherits="HelpDesk.UsuarioResponsable" %>
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
        Solicitudes de Servicio creadas por Usted en Proceso de solución.</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="IdSDS" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged1" 
            style="text-align: center" Height="16px" Width="800px" EmptyDataText="No existen SDS Creadas">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkSDS" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSDS" runat="server" OnClick ="CheckOne(this)" />
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="IdSds" HeaderText="SDS" InsertVisible="False" 
                    ReadOnly="True" SortExpression="IdSds" >
                <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" 
                    SortExpression="Asunto" >
                <HeaderStyle Width="200px" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Fec_Crea" HeaderText="Fecha Creacion" 
                    SortExpression="Fec_Crea" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Estado" 
                    SortExpression="Estado" >
                <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Fec_Comp" HeaderText="Fecha Compromiso" 
                    SortExpression="Fec_Comp" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nom_Usu_Crea" HeaderText="Creador" 
                    SortExpression="Nom_Usu_Crea" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nom_Usu_Resp" HeaderText="Responsable" 
                    SortExpression="Nom_Usu_Resp" >
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
        <asp:Button ID="btnDetalles" runat="server" Text="Detalle SDS" 
            onclick="btnDetalles_Click" />
        <asp:Button ID="btnSegumiento" runat="server" Text="Agregar Seguimiento" 
            onclick="btnSegumiento_Click" />
    </p>
    <p>
        <asp:Label ID="lblSeguimiento" runat="server" 
            Text="Ingrese Seguimiento para la SDS "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtSeguimiento" runat="server" Height="85px" Width="512px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblValidadorSeguimiento" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnAceptarSeg" runat="server" onclick="btnAceptarSeg_Click" 
            Text="Aceptar" OnClientClick="return confirm('¿Insertar Seguimiento?');" />
        <asp:Button ID="btnCancelarSeg" runat="server" onclick="btnCancelarSeg_Click" 
            Text="Cancelar" />
    </p>
    <p>
        Solicitudes de Servicio Asignadas por Atender.</p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="IdSDS"  
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" 
            style="text-align: center" Width="800px" EmptyDataText="No existen SDS por Atender">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkSDSAsig" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSDSAsig" runat="server" OnClick ="CheckOne(this)" />
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="IdSDS" HeaderText="SDS" InsertVisible="False" 
                    ReadOnly="True" SortExpression="IdSDS" >
                <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" 
                    SortExpression="Asunto" >
                <HeaderStyle Width="400px" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Fec_Crea" HeaderText="Fecha Creación" 
                    SortExpression="Fec_Crea" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Estado" 
                    SortExpression="Estado" >
                <HeaderStyle Width="50px" />
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
        <asp:Button ID="btnDetalles2" runat="server" onclick="btnDetalles2_Click" 
            Text="Detalle SDS" />
        <asp:Button ID="btnProcesarSDS" runat="server" onclick="btnProcesarSDS_Click" 
            Text="Procesar SDS" OnClientClick="return confirm('¿Procesar Solicitud?');" />
        <asp:Button ID="btnRechazar" runat="server" Text="Rechazar SDS" 
            onclick="btnRechazar_Click" OnClientClick="return confirm('¿Rechazar Solicitud?');"/>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#003399" Height="200px" 
            onselectionchanged="Calendar1_SelectionChanged" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </p>
    <p>
        <asp:Button ID="btnFecComp" runat="server" Text="Asignar Fecha Compromiso" 
            onclick="btnFecComp_Click" OnClientClick="return confirm('¿Procesar Solicitud?');" />
        <asp:Label ID="lblFecha" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblRechazo" runat="server" Text="Indique Motivo de Rechazo"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtRechazo" runat="server" Height="85px" Width="512px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblValidadorRech" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnAceptarRech" runat="server" onclick="btnAceptarRech_Click" 
            Text="Aceptar" 
            OnClientClick="return confirm('¿Insertar Seguimiento y Rechazar Solicitud?');" />
        <asp:Button ID="btnCancelarRech" runat="server" onclick="btnCancelarRech_Click" 
            Text="Cancelar" />
    </p>
    <p>
        Solicitudes de Servicio Pendientes de Solución.</p>
    <p>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="IdSDS"  
            ForeColor="#333333" GridLines="None" 
            style="text-align: center; margin-top: 0px;" Height="16px" Width="800px" EmptyDataText="No existen SDS por Pendientes de Solución">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkSDSProc" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSDSProc" runat="server" OnClick ="CheckOne(this)" />
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="IdSDS" HeaderText="SDS" InsertVisible="False" 
                    ReadOnly="True" SortExpression="IdSDS" >
                <HeaderStyle Height="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" 
                    SortExpression="Asunto" >
                <HeaderStyle Width="300px" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Fec_Crea" HeaderText="Fecha Creación" 
                    SortExpression="Fec_Crea" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Estado" 
                    SortExpression="Estado" >
                <HeaderStyle Height="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Fec_Comp" HeaderText="Fecha Compromiso" 
                    SortExpression="Fec_Comp" >
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
        <asp:Button ID="btnDetalles3" runat="server" onclick="btnDetalles3_Click" 
            Text="Detalle SDS" />
        <asp:Button ID="btnCerrarSDS" runat="server" Text="Cerrar SDS" 
            onclick="btnCerrarSDS_Click" />
        <asp:Button ID="btnSeguimientoProc" runat="server" 
            onclick="btnSeguimientoProc_Click" Text="Agregar Seguimiento" />
    </p>
    <p>
        <asp:Label ID="lblSeguimientoProc" runat="server" 
            Text="Ingrese Seguimiento para la SDS "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtSeguimientoProc" runat="server" Height="85px" Width="512px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblValidadorSeguimientoProc" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnAceptarSegProc" runat="server" onclick="btnAceptarSegProc_Click" 
            Text="Aceptar" OnClientClick="return confirm('¿Insertar Seguimiento?');" />
        <asp:Button ID="btnCancelarSegProc" runat="server" onclick="btnCancelarSegProc_Click" 
            Text="Cancelar" />
    </p>
    <p>
        <asp:Label ID="lblCierre" runat="server" Text="Indique Motivo de Cierre"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtCierre" runat="server" Height="85px" Width="512px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblValidador" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
            Text="Aceptar" OnClientClick="return confirm('¿Insertar Seguimiento y Cerrar Solicitud?');" />
        <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
            Text="Cancelar" />
    </p>
</asp:Content>
