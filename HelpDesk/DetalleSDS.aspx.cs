using HelpDeskBO;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk
{
    public partial class DetalleSDS : System.Web.UI.Page
    {
        private SdsBO sdsBO = new SdsBO();
        private UsuarioDTO userDTO = new UsuarioDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int idSeleccionado = (int)Session["SDSSeg"];

                    llenarDetalleSDS(idSeleccionado);
                    
                    if ((UsuarioDTO)Session["LoggedIn"] == null)
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
                    }
                    else
                    {
                        userDTO = (UsuarioDTO)Session["LoggedIn"];

                        if (userDTO.RolUser == ROLES.encargado)
                        {
                            Session.Abandon();
                            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                            Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
                        }
                    }
                    
                }
            }
            catch (NullReferenceException)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
            }
            lblDetalles.Text = "Información Detallada SDS N°: " + Session["SDSSeg"];
            lblSeguimiento.Text = "Seguimientos Asociados a SDS N°: " + Session["SDSSeg"];
        }

        private void llenarDetalleSDS(int id) {

            List<SdsDTO> sds = new List<SdsDTO>();
            sds.Add(sdsBO.readById(id));

            DetailsView1.DataSource = sds;
            DetailsView1.DataBind();
        }
    }
}