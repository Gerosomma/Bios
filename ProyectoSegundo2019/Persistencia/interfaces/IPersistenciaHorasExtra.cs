using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaHorasExtra
    {
        void AltaHoraExtra(EmpleadoHorasExtra hemp, Empleado empLog);
    }
}
