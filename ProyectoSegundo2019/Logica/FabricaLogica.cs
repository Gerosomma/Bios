using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.ClaseTrabajo;
using Logica.Interfaces;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaDocumentacion GetLogicaDocumentacion()
        {
            return (LogicaDocumentacion.GetInstancia());
        }

        public static ILogicaUsuario GetLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());
        }

        public static ILogicaSolicitud GetLogicaSolicitud()
        {
            return (LogicaSolicitud.GetInstancia());
        }

        public static ILogicaTramite GetLogicaTramite()
        {
            return (LogicaTramite.GetInstancia());
        }

        public static ILogicaHorasExtra GetLogicaHorasExtra()
        {
            return (LogicaHorasExtra.GetInstancia());
        }
    }
}
