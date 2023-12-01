using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDeskDTO;
using HelpDeskBO;

namespace HelpDesk
{
    public partial class Operador : System.Web.UI.Page
    {        
        String responsable = string.Empty;
        private static UsuarioBO userBO = new UsuarioBO();
        private static SdsBO sdsBO = new SdsBO();
        private static UsuarioDTO userDTO = new UsuarioDTO();

     

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                userDTO = (UsuarioDTO)Session["LoggedIn"];
                                if (!IsPostBack)
                {

                  

                    if (userDTO.IdUser == 0)
                    {
                            Session.Abandon();
                            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                            Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");

                    }
                    else
                    {
                        UsuarioDTO UsuarioDTODTO = (UsuarioDTO)Session["UserLogeado"];
                        ddADUsers.DataSource = userBO.readByRolId((int)ROLES.responsable);
                        ddADUsers.DataBind();
                        ddADUsers.Items.Insert(0, new ListItem("Seleccione Usuario...", string.Empty));
                    }
                    
                }

            }
            catch (NullReferenceException)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
            }

        }

        protected void ddADUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            responsable = ddADUsers.SelectedValue.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAsignarSDS_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            string asunto = string.Empty;
            string detalle = string.Empty;
            string fec_crea = string.Empty;
            string estado = string.Empty;
            DateTime? fec_comp = null;
            DateTime? fec_cierre = null;
            string creador = string.Empty;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSdS");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView1.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    asunto = gvrow.Cells[2].Text;
                    fec_crea = gvrow.Cells[3].Text;
                    estado = gvrow.Cells[4].Text;
                    creador = gvrow.Cells[5].Text;
                    creador = System.Web.HttpUtility.HtmlDecode(creador);
                }
            }

            if (idsds != "")
            {
                if (ddADUsers.SelectedIndex != 0)
                {

                    idsds = idsds.Trim(",".ToCharArray());
                    lblmsg.Text = idsds + " " + asunto + " " + detalle + " " + fec_crea + " " + estado + " " +
                        fec_cierre + " " + fec_comp + " " + creador + " " + responsable;
                    SdsDTO sdsDTO = new SdsDTO();
                    sdsDTO.IdSds = Int32.Parse(idsds);
                    sdsDTO.Asunto = asunto;
                    sdsDTO.Detalle = detalle;
                    sdsDTO.Estado =ESTADOS.asignada;
                    sdsDTO.Fec_Crea = DateTime.Parse(fec_crea);
                    sdsDTO.Fec_Cierre = fec_cierre;
                    sdsDTO.Fec_Comp = fec_comp;
                    sdsDTO.Nom_Usu_Crea = creador;
                    sdsDTO.Nom_Usu_Resp = responsable;
                

                    if (sdsBO.update(sdsDTO) != null)
                    {
                        SeguimientoDTO segDTO = new SeguimientoDTO();
                        segDTO.IdSeg = Int32.Parse(idsds);
                        segDTO.Detalle = "Solicitud Asignada.";
                        segDTO.Nom_Usu_Seg = (string)Session["Username"];
                        var segBO = new SeguimientoBO();
                        
                        if (segBO.create(segDTO) != null)
                        {
                            Response.Write("<script language=javascript>alert('Solicitud asignada correctamente!');window.location='Default.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Error al asignar solicitud!');</script>");
                        }                        
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al asignar solicitud!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe Seleccionar un UsuarioDTO');window.location='Default.aspx'</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar una SDS');window.location='Default.aspx'</script>");
            }

        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
        }

        protected void DSSDSSinAsignar_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        private void llenarGridview() {

            GridView1.DataSource = sdsBO.readAllsByCreatorUserAndState(userDTO.Username, (int)ESTADOS.proceso);
            GridView1.DataBind();
        }

    }
}