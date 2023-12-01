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
    public partial class CrearSDS : System.Web.UI.Page
    {
        private UsuarioBO userBO = new UsuarioBO();
        private String user_selected = String.Empty;
        private static UsuarioDTO userDTO = new UsuarioDTO();
        private static SdsBO sdsBO = new SdsBO();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //String tipo = "solicitante";
                    //String tipo = "encargado";

                    //userDTO = new UsuarioDTO { IdUser = 1, Username = "oscar", RolUser = new RolDTO(tipo), Password = "pelusita" };
                    //Session["LoggedIn"] = userDTO;

                    if (Session["LoggedIn"] == null)
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
                    }

                    userDTO = (UsuarioDTO)Session["LoggedIn"];

                    if ((int)userDTO.RolUser == (int)ROLES.encargado)// operador
                    {
                        ddADUsers.Enabled = true;
                        ddADUsers.Visible = true;
                        lblAsignarSDS.Visible = true;
                        ddADUsers.DataSource = userBO.readByRolId((int)ROLES.encargado);
                        ddADUsers.DataBind();
                        ddADUsers.Items.Insert(0, new ListItem("seleccione usuario.."));
                    }
                    else
                    {
                        ddADUsers.Visible = false;
                        ddADUsers.Enabled = false;
                        lblAsignarSDS.Visible = false;
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

        protected void InsertarSDS_Click(object sender, EventArgs e)
        {
            
            if (!isEmptySDS())
            {
                SdsDTO sdsDTO = new SdsDTO();          
                    
                sdsDTO.Asunto = txtAsunto.Text;
                sdsDTO.Detalle = txtDetalle.Text;
                sdsDTO.Estado = ESTADOS.abierta;

                if (userDTO.RolUser == ROLES.encargado)
                {
                    sdsDTO.Nom_Usu_Crea = user_selected;
                }
                else
                {
                    sdsDTO.Nom_Usu_Crea = userDTO.Username;
                }
            


                if (sdsBO.create_simple(sdsDTO) != null)
                {
                    Response.Write("<script language=javascript>alert('Solicitud ingresada correctamente!');window.location='UsuarioResponsable.aspx'</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al ingresar solicitud!')</script>");

                    txtAsunto.Text = sdsDTO.Asunto;
                    txtAsunto.Text = sdsDTO.Detalle;
                }

                
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Ingresar todos los datos!');window.location='CrearSDS.aspx'</script>");
            }
            
        }

        protected void ddADUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_selected = ddADUsers.SelectedValue.ToString();
        }

        private bool isEmptySDS()
        {

            if (userDTO.RolUser == ROLES.encargado)
            {

                if (txtAsunto.Text.Trim().Length == 0 || txtDetalle.Text.Trim().Length == 0 || ddADUsers.SelectedIndex == 0)
                    return true;
                else
                    return false;
            }
            else
            {

                if (txtAsunto.Text.Trim().Length == 0 || txtDetalle.Text.Trim().Length == 0)
                    return true;
                else
                    return false;

            }

        }
    }
}