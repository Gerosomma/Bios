using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaUsuario
    {
        Usuario LogueoUsuario(int documento, string contraseana);
        Usuario BuscarUsuario(int documento, Usuario usLog);
        void AltaUsuario(Usuario usuario, Usuario usLog);
        void ModificarUsuario(Usuario empleado, Empleado empLog);
        void BajaUsuario(Usuario empleado, Empleado empLog);
    }
}
