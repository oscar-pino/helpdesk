using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk
{
    public partial class SiteMaster : System.Web.UI.MasterPage{

        private static UsuarioDTO userDTO;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                userDTO = (UsuarioDTO)Session["LoggedIn"];

                if (userDTO.IdUser != 0)
                {  

                    MasterPage myMasterPage = (MasterPage)Page.Master;
                    HyperLink myLink = (HyperLink)myMasterPage.FindControl("hypCerrarSesion");                    
                    Label myLabelUsuarioDTO = (Label)myMasterPage.FindControl("lblUsrLog");
                    Label myLabelType = (Label)myMasterPage.FindControl("lblTypeLog");
                    Menu menu = (Menu)myMasterPage.FindControl("NavigationMenu");
                    lblUsrLog.Text = "Bienvenido, " + userDTO.Username;
                    lblTypeLog.Text = "Rol: " + userDTO.RolUser.ToString().ToLower();
                    lblUsrLog.Visible = true;
                    lblTypeLog.Visible = true;
                    myLink.Visible = true;
                    myLink.Attributes.Add("onclick", "return hlCerrarClick()");

                    if ((int)userDTO.RolUser != (int)ROLES.administrador)
                        menu.Items.RemoveAt(2);

                    menu.Items.RemoveAt(0);
                    
                }
                else
                {
                    MasterPage myMasterPage = (MasterPage)Page.Master;
                    HyperLink myLink = (HyperLink)myMasterPage.FindControl("hypCerrarSesion");
                    myLink.Visible = false;
                }
            }
            catch (NullReferenceException)
            {
                MasterPage myMasterPage = (MasterPage)Page.Master;
                HyperLink myLink = (HyperLink)myMasterPage.FindControl("hypCerrarSesion");
                myLink.Visible = false;
            }

        }
    }
}
