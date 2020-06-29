using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using wcfTramite;

public partial class ConsultaTramite : System.Web.UI.Page
{
    ServiceClient wcf = new ServiceClient();
    static string documento = "";
    static XmlDocument doc = new XmlDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)this.Master.FindControl("lblPagina")).Text = "Listado de Tramites activos";

        if (!IsPostBack)
        {
            try
            {
                documento = wcf.listadoTramitesXml();
                doc.LoadXml(documento);

                XElement element = XElement.Parse(doc.OuterXml);
                var res = (from node in element.Elements("Tramite")
                           select new
                           {
                               Nombre = node.Elements("nombre").First().Value
                           }).ToList();

                rpTramites.DataSource = res;
                rpTramites.DataBind();

                if (doc == null)
                {
                    lblMensaje.Text = "No hay trámites disponibles";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }

    protected void rpTramites_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Seleccionar")
        {
            string tramite = ((Label)(e.Item.Controls[1])).Text;
            doc.LoadXml(documento);

            XElement element = XElement.Parse(doc.OuterXml);
            var resultado = (from item in element.Elements("Tramite")
                             where (string)item.Element("nombre") == tramite
                             select item);

            string _resultado = "";
            foreach (var unNodo in resultado)
            {
                _resultado += unNodo.ToString();
            }

            Xml1.DocumentContent = _resultado;
        }

        if (e.CommandName == "Filtrar")
        {
            try
            {
                int anio = Convert.ToInt32(((DropDownList)(e.Item.FindControl("ddlAnio"))).SelectedValue);
                decimal precio = Convert.ToDecimal(((DropDownList)(e.Item.FindControl("ddlPrecioMax"))).SelectedValue);
                doc.LoadXml(documento);

                XElement element = XElement.Parse(doc.OuterXml);
                var res = (from node in element.Elements("Tramite")
                           where Convert.ToInt32(((string)(node.Element("codigo"))).Substring(0, 3)) <= anio &&
                                 (decimal)node.Element("precio") <= precio
                           select new
                           {
                               Nombre = node.Elements("nombre").First().Value
                           }).ToList();

                rpTramites.DataSource = res;
                rpTramites.DataBind();

                if (doc == null)
                {
                    lblMensaje.Text = "No hay trámites disponibles";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}