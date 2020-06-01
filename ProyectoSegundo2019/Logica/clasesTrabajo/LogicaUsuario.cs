using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuario : ILogicaUsuario
    {
        private static LogicaUsuario _instancia = null;
        private LogicaUsuario() { }
        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaUsuario();
            }
            return _instancia;
        }

        public Usuario LogueoUsuario(int documento, string contraseana)
        {
            Usuario usuario = FabricaPersistencia.GetPersistenciaEmpelado().LoguearEmpleado(documento, contraseana);

            if (usuario == null)
            {
                usuario = FabricaPersistencia.GetPersistenciaSolicitante().LoguearSoli(documento, contraseana);
            }

            if (usuario.Contrasenia != contraseana)
                throw new Exception("Contraseña invalida, o usuario incorrecto");

            return usuario;
        }

        public Usuario BuscarUsuario(int documento, Usuario usLog)
        {
            Usuario usuario = FabricaPersistencia.GetPersistenciaEmpelado().BuscarEmpleado(documento, usLog);

            if (usuario == null)
            {
                usuario = FabricaPersistencia.GetPersistenciaSolicitante().BuscarSolicitante(documento, usLog);
            }

            return usuario;
        }

        public void AltaUsuario(Usuario usuario, Usuario usLog)
        {
            if (usuario is Empleado)
            {
                FabricaPersistencia.GetPersistenciaEmpelado().AltaEmpleado((Empleado)usuario, usLog);
            }
            else if (usuario is Solicitante)
            {
                FabricaPersistencia.GetPersistenciaSolicitante().AltaSolicitante((Solicitante)usuario);
            }
        }

        public void ModificarUsuario(Usuario usuario, Empleado empLog)
        {
            if (usuario is Empleado)
            {
                FabricaPersistencia.GetPersistenciaEmpelado().ModificarEmpleado((Empleado)usuario, empLog);
            }
            else if (usuario is Solicitante)
            {
                throw new Exception("El usuario no es un empleado.");
            }
        }

        public void BajaUsuario(Usuario usuario, Empleado empLog)
        {
            if (usuario is Empleado)
            {
                FabricaPersistencia.GetPersistenciaEmpelado().BajaEmpleado((Empleado)usuario, empLog);
            }
            else if (usuario is Solicitante)
            {
                throw new Exception("El usuario no es un empleado.");
            }
        }
    }
}
