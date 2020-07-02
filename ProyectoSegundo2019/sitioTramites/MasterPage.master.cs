using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfTramite;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Usuario usuario = (Usuario)Session["Usuario"];
        if (usuario == null || !(usuario is Solicitante))
        {
            lblMensaje.Text = "Usuario desconectado";
            btnLogout.Visible = false;
        }
        else
        {
            lblMensaje.Text = usuario.Documento.ToString() + " - " + usuario.NombreCompleto;
            btnLogout.Visible = true;
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Usuario");
        Session.Remove("Mensaje");
        lblMensaje.Text = "Usuario desconectado";
        Response.Redirect("~/Default.aspx");
    }
}
