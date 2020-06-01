using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaDocumentacion
    {
        Documentacion BuscarDocumentacion(int codigoInterno);
        Documentacion BuscarDocumentacionAux(int codigoInterno, Empleado empLog);
        void AltaDocumentacion(Documentacion documentacion, Empleado empLog);
        void ModificarDocumentacion(Documentacion documentacion, Empleado empLog);
        void BajaDocumentacion(Documentacion documentacion, Empleado empLog);
        List<Documentacion> listadoDocumentacion(Empleado empLog);
    }
}
