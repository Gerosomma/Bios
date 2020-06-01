using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Clases_de_trabajo;
using Persistencia.Interfaces;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaDocumentacion GetPersistenciaDocumentacion()
        {
            return (PersistenciaDocumentacion.getInstancia());
        }

        public static IPersistenciaEmpleado GetPersistenciaEmpelado()
        {
            return (PersistenciaEmpleado.getInstancia());
        }

        public static IPersistenciaSolicitante GetPersistenciaSolicitante()
        {
            return (PersistenciaSolicitante.getInstancia());
        }

        public static IPersistenciaSolicitud GetPersistenciaSolicitud()
        {
            return (PersistenciaSolicitud.getInstancia());
        }

        public static IPersistenciaTramite GetPersistenciaTramite()
        {
            return (PersistenciaTramite.getInstancia());
        }

        public static IPersistenciaHorasExtra GetPersistenciaHorasExtra()
        {
            return (PersistenciaHorasExtra.getInstancia());
        }
    }
}
