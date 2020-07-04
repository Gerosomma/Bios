using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Xml;

namespace Logica
{
    public interface ILogicaTramite
    {
        Tramite BuscarTramite(string codigoTramite, Usuario empLog);
        Tramite BuscarTramiteAux(string codigoTramite, Usuario empLog);
        void AltaTramite(Tramite tramite, Empleado empLog);
        void ModificarTramite(Tramite tramite, Empleado empLog);
        void BajaTramite(Tramite tramite, Empleado empLog);
        List<Tramite> ListarTramites();
        string listadoTramitesXml();
    }
}
