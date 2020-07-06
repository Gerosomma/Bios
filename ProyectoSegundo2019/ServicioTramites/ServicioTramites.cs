using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using ServicioTramites.wcfTramite;

namespace ServicioTramites
{
    partial class ServicioTramites : ServiceBase
    {
        private int evento = 0;
        public ServicioTramites()
        {
            InitializeComponent();
            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("ServicioTramitesLog"))
            {
                System.Diagnostics.EventLog.CreateEventSource("ServicioTramitesLog", "TramitesLog");
            }
            eventLog.Source = "ServicioTramitesLog";
            eventLog.Log = "TramitesLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Inicio2 - Servicio  Tramites");
            Timer bucle = new Timer();
            bucle.Interval = 60000; // 60 seconds
            bucle.Elapsed += new ElapsedEventHandler(this.bucle_Tick);
            bucle.Start();
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Se detuvo - Servicio  Tramites");
        }

        protected override void OnPause()
        {
            eventLog.WriteEntry("Se pauso - Servicio  Tramites");
        }

        protected override void OnContinue()
        {
            eventLog.WriteEntry("Continua ejecucion - Servicio  Tramites");
        }

        public void bucle_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                string ruta = Path.Combine(@"~\Debug\XML\empleadoLogueado.xml");
                eventLog.WriteEntry("Monitoring the System", EventLogEntryType.Information, evento++);
                if (File.Exists(ruta))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(ruta);
                    string documento = "", inicio = "", fin = "", nombre = "", contrasenia = "";
                    XmlNodeList empleado = doc.GetElementsByTagName("EmpleadoLogueado");
                    eventLog.WriteEntry("Existe empleado logueado, leemos xml.");
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
                    Empleado emp = new Empleado();
                    emp.Documento = Convert.ToInt32(documento);
                    emp.Contrasenia = contrasenia;
                    emp.NombreCompleto = nombre;
                    emp.HoraInicio = inicio;
                    emp.HoraFin = fin;
                    DateTime ahora = DateTime.Now;
                    DateTime finTrabajo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(fin.Substring(3, 2)), Convert.ToInt32(fin.Substring(0, 2)), 0);
                    //calcular minutos extra.
                    int minutosExtra = Convert.ToInt32((ahora - finTrabajo).TotalMinutes);
                    eventLog.WriteEntry("Verifica si hay minutos extra.");
                    if (minutosExtra >= 1)
                    {
                        ServiceClient wcf = new ServiceClient();
                        EmpleadoHorasExtra horasExtra = new EmpleadoHorasExtra();
                        eventLog.WriteEntry("Ingreso minutos extra emp: " + emp.NombreCompleto + ", cant: " + minutosExtra.ToString());
                        horasExtra.Empleado = emp;
                        horasExtra.Fecha = ahora;
                        horasExtra.MinutosExtra = minutosExtra;
                        wcf.AltaHoraExtra(horasExtra, emp);
                        eventLog.WriteEntry("Se inserto horas extra", EventLogEntryType.SuccessAudit);
                    }

                }
                else
                {
                    eventLog.WriteEntry("No existe empleado logueado.");
                }

            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }
    }
}
