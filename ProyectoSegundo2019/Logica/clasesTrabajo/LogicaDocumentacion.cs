using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;
using Logica.Interfaces;

namespace Logica.ClaseTrabajo
{
    internal class LogicaDocumentacion : ILogicaDocumentacion
    {
        private static LogicaDocumentacion _instancia = null;
        private LogicaDocumentacion() { }
        public static LogicaDocumentacion GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaDocumentacion();
            }
            return _instancia;
        }

        public void AltaDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaDocumentacion().AltaDocumentacion(documentacion, empLog);
        }

        public void BajaDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaDocumentacion().BajaDocumentacion(documentacion, empLog);
        }

        public Documentacion BuscarDocumentacion(int codigoInterno)
        {
            return (FabricaPersistencia.GetPersistenciaDocumentacion().BuscarDocumentacion(codigoInterno));
        }

        public void ModificarDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaDocumentacion().ModificarDocumentacion(documentacion, empLog);
        }

        public List<Documentacion> listadoDocumentacion(Empleado empLog)
        {
            return FabricaPersistencia.GetPersistenciaDocumentacion().listadoDocumentacion(empLog);
        }

        public Documentacion BuscarDocumentacionAux(int codigoInterno, Empleado empLog)
        {
            return FabricaPersistencia.GetPersistenciaDocumentacion().BuscarDocumentacionAux(codigoInterno, empLog);
        }
    }
}
