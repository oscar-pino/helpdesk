using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk
{
    public partial class Salir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
            //Session["LoggedIn"] = null;
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.Clear();
            Response.Write("<script language=javascript>alert('AVISO: UD ha salido del sistema!');window.location='Default.aspx'</script>");
        }
    }
}