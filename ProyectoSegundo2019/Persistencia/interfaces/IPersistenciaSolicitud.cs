using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaSolicitud
    {
        void AltaSolicitud(Solicitud solicitud, Usuario empLog);
        List<Solicitud> listadoSolicitud(Usuario usLog);
        Solicitud BuscarSolicitud(int documento, Usuario usLog);
        void CambiarEstadoSolicitud(int solicitud, int accion, Empleado usLog);
    }
}
