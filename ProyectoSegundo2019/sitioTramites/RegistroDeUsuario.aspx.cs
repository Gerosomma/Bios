using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfTramite;

public partial class RegistroDeUsuario : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)this.Master.FindControl("lblPagina")).Text = "Registro de usuario";
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Solicitante nuevoSolicitante;
        try
        {
            int documento = Convert.ToInt32(txtDocumento.Text);
            string contrasena = txtContrasenia.Text;
            string nombre = txtNombre.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);

            nuevoSolicitante = new Solicitante();
            nuevoSolicitante.Documento = documento;
            nuevoSolicitante.Contrasenia = contrasena;
            nuevoSolicitante.NombreCompleto = nombre;
            nuevoSolicitante.Telefono = telefono;

            ServiceClient wcf = new ServiceClient();
            wcf.AltaUsuario(nuevoSolicitante, null);

            lblError.Text = "Registro realizado con éxito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}