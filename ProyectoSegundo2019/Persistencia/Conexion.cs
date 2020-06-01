using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Persistencia
{
    internal class Conexion
    {
        private static string cadenaConexion2 = "data source = .; initial catalog = ProyectoSegundo2019; Integrated Security = true;";
        private static string autenticacion = "data source = .; initial catalog = ProyectoSegundo2019;";

        public static string ObtenerCadenaConexion(int us, string pw)
        {
            return autenticacion + String.Format(" User Id={0}; Password={1};", us, pw);
        }

        public static string CadenaConexion
        {
            get { return cadenaConexion2; }
        }


    }
}
