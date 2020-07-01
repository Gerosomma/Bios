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
        }
        else
        {
            lblMensaje.Text = usuario.Documento.ToString() + " - " + usuario.NombreCompleto;
        }
    }
}
