using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica.ClaseTrabajo
{
    internal class LogicaSolicitud : ILogicaSolicitud
    {
        private static LogicaSolicitud _instancia = null;
        private LogicaSolicitud() { }
        public static LogicaSolicitud GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaSolicitud();
            }
            return _instancia;
        }

        public void AltaSolicitud(Solicitud solicitud, Usuario empLog)
        {
            FabricaPersistencia.GetPersistenciaSolicitud().AltaSolicitud(solicitud, empLog);
        }

        public List<Solicitud> listadoSolicitud(Usuario usLog)
        {
            return FabricaPersistencia.GetPersistenciaSolicitud().listadoSolicitud(usLog);
        }

        public Solicitud BuscarSolicitud(int documento, Usuario usLog)
        {
            return FabricaPersistencia.GetPersistenciaSolicitud().BuscarSolicitud(documento, usLog);
        }

        public void CambiarEstadoSolicitud(int solicitud, int accion, Empleado usLog)
        {
            FabricaPersistencia.GetPersistenciaSolicitud().CambiarEstadoSolicitud(solicitud, accion, usLog);
        }
    }
}
