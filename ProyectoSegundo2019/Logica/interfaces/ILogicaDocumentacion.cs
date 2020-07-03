using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaDocumentacion
    {
        Documentacion BuscarDocumentacion(int codigoInterno);
        Documentacion BuscarDocumentacionAux(int codigoInterno);
        void AltaDocumentacion(Documentacion documentacion, Empleado empLog);
        void ModificarDocumentacion(Documentacion documentacion, Empleado empLog);
        void BajaDocumentacion(Documentacion documentacion, Empleado empLog);
        List<Documentacion> listadoDocumentacion(Empleado empLog);
    }
}
