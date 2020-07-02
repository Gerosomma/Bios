using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfTramite;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario us = (Usuario)Session["Usuario"];
        ((Label)this.Master.FindControl("lblPagina")).Text = "Acceso de usuario";
        if (us != null)
        {
            lblError.Text = "Usted ya esta logueado con el documento: " + us.Documento;
            btnLog.Enabled = false;
        }
        else
        {
            lblError.Text = (String)Session["Mensaje"];
            btnLog.Enabled = true;
        }
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        try
        {
            int _Usu = Convert.ToInt32(txtDocumento.Text.Trim());
            string _Pass = txtContrasena.Text;

            ServiceClient wcf = new ServiceClient();
            Solicitante _unCliente = (Solicitante)wcf.LogueoUsuario(_Usu, _Pass);

            if (_unCliente == null)
            {
                lblError.Text = "Usuario o Pass Invalidos";
            }
            else
            {
                Session["Usuario"] = _unCliente;
                Response.Redirect("~/SolicitudDeTramite.aspx");
            }
        }
        catch (FormatException)
        {
            lblError.Text = "Documento invalido.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}