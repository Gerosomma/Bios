using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;
using System.Xml;

namespace Logica.ClaseTrabajo
{
    internal class LogicaTramite : ILogicaTramite
    {
        private static LogicaTramite _instancia = null;
        private LogicaTramite() { }
        public static LogicaTramite GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaTramite();
            }
            return _instancia;
        }

        public void AltaTramite(Tramite tramite, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaTramite().AltaTramite(tramite, empLog);
        }

        public void BajaTramite(Tramite tramite, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaTramite().BajaTramite(tramite, empLog);
        }

        public Tramite BuscarTramite(string codigoTramite, Usuario empLog)
        {
            return FabricaPersistencia.GetPersistenciaTramite().BuscarTramite(codigoTramite, empLog);
        }

        public Tramite BuscarTramiteAux(string codigoTramite, Usuario empLog)
        {
            return FabricaPersistencia.GetPersistenciaTramite().BuscarTramiteAux(codigoTramite, empLog);
        }

        public void ModificarTramite(Tramite tramite, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaTramite().ModificarTramite(tramite, empLog);
        }

        public List<Tramite> ListarTramites()
        {
            return FabricaPersistencia.GetPersistenciaTramite().ListarTramites();
        }

        public string listadoTramitesXml()
        {
            return FabricaPersistencia.GetPersistenciaTramite().listadoTramitesXml();
        }
    }
}
