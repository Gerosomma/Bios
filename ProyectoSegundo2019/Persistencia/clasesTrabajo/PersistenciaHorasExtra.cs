using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
using Persistencia.Interfaces;

namespace Persistencia.Clases_de_trabajo
{
    internal class PersistenciaHorasExtra : IPersistenciaHorasExtra
    {
        private static PersistenciaHorasExtra _instancia = null;
        private PersistenciaHorasExtra() { }
        public static PersistenciaHorasExtra getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaHorasExtra();
            return _instancia;
        }

        public void AltaHoraExtra(EmpleadoHorasExtra hemp, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdAltaSolicitante = new SqlCommand("AltaHoraExtra", conexion);
                cmdAltaSolicitante.CommandType = CommandType.StoredProcedure;

                cmdAltaSolicitante.Parameters.AddWithValue("@documentoEmpleado", hemp.Empleado.Documento);
                cmdAltaSolicitante.Parameters.AddWithValue("@fecha", hemp.Fecha);
                cmdAltaSolicitante.Parameters.AddWithValue("@minutosExtra", hemp.MinutosExtra);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaSolicitante.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAltaSolicitante.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("No existe empleado en sistema.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al agregar las horas extra del empleado.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al agregar las horas extra del empleado.");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }
}
