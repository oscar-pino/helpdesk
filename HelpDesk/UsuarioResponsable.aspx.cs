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
    public partial class UsuarioResponsable : System.Web.UI.Page
    {
        SdsBO sdsBO = new SdsBO();
        UsuarioBO userBO = new UsuarioBO();
        SeguimientoBO segBO = new SeguimientoBO();
        UsuarioDTO userDTO = new UsuarioDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            ocultarControles();
            userDTO = userBO.readById(5);
            
            try
            {
                if (!IsPostBack)
                {
                    Calendar1.Visible = false;
                    btnFecComp.Visible = false;                    

                    if (userDTO == null)
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Write("<script language=javascript>alert('Error: No se ha logueado en el sistema!');window.location='Default.aspx'</script>");
                    }
                    else {

                        Session["LoggedIn"] = userDTO;
                        llenarGridViews();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = GridView2.SelectedIndex;

            Response.Write("<script language=javascript>alert("+x+")</script>");
        }

        protected void btnProcesarSDS_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSAsig");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView2.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }

            }
            if (idsds != "")
            {
                Calendar1.Visible = true;
                btnFecComp.Visible = true;
            }

            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar una SDS');window.location='Default.aspx'</script>");
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
        }

        protected void btnFecComp_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            int idsds = 0;

            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDS");
                if (chk != null & chk.Checked)
                {
                    idsds = Int32.Parse(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
                }
            }
            
            //idsds = idsds.Trim(",".ToCharArray());

            if (idsds != 0)
            {
                Session["SDSSeg"] = idsds;
                Response.Redirect("~/DetalleSDS.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSAsig");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView2.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                lblRechazo.Visible = true;
                txtRechazo.Visible = true;
                btnAceptarRech.Visible = true;
                btnCancelarRech.Visible = true;
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }


        }
        protected void btnCerrarSDS_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView3.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSProc");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView3.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                lblCierre.Visible = true;
                txtCierre.Visible = true;
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }
        }

        protected void btnSegumiento_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDS");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView1.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                lblValidadorSeguimiento.Visible = true;
                lblSeguimiento.Visible = true;
                txtSeguimiento.Visible = true;
                btnAceptarSeg.Visible = true;
                btnCancelarSeg.Visible = true;
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }

        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCierre.Text != "")
            {
                string idsds = string.Empty;
                string asunto = string.Empty;
                string detalle = string.Empty;
                string estado = string.Empty;
                DateTime? fec_cierre = DateTime.Parse(DateTime.Now.Date.ToString());
                DateTime? fec_comp = null;
                DateTime? fec_crea = null;
                string creador = string.Empty;
                string responsable = string.Empty;
                foreach (GridViewRow gvrow in GridView3.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSProc");
                    if (chk != null & chk.Checked)
                    {
                        idsds = GridView3.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                        fec_comp = DateTime.Parse(gvrow.Cells[5].Text);
                    }
                }
                idsds = idsds.Trim(",".ToCharArray());
                if (idsds != "")
                {
                    SdsDTO sdsDTO = new SdsDTO();
                    sdsDTO.IdSds = Int32.Parse(idsds);
                    sdsDTO.Asunto = asunto;
                    sdsDTO.Detalle = detalle;
                    sdsDTO.Estado = ESTADOS.cerrada;
                    sdsDTO.Fec_Crea = fec_crea;
                    sdsDTO.Fec_Cierre = fec_cierre;
                    sdsDTO.Fec_Comp = fec_comp;
                    sdsDTO.Nom_Usu_Crea = creador;
                    sdsDTO.Nom_Usu_Resp = (string)Session["Username"];
                    SeguimientoDTO segDTO = new SeguimientoDTO();
                    segDTO.SDS = sdsBO.readById(Int32.Parse(idsds));
                    segDTO.Detalle = txtCierre.Text;
                    segDTO.Nom_Usu_Seg = (string)Session["Username"];
                    var segBO = new SeguimientoBO();

                    if (segBO.create(segDTO) != null)
                    {

                        Response.Write("<script language=javascript>alert('Seguimiento Insertado!');</script>");
                     
                        if (sdsBO.update(sdsDTO) != null)
                        {
                            Response.Write("<script language=javascript>alert('Cambia estado SDS : CERRADA!');window.location='Default.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Error al Cambiar Estado!');window.location='Default.aspx'</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al Agregar Seguimiento!');window.location='Default.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
                }
            }
            else
            {
                lblValidador.Visible = true;
                lblCierre.Visible = true;
                txtCierre.Visible = true;
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
                lblValidador.Text = "Este Campo no puede estar vacio";
            }

        }
        protected void btnCancelarRech_Click(object sender, EventArgs e)
        {
            lblRechazo.Visible = false;
            txtRechazo.Visible = false;
            btnAceptarRech.Visible = false;
            btnCancelarRech.Visible = false;
            lblValidadorRech.Visible = false;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblCierre.Visible = false;
            lblValidador.Visible = false;
            txtCierre.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void btnAceptarRech_Click(object sender, EventArgs e)
        {
            if (txtRechazo.Text != "")
            {
                string idsds = string.Empty;
                string asunto = string.Empty;
                string detalle = string.Empty;
                string estado = string.Empty;
                DateTime? fec_cierre = null;
                DateTime? fec_comp = null;
                DateTime? fec_crea = null;
                string creador = string.Empty;
                string responsable = string.Empty;
                foreach (GridViewRow gvrow in GridView2.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSAsig");
                    if (chk != null & chk.Checked)
                    {
                        idsds = GridView2.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    }
                }
                idsds = idsds.Trim(",".ToCharArray());
                if (idsds != "")
                {
                    SdsDTO sdsDTO = new SdsDTO();
                    sdsDTO.IdSds = Int32.Parse(idsds);
                    sdsDTO.Asunto = asunto;
                    sdsDTO.Detalle = detalle;
                    sdsDTO.Estado = ESTADOS.abierta;
                    sdsDTO.Fec_Crea = fec_crea;
                    sdsDTO.Fec_Cierre = fec_cierre;
                    sdsDTO.Fec_Comp = fec_comp;
                    sdsDTO.Nom_Usu_Crea = creador;
                    sdsDTO.Nom_Usu_Resp = null;
                    SeguimientoDTO segDTO = new SeguimientoDTO();
                    segDTO.SDS = sdsBO.readById(Int32.Parse(idsds));
                    segDTO.Detalle = txtRechazo.Text;
                    segDTO.Nom_Usu_Seg = (string)Session["Username"];
                   
                    if (segBO.create(segDTO) != null)
                    {

                        Response.Write("<script language=javascript>alert('Seguimiento Insertado!');</script>");
                       

                        if (sdsBO.update(sdsDTO) != null)
                        {
                            Response.Write("<script language=javascript>alert('Rechaza SDS Cambia estado a : ABIERTA!');window.location='Default.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Error al Cambiar Estado!');window.location='Default.aspx'</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al Agregar Seguimiento!');window.location='Default.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
                }
            }
            else
            {
                lblRechazo.Visible = true;
                txtRechazo.Visible = true;
                btnAceptarRech.Visible = true;
                btnCancelarRech.Visible = true;
                lblValidadorRech.Visible = true;
                lblValidadorRech.Text = "Este Campo no puede estar vacio";
            }

        }

        protected void btnAceptarSeg_Click(object sender, EventArgs e)
        {
            if (txtSeguimiento.Text != "")
            {
                string idsds = string.Empty;
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSDS");
                    if (chk != null & chk.Checked)
                    {
                        idsds = GridView1.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    }
                }
                idsds = idsds.Trim(",".ToCharArray());
                if (idsds != "")
                {
                    SeguimientoDTO segDTO = new SeguimientoDTO();
                    segDTO.SDS = sdsBO.readById(Int32.Parse(idsds));
                    segDTO.Detalle = txtSeguimiento.Text;
                    segDTO.Nom_Usu_Seg = (string)Session["Username"];
                    var segBO = new SeguimientoBO();
                    
                    if (segBO.create(segDTO) != null)
                    {

                        Response.Write("<script language=javascript>alert('Seguimiento Insertado!');window.location='Default.aspx'</script>");

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al Agregar Seguimiento!');window.location='Default.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
                }
            }
            else
            {
                lblValidadorSeguimiento.Visible = true;
                lblSeguimiento.Visible = true;
                txtSeguimiento.Visible = true;
                btnAceptarSeg.Visible = true;
                btnCancelarSeg.Visible = true;
                lblValidadorSeguimiento.Text = "Este Campo no puede estar vacio";
            }

        }

        protected void btnCancelarSeg_Click(object sender, EventArgs e)
        {
            lblValidadorSeguimiento.Visible = false;
            lblSeguimiento.Visible = false;
            txtSeguimiento.Visible = false;
            btnAceptarSeg.Visible = false;
            btnCancelarSeg.Visible = false;
        }

        protected void btnDetalles2_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSAsig");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView2.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                Session["SDSSeg"] = idsds;
                Response.Redirect("~/DetalleSDS.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }
        }

        protected void btnDetalles3_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView3.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSProc");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView3.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                Session["SDSSeg"] = idsds;
                Response.Redirect("~/DetalleSDS.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }
        }

        protected void btnSeguimientoProc_Click(object sender, EventArgs e)
        {
            string idsds = string.Empty;
            foreach (GridViewRow gvrow in GridView3.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSProc");
                if (chk != null & chk.Checked)
                {
                    idsds = GridView3.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                }
            }
            idsds = idsds.Trim(",".ToCharArray());
            if (idsds != "")
            {
                lblValidadorSeguimientoProc.Visible = true;
                lblSeguimientoProc.Visible = true;
                txtSeguimientoProc.Visible = true;
                btnAceptarSegProc.Visible = true;
                btnCancelarSegProc.Visible = true;
            }
            else
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
            }

        }

        protected void btnAceptarSegProc_Click(object sender, EventArgs e)
        {
            if (txtSeguimientoProc.Text != "")
            {
                string idsds = string.Empty;
                foreach (GridViewRow gvrow in GridView3.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSProc");
                    if (chk != null & chk.Checked)
                    {
                        idsds = GridView3.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    }
                }
                idsds = idsds.Trim(",".ToCharArray());
                if (idsds != "")
                {
                    SeguimientoDTO segDTO = new SeguimientoDTO();
                    segDTO.SDS = sdsBO.readById(Int32.Parse(idsds));
                    segDTO.Detalle = txtSeguimientoProc.Text;
                    segDTO.Nom_Usu_Seg = (string)Session["Username"];
                    var segBO = new SeguimientoBO();
                   
                    if (segBO.create(segDTO) != null)
                    {

                        Response.Write("<script language=javascript>alert('Seguimiento Insertado!');window.location='Default.aspx'</script>");

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al Agregar Seguimiento!');window.location='Default.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe Seleccionar Una SDS');window.location='Default.aspx'</script>");
                }
            }
            else
            {
                lblValidadorSeguimientoProc.Visible = true;
                lblSeguimientoProc.Visible = true;
                txtSeguimientoProc.Visible = true;
                btnAceptarSegProc.Visible = true;
                btnCancelarSegProc.Visible = true;
                lblValidadorSeguimientoProc.Text = "Este Campo no puede estar vacio";
            }
        }

        protected void btnCancelarSegProc_Click(object sender, EventArgs e)
        {
            lblValidadorSeguimientoProc.Visible = false;
            lblSeguimientoProc.Visible = false;
            txtSeguimientoProc.Visible = false;
            btnAceptarSegProc.Visible = false;
            btnCancelarSegProc.Visible = false;
        }

        private void AgregarFechaCompromiso() {


            lblFecha.Text = Calendar1.SelectedDate.ToString();

            if ((DateTime.Parse(lblFecha.Text) <= DateTime.Now))
            {
                Response.Write("<script language=javascript>alert('Debe Seleccionar una fecha posterior a la de hoy!');window.location='Default.aspx'</script>");
            }
            else
            {
                string idsds = string.Empty;
                string asunto = string.Empty;
                string detalle = string.Empty;
                string fec_crea = string.Empty;
                string estado = string.Empty;
                DateTime? fec_cierre = null;
                string creador = string.Empty;
                string responsable = string.Empty;

                foreach (GridViewRow gvrow in GridView2.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSDSAsig");

                    if (chk != null & chk.Checked)
                    {
                        idsds = GridView2.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                        asunto = gvrow.Cells[2].Text;
                        fec_crea = gvrow.Cells[3].Text;
                        estado = gvrow.Cells[4].Text;
                        creador = gvrow.Cells[5].Text;
                        creador = System.Web.HttpUtility.HtmlDecode(creador);
                        responsable = (string)Session["Username"];
                    }
                }
                idsds = idsds.Trim(",".ToCharArray());
                SdsDTO sdsDTO = new SdsDTO();
                sdsDTO.IdSds = Int32.Parse(idsds);
                sdsDTO.Asunto = asunto;
                sdsDTO.Detalle = detalle;
                sdsDTO.Estado = ESTADOS.proceso;
                sdsDTO.Fec_Crea = DateTime.Parse(fec_crea);
                sdsDTO.Fec_Cierre = fec_cierre;
                sdsDTO.Fec_Comp = DateTime.Parse(Calendar1.SelectedDate.ToString());
                sdsDTO.Nom_Usu_Crea = creador;
                sdsDTO.Nom_Usu_Resp = responsable;
            

                if (sdsBO.update(sdsDTO) != null)
                {
                    SeguimientoDTO segDTO = new SeguimientoDTO();
                    segDTO.SDS = sdsBO.readById(Int32.Parse(idsds));
                    segDTO.Detalle = "Solicitud Aceptada.";
                    segDTO.Nom_Usu_Seg = (string)Session["Username"];
                    
                    if (segBO.create(segDTO) != null)
                    {

                        Response.Write("<script language=javascript>alert('Cambia estado SDS : EN PROCESO!');window.location='Default.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Error al Agregar Seguimiento!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al Cambiar Estado!');</script>");
                }
            }
        }

        private void ocultarControles() {

            lblFecha.Visible = false;
            lblCierre.Visible = false;
            txtCierre.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            lblValidador.Visible = false;
            lblRechazo.Visible = false;
            txtRechazo.Visible = false;
            btnAceptarRech.Visible = false;
            btnCancelarRech.Visible = false;
            lblValidadorRech.Visible = false;
            lblValidadorSeguimiento.Visible = false;
            lblSeguimiento.Visible = false;
            txtSeguimiento.Visible = false;
            btnAceptarSeg.Visible = false;
            btnCancelarSeg.Visible = false;
            lblValidadorSeguimientoProc.Visible = false;
            lblSeguimientoProc.Visible = false;
            txtSeguimientoProc.Visible = false;
            btnAceptarSegProc.Visible = false;
            btnCancelarSegProc.Visible = false;
        }

        private void llenarGridViews()
        {

            GridView1.DataSource = sdsBO.readAllsByCreatorUserAndState(userDTO.Username, (int)ESTADOS.abierta);
            GridView1.DataBind();

            GridView2.DataSource = sdsBO.readAllsByCreatorUserAndState(userDTO.Username, (int)ESTADOS.asignada);
            GridView2.DataBind();

            GridView3.DataSource = sdsBO.readAllsByCreatorUserAndState(userDTO.Username, (int)ESTADOS.proceso);
            GridView3.DataBind();

        }
    }
}