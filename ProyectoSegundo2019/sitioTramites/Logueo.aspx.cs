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
        Session["Usuario"] = null;
    }

    protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            int _Usu = Convert.ToInt32(controlLog.UserName.Trim());
            string _Pass = controlLog.Password.Trim();

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
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}