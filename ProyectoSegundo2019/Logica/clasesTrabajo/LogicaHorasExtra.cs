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
    internal class LogicaHorasExtra : ILogicaHorasExtra
    {
        private static LogicaHorasExtra _instancia = null;
        private LogicaHorasExtra() { }
        public static LogicaHorasExtra GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaHorasExtra();
            }
            return _instancia;
        }

        public void AltaHoraExtra(EmpleadoHorasExtra hemp, Empleado empLog)
        {
            FabricaPersistencia.GetPersistenciaHorasExtra().AltaHoraExtra(hemp, empLog);
        }
    }
}
