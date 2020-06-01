using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

using Persistencia.Interfaces;

namespace Persistencia.Clases_de_trabajo
{
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        private static PersistenciaEmpleado _instancia = null;
        private PersistenciaEmpleado()
        {

        }
        public static PersistenciaEmpleado getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();
            return _instancia;
        }

        public Empleado LoguearEmpleado(int documento, string contrasena)
        {
            SqlConnection conexion = null;
            SqlDataReader drEmpleado = null;
            Empleado empleado = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(documento, contrasena));
                SqlCommand cmdBuscarEmpleado = new SqlCommand("BuscarEmpleado", conexion);
                cmdBuscarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdBuscarEmpleado.Parameters.AddWithValue("@documento", documento);

                conexion.Open();
                drEmpleado = cmdBuscarEmpleado.ExecuteReader();
                if (drEmpleado.Read())
                {
                    empleado = new Empleado((int)drEmpleado["documento"], (string)drEmpleado["contrasena"], (string)drEmpleado["nombreCompleto"], Convert.ToString((TimeSpan)drEmpleado["horaInicio"]), Convert.ToString((TimeSpan)drEmpleado["horaFin"]));
                }
                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drEmpleado != null)
                {
                    drEmpleado.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public Empleado BuscarEmpleado(int documento, Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drEmpleado = null;
            Empleado empleado = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                SqlCommand cmdBuscarEmpleado = new SqlCommand("BuscarEmpleado", conexion);
                cmdBuscarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdBuscarEmpleado.Parameters.AddWithValue("@documento", documento);

                conexion.Open();
                drEmpleado = cmdBuscarEmpleado.ExecuteReader();

                if (drEmpleado.Read())
                {
                    empleado = new Empleado((int)drEmpleado["documento"], (string)drEmpleado["contrasena"], (string)drEmpleado["nombreCompleto"], Convert.ToString((TimeSpan)drEmpleado["horaInicio"]), Convert.ToString((TimeSpan)drEmpleado["horaFin"]));
                }
                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drEmpleado != null)
                {
                    drEmpleado.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void AltaEmpleado(Empleado empleado, Usuario usLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                //conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAltaEmpleado = new SqlCommand("AltaEmpleado", conexion);
                cmdAltaEmpleado.CommandType = CommandType.StoredProcedure;

                cmdAltaEmpleado.Parameters.AddWithValue("@documento", empleado.Documento.ToString());
                cmdAltaEmpleado.Parameters.AddWithValue("@contrasena", empleado.Contrasenia);
                cmdAltaEmpleado.Parameters.AddWithValue("@nombreCompleto", empleado.NombreCompleto);
                cmdAltaEmpleado.Parameters.AddWithValue("@horaInicio", empleado.HoraInicio);
                cmdAltaEmpleado.Parameters.AddWithValue("@horaFin", empleado.HoraFin);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAltaEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El documento ya existe en el sistema.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al agregar el usuario.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al agregar el empleado.");
                        break;
                    case -4:
                        throw new Exception("Ocurrió un error al agregar el usuario SQL.");
                        break;
                    case -5:
                        throw new Exception("Ocurrió un error al crear usuario BD.");
                        break;
                    case -6:
                        throw new Exception("Error al conceder permiso de servidor.");
                        break;
                    case -7:
                        throw new Exception("Error al conceder permiso de BD 1.");
                        break;
                    case -8:
                        throw new Exception("Error al conceder permiso de BD 2.");
                        break;
                    case -9:
                        throw new Exception("Error al conceder rol de empleado.");
                        break;
                    case -10:
                        throw new Exception("Error al conceder rol de empleado.");
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

        public void ModificarEmpleado(Empleado empleado, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdModificarEmpleado = new SqlCommand("ModificarEmpleado", conexion);
                cmdModificarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdModificarEmpleado.Parameters.AddWithValue("@documento", empleado.Documento);
                cmdModificarEmpleado.Parameters.AddWithValue("@contrasena", empleado.Contrasenia);
                cmdModificarEmpleado.Parameters.AddWithValue("@nombreCompleto", empleado.NombreCompleto);
                cmdModificarEmpleado.Parameters.AddWithValue("@horaInicio", empleado.HoraInicio);
                cmdModificarEmpleado.Parameters.AddWithValue("@horaFin", empleado.HoraFin);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdModificarEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El empleado no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al modificar el usuario.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al modificar el empleado.");
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

        public void BajaEmpleado(Empleado empleado, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdBajaEmpleado = new SqlCommand("BajaEmpleado", conexion);
                cmdBajaEmpleado.CommandType = CommandType.StoredProcedure;

                cmdBajaEmpleado.Parameters.AddWithValue("@documento", empleado.Documento);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBajaEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBajaEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El empleado no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al eliminar el empleado.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al eliminar el usuario.");
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
