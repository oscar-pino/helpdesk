<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="HelpDesk.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            text-align: center;
        }

        .style43 {
            width: 132px;
        }

        .style44 {
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlReporte" runat="server" Width="50%" Style="padding-top: 3%; margin: 3% auto; padding-bottom: 3%;border:2px solid yellow;">
        <asp:Label ID="lblTitulo" runat="server" Text="Generar Reportes" Style="font-size: x-large;text-align:center;display:block;" /><br /><br />
        <br />
        <br />
        <br />
        <asp:Label runat="server" Text="Estado SDS:" ID="lblSDS" Font-Size="Medium" />
        <asp:DropDownList OnSelectedIndexChanged="ddEstadoSDS_SelectedIndexChanged" ID="ddEstadoSDS" runat="server" Font-Size="Large" Width="225" Height="25" Style="margin-left: 5.9%" AutoPostBack="True" DataTextField="Estado" DataValueField="IdEstado" />
        <br />
        <asp:Label runat="server" Text="Usuario Creador:" ID="lblCreador" />
        <asp:DropDownList ID="ddUsuarioCreador" runat="server" Font-Size="Larger" Width="225" Height="25" Style="margin-left: 3.2%; margin-top: .5%; margin-bottom: .5%" />
        <br />
        <asp:Label runat="server" Text="Usuario Responsable:" ID="lblResponsable" />
        <asp:DropDownList ID="ddUsuarioResponsable" runat="server" Font-Size="Larger" Width="225" Height="25" Style="margin-bottom: 2%" />
        <br />
        <asp:CheckBoxList ID="cblCrea" runat="server" AutoPostBack="True">
            <asp:ListItem Text="incluir filtros en fecha de creacion" />
        </asp:CheckBoxList>
        <asp:RadioButtonList ID="rblCrea" runat="server" AutoPostBack="True" Style="text-align: left; width: 50%">
            <asp:ListItem>Sin Fecha</asp:ListItem>
            <asp:ListItem>Con Rango de Fecha</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Panel ID="PanelCrea" runat="server" Width="422px">
            <table style="width: 45%; height: 195px;">
                <tr>
                    <td class="style1">Desde</td>
                    <td class="style1">Hasta</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Calendar ID="creaInicio" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="171px" Width="202px">
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
                    </td>
                    <td class="style1">
                        <asp:Calendar ID="creaFin" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="172px" ViewStateMode="Enabled" Width="212px">
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:CheckBoxList ID="cblCierre" runat="server" AutoPostBack="True">
            <asp:ListItem>Incluir Filtros En Fecha de Cierre</asp:ListItem>
        </asp:CheckBoxList>
        <asp:RadioButtonList ID="rblCierre" runat="server" AutoPostBack="True"
            Style="text-align: left" Width="50%">
            <asp:ListItem>Sin Fecha</asp:ListItem>
            <asp:ListItem>Con Rango de Fecha</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Panel ID="PanelCierre" runat="server" Width="418px">
            <table style="width: 98%; height: 199px;">
                <tr>
                    <td class="style1">Desde</td>
                    <td class="style1">Hasta</td>
                </tr>
                <tr>
                    <td>
                        <asp:Calendar ID="cierreInicio" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="171px" Width="202px">
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
                    </td>
                    <td>
                        <asp:Calendar ID="cierreFin" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="171px" ViewStateMode="Enabled" Width="202px">
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:CheckBoxList ID="cblComp" runat="server" AutoPostBack="True">
            <asp:ListItem>Incluir Filtros En Fecha de Compromiso</asp:ListItem>
        </asp:CheckBoxList>
        <asp:RadioButtonList ID="rblComp" runat="server" AutoPostBack="True"
            Style="text-align: left" Width="50%">
            <asp:ListItem>Sin Fecha</asp:ListItem>
            <asp:ListItem>Con Rango de Fecha</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Panel ID="PanelComp" runat="server" Width="413px">
            <table style="width: 41%; height: 145px;">
                <tr>
                    <td class="style1">Desde</td>
                    <td class="style1">Hasta</td>
                </tr>
                <tr>
                    <td>
                        <asp:Calendar ID="compInicio" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="171px" Width="202px">
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
                    </td>
                    <td>
                        <asp:Calendar ID="compFin" runat="server" BackColor="White"
                            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="171px" ViewStateMode="Enabled" Width="202px">
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click"
            Text="Generar Reporte" />
        <br />
        <br />
        <asp:GridView ID="grvReporte" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" EmptyDataText="No existen datos que cumplan el criterio de búsqueda"
            OnRowDataBound="grvReporte_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
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
        <br />
        <asp:Button ID="btnExpEx" runat="server" OnClick="btnExpEx_Click"
            Text="Exportar a Excel" Style="font-size: x-large" />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
