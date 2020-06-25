using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Logica;
using EntidadesCompartidas;
using System.Timers;
using System.IO;
using System.Xml;
namespace servicioWindows
{
    public partial class Service1 : ServiceBase
    {
        private int evento = 1;
        public Service1()
        {
            InitializeComponent();
            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog.Source = "MySource";
            eventLog.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Inicio winServiceTramites.");
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }
        protected override void OnStop()
        {
            eventLog.WriteEntry("Se paro winServiceTramites.");
        }

        protected override void OnContinue()
        {
            eventLog.WriteEntry("accion OnContinue.");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            string ruta = Path.Combine(@"~\Debug\XML\empleadoLogueado.xml");
            eventLog.WriteEntry("Monitoring the System", EventLogEntryType.Information, evento++);
            if (File.Exists(ruta))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(ruta);
                    string documento = "", inicio = "", fin = "", nombre = "", contrasenia = "";
                    XmlNodeList empleado = doc.GetElementsByTagName("EmpleadoLogueado");

                    foreach (XmlElement nodo in empleado)
                    {
                        XmlNodeList nDoc = nodo.GetElementsByTagName("Documento");
                        XmlNodeList nContrasena = nodo.GetElementsByTagName("Contrasenia");
                        XmlNodeList nNombre = nodo.GetElementsByTagName("Nombre");
                        XmlNodeList nInicio = nodo.GetElementsByTagName("Inicio");
                        XmlNodeList nFin = nodo.GetElementsByTagName("Fin");
                        documento = nDoc[0].InnerText;
                        contrasenia = nContrasena[0].InnerText;
                        nombre = nNombre[0].InnerText;
                        inicio = nInicio[0].InnerText;
                        fin = nFin[0].InnerText;
                    }
                    Empleado emp = new Empleado(Convert.ToInt32(documento), contrasenia, nombre, inicio, fin);

                    DateTime ahora = DateTime.Now;
                    DateTime finTrabajo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(fin.Substring(3, 2)), Convert.ToInt32(fin.Substring(0, 2)), 0);
                    //calcular minutos extra.
                    int minutosExtra = Convert.ToInt32((ahora - finTrabajo).TotalMinutes);

                    if (minutosExtra >= 1)
                    {
                        EmpleadoHorasExtra horasExtra = new EmpleadoHorasExtra(emp, ahora, minutosExtra);
                        FabricaLogica.GetLogicaHorasExtra().AltaHoraExtra(horasExtra, emp);
                        eventLog.WriteEntry("Se inserto horas extra", EventLogEntryType.SuccessAudit);
                    }
                }
                catch (Exception ex)
                {
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                }
            }

        }
    }
}
