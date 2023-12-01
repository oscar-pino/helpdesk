using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDeskDTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using HelpDeskBO;


namespace HelpDesk
{
    public partial class Reportes : System.Web.UI.Page
    {
        private UsuarioBO userBO = new UsuarioBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Session["LoggedIn"] == null)
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
                    }

                    llenarComboxs();

                    rblCrea.Visible = false;
                    rblCierre.Visible = false;
                    rblComp.Visible = false;
                    PanelCrea.Visible = false;
                    PanelCierre.Visible = false;
                    PanelComp.Visible = false;
                    btnExpEx.Visible = false;
                }


                if (cblCrea.SelectedIndex > -1)
                {
                    rblCrea.Visible = true;
                    PanelCrea.Visible = false;

                    if (rblCrea.SelectedIndex > 0)
                    {
                        PanelCrea.Visible = true;
                    }
                    else
                    {
                        PanelCrea.Visible = false;
                    }
                }
                else
                {
                    rblCrea.Visible = false;
                    PanelCrea.Visible = false;
                }


                if (cblCierre.SelectedIndex > -1)
                {
                    rblCierre.Visible = true;
                    PanelCierre.Visible = false;

                    if (rblCierre.SelectedIndex > 0)
                    {
                        PanelCierre.Visible = true;
                    }
                    else
                    {
                        PanelCierre.Visible = false;
                    }
                }
                else
                {
                    rblCierre.Visible = false;
                    PanelCierre.Visible = false;
                }

                if (cblComp.SelectedIndex > -1)
                {
                    rblComp.Visible = true;
                    PanelComp.Visible = false;

                    if (rblComp.SelectedIndex > 0)
                    {
                        PanelComp.Visible = true;
                    }
                    else
                    {
                        PanelComp.Visible = false;
                    }
                }
                else
                {
                    rblComp.Visible = false;
                    PanelComp.Visible = false;
                }


            }
            catch (NullReferenceException)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            string cadena = "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ";
            if (ddEstadoSDS.SelectedIndex != 0)
            {
                if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                {
                    cadena += " and";
                }
                cadena += " ESTADO = '" + ddEstadoSDS.SelectedValue.ToString() + "'";
            }
            if (ddUsuarioCreador.SelectedIndex != 0)
            {
                if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                {
                    cadena += " and";
                }
                cadena += " Nom_Usu_Crea = '" + ddUsuarioCreador.SelectedValue.ToString() + "'";
            }
            if (ddUsuarioResponsable.SelectedIndex != 0)
            {
                if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                {
                    cadena += " and";
                }
                cadena += " Nom_Usu_Resp = '" + ddUsuarioResponsable.SelectedValue.ToString() + "'";
            }


            if (cblCrea.SelectedIndex > -1)
            {
                if (rblCrea.SelectedIndex > 0)
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += " and";
                    }
                    if (creaInicio.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " Fec_Crea between '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(creaInicio.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " Fec_Crea between '2000-01-01'";
                    }
                    if (creaFin.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " and '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(creaFin.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " and '2100-01-01'";
                    }
                }
                else
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += " and";
                    }
                    cadena += " Fec_Crea IS NULL ";
                }
            }


            if (cblCierre.SelectedIndex > -1)
            {
                if (rblCierre.SelectedIndex > 0)
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += " and";
                    }
                    if (cierreInicio.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " Fec_Cierre between '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(cierreInicio.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " Fec_Cierre between '2000-01-01'";
                    }
                    if (cierreFin.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " and '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(cierreFin.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " and '2100-01-01'";
                    }
                }
                else
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += " and";
                    }
                    cadena += " Fec_Cierre IS NULL";
                }
            }


            if (cblComp.SelectedIndex > -1)
            {
                if (rblComp.SelectedIndex > 0)
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += " and";
                    }
                    if (compInicio.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " Fec_Comp between '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(compInicio.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " Fec_Comp between '2000-01-01'";
                    }
                    if (compFin.SelectedDate.ToString() != "01-01-0001 0:00:00")
                    {
                        cadena += " and '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(compFin.SelectedDate.ToString())) + "'";
                    }
                    else
                    {
                        cadena += " and '2100-01-01'";
                    }
                }
                else
                {
                    if (cadena != "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
                    {
                        cadena += "and";
                    }
                    cadena += " Fec_Comp IS NULL";
                }
            }
            if (cadena == "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS WHERE ")
            {
                cadena = "SELECT IdSds, asunto, detalle, Fec_Crea as 'Fecha Creacion', Estado, Fec_Cierre as 'Fecha Cierre', Fec_Comp as 'Fecha Compromiso', Nom_Usu_Crea as 'UsuarioDTO Creador', Nom_Usu_Resp as 'UsuarioDTO Responsable' FROM SDS ";
            }

            string conexion = (string)ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
            SqlConnection conn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(cadena, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            grvReporte.DataSource = reader;
            grvReporte.DataBind();
            btnExpEx.Visible = true;

        }

        private void ExportGridToExcel()
        {
            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();

            HtmlForm form = new HtmlForm();

            grvReporte.EnableViewState = false;

            page.EnableEventValidation = false;

            page.DesignerInitialize();

            page.Controls.Add(form);

            form.Controls.Add(grvReporte);

            page.RenderControl(htw);

            Response.Clear();

            Response.Buffer = true;

            //Response.ContentType = "application/vnd.ms-excel";

            Response.ContentType = "text/plain";

            Response.AddHeader("Content-Disposition", "attachment;filename=HelpDesk.xls");

            Response.Charset = "UTF-8";

            Response.ContentEncoding = Encoding.Default;

            Response.Write(sb.ToString());

            Response.End();

        }

        protected void btnExpEx_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        protected void grvReporte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "SDS";
                e.Row.Cells[1].Text = "Asunto";
                e.Row.Cells[2].Text = "Detalle";
                e.Row.Cells[3].Text = "Fecha Creación";
                e.Row.Cells[5].Text = "Fecha Cierre";
                e.Row.Cells[6].Text = "Fecha Compromiso";
                e.Row.Cells[7].Text = "UsuarioDTO Creador";
                e.Row.Cells[8].Text = "UsuarioDTO Responsable";
            }
        }

        /*
         private void llenarCombox() {
                        
            clsLiq.setAfp(cmb_afp);
            clsLiq.setSalud(cmb_salud);

            cmb_afp.Items.Insert(0, "Seleccione AFP");
            cmb_afp.SelectedIndex = 0;

            cmb_salud.Items.Insert(0, "Seleccione Salud");
            cmb_salud.SelectedIndex = 0;
        }
         */

        private void llenarComboxs() {

        List<ESTADOS> estados = new List<ESTADOS> {ESTADOS.abierta,ESTADOS.asignada,ESTADOS.cerrada,ESTADOS.proceso };
        List<ROLES> roles = new List<ROLES> { ROLES.administrador, ROLES.encargado, ROLES.responsable, ROLES.solicitante};

        ddEstadoSDS.DataSource = estados;
        ddEstadoSDS.DataBind();
        ddEstadoSDS.Items.Insert(0, new ListItem("seleccione estado..."));

        ddUsuarioCreador.DataSource = userBO.readByRolId((int)ROLES.solicitante);
        ddUsuarioCreador.DataBind();
        ddUsuarioCreador.Items.Insert(0, new ListItem("seleccione creador.."));

        ddUsuarioResponsable.DataSource = userBO.readByRolId((int)ROLES.responsable);
        ddUsuarioResponsable.DataBind();
        ddUsuarioResponsable.Items.Insert(0, new ListItem("seleccione responsable.."));   
       
        
        }

        protected void ddEstadoSDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            String x = "text: " + ddEstadoSDS.SelectedItem.Text + ", valor: " + ddEstadoSDS.SelectedItem.Value + ", selected: " + ddEstadoSDS.SelectedItem.Selected+", index: "+ddEstadoSDS.SelectedIndex;

                Response.Write("<script language=javascript>alert('"+x+"')</script>");

                Console.WriteLine("con: "+x);
        }       
    }
}
