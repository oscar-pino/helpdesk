using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelpDeskDTO;
using HelpDeskBO;
using System.Web.UI.WebControls;

namespace HelpDesk
{
    public partial class _Default : System.Web.UI.Page
    {
        private UsuarioBO userBO = new UsuarioBO();
        private String username = String.Empty;
        private String password = String.Empty;
        private static UsuarioDTO userDTO = new UsuarioDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    if (userDTO.IdUser != 0)
                    {
                        rutas();
                    }
                }
                else
                {
                    Session["LoggedIn"] = new UsuarioDTO();
                }
            }
            catch (NullReferenceException ex)
            {
                lblAuth.Text = ex.Message;
            }
        }

        protected void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                username = txtUser.Text.ToString();
                password = txtPassword.Text.ToString();

                userDTO = userBO.isAuthenticated(username, password);

                if (userDTO != null)
                {
                    Session["LoggedIn"] = userDTO;

                    rutas();
                }
                else
                {
                    lblAuth.Text = "Autenticación Inválida. Revise Usuario y Password.";
                }

            }
            catch (Exception ex)
            {
                lblAuth.Text = ex.Message;
            }
        }

        private void rutas()
        {
            if ((int)userDTO.RolUser == (int)ROLES.solicitante)
            {
                Response.Redirect("~/CrearSDS.aspx");
            }
            else if ((int)userDTO.RolUser == (int)ROLES.encargado)
            {
                Response.Redirect("~/Operador.aspx");
            }
            else if ((int)userDTO.RolUser == (int)ROLES.responsable)
            {
                Response.Redirect("~/UsuarioResponsable.aspx");
            }
            else
            {
                Response.Redirect("~/Reportes.aspx");
            }

        }
    }
}
