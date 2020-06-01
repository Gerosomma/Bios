using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaSolicitante
    {
        Solicitante LoguearSoli(int documento, string contrasena);
        Solicitante BuscarSolicitante(int documento, Usuario usLog);
        void AltaSolicitante(Solicitante solicitante);
    }
}
