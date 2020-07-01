using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)this.Master.FindControl("lblPagina")).Text = "Página principal";
        Response.CacheControl = "no-cache";

        string mensaje = (string)Session["Mensaje"];

        if (mensaje != null)
        {
            lblError.Text = mensaje;

            Session.Remove("Mensaje");
        }
    }
}