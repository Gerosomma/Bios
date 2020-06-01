using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaEmpleado
    {
        Empleado LoguearEmpleado(int documento, string contrasena);
        Empleado BuscarEmpleado(int documento, Usuario usLog);
        void AltaEmpleado(Empleado empleado, Usuario usLog);
        void ModificarEmpleado(Empleado empleado, Empleado empLog);
        void BajaEmpleado(Empleado empleado, Empleado empLog);
    }
}
