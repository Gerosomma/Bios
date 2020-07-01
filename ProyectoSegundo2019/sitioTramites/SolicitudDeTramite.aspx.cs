using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfTramite;


public partial class SolicitudDeTramite : System.Web.UI.Page
{
    ServiceClient wcf = new ServiceClient();
    Usuario usuarioLogueado = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)this.Master.FindControl("lblPagina")).Text = "Solicitud de Tramite";
        Response.CacheControl = "no-cache";
        usuarioLogueado = (Usuario)Session["Usuario"];

        if (usuarioLogueado == null || !(usuarioLogueado is Solicitante))
        {
            Session["Mensaje"] = "Acceso denegado, debe loguearse como usuario para solicitar tramites.";
            Response.Redirect("~/Logueo.aspx");
        }
        try
        {
            List<Tramite> tramites = new List<Tramite>();

            tramites = wcf.ListarTramites().ToList<Tramite>();
            gvTramites.DataSource = tramites;
            gvTramites.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnSolicitarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fecha = new DateTime();
            int hora = 0;

            if (calFecha.SelectedDate > DateTime.Today)
            {
                fecha = calFecha.SelectedDate;
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una fecha próxima al día de hoy.";
            }

            try
            {
                hora = Convert.ToInt32(ddlHora.SelectedValue);
            }
            catch (Exception)
            {
                lblMensaje.Text = "Debe seleccionar hora.";
            }

            DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, 0, 0);
            Tramite tramiteSeleccionado = wcf.BuscarTramite(gvTramites.SelectedValue.ToString(), usuarioLogueado);

            Solicitud solicitud = new Solicitud();
            Tramite tramite = new Tramite();
            List<Documentacion> listDoc = new List<Documentacion>();
            solicitud.Numero = 1;
            solicitud.Estado = "alta";
            solicitud.FechaHora = fechaHora;
            solicitud.Solicitante = (Solicitante)usuarioLogueado;
            tramite.CodigoTramite = tramiteSeleccionado.CodigoTramite;
            tramite.NombreTramite = tramiteSeleccionado.NombreTramite;
            tramite.Descripcion = tramiteSeleccionado.Descripcion;
            tramite.Precio = tramiteSeleccionado.Precio;
            tramite.DocumentacionExigida = tramiteSeleccionado.DocumentacionExigida;

            solicitud.Tramite = tramite;
            wcf.AltaSolicitud(solicitud, usuarioLogueado);

            lblMensaje.Text = "Solicitud realizada con éxito.";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}