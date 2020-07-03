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
    internal class PersistenciaDocumentacion : IPersistenciaDocumentacion
    {
        //singleton
        private static PersistenciaDocumentacion _instancia = null;
        private PersistenciaDocumentacion() { }
        public static PersistenciaDocumentacion getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaDocumentacion();
            return _instancia;
        }

        public Documentacion BuscarDocumentacion(int codigoInterno)
        {
            SqlConnection conexion = null;
            SqlDataReader drDocumentacion = null;
            Documentacion documentacion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);
                SqlCommand cmdBuscarDocumentacion = new SqlCommand("BuscarDocumentacion", conexion);
                cmdBuscarDocumentacion.CommandType = CommandType.StoredProcedure;

                cmdBuscarDocumentacion.Parameters.AddWithValue("@codigoInterno", codigoInterno);

                conexion.Open();
                drDocumentacion = cmdBuscarDocumentacion.ExecuteReader();
                if (drDocumentacion.Read())
                {
                    documentacion = new Documentacion((int)drDocumentacion["codigoInterno"], (string)drDocumentacion["nomDocumentacion"], (string)drDocumentacion["lugar"], (bool)drDocumentacion["activo"]);
                }
                return documentacion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drDocumentacion != null)
                {
                    drDocumentacion.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public Documentacion BuscarDocumentacionAux(int codigoInterno)
        {
            SqlConnection conexion = null;
            SqlDataReader drDocumentacion = null;
            Documentacion documentacion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);
                SqlCommand cmdBuscarDocumentacion = new SqlCommand("BuscarDocumentacionAux", conexion);
                cmdBuscarDocumentacion.CommandType = CommandType.StoredProcedure;

                cmdBuscarDocumentacion.Parameters.AddWithValue("@codigoInterno", codigoInterno);

                conexion.Open();
                drDocumentacion = cmdBuscarDocumentacion.ExecuteReader();
                if (drDocumentacion.Read())
                {
                    documentacion = new Documentacion((int)drDocumentacion["codigoInterno"], (string)drDocumentacion["nomDocumentacion"], (string)drDocumentacion["lugar"], (bool)drDocumentacion["activo"]);
                }
                return documentacion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drDocumentacion != null)
                {
                    drDocumentacion.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void AltaDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdAltaDocumentacion = new SqlCommand("AltaDocumentacion", conexion);
                cmdAltaDocumentacion.CommandType = CommandType.StoredProcedure;

                cmdAltaDocumentacion.Parameters.AddWithValue("@codigoInterno", documentacion.CodigoInterno);
                cmdAltaDocumentacion.Parameters.AddWithValue("@nomDocumentacion", documentacion.NomDocumentacion);
                cmdAltaDocumentacion.Parameters.AddWithValue("@lugar", documentacion.Lugar);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaDocumentacion.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAltaDocumentacion.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El código interno ya existe en el sistema.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al agregar la documentacón.");
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

        public void ModificarDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdModificarDocumentacion = new SqlCommand("ModificarDocumentacion", conexion);
                cmdModificarDocumentacion.CommandType = CommandType.StoredProcedure;

                cmdModificarDocumentacion.Parameters.AddWithValue("@codigoInterno", documentacion.CodigoInterno);
                cmdModificarDocumentacion.Parameters.AddWithValue("@nomDocumentacion", documentacion.NomDocumentacion);
                cmdModificarDocumentacion.Parameters.AddWithValue("@lugar", documentacion.Lugar);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarDocumentacion.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdModificarDocumentacion.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("La documentacón no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al modificar la documentacón.");
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

        public void BajaDocumentacion(Documentacion documentacion, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdBajaDocumentacion = new SqlCommand("BajaDocumentacion", conexion);
                cmdBajaDocumentacion.CommandType = CommandType.StoredProcedure;

                cmdBajaDocumentacion.Parameters.AddWithValue("@codigoInterno", documentacion.CodigoInterno);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBajaDocumentacion.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBajaDocumentacion.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("La documentacón no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al eliminar la documentacón.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al eliminar la documentacón.");
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

        public List<Documentacion> listadoDocumentacion(Empleado empLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drDocumentacion = null;
            List<Documentacion> listaDocumentacion = new List<Documentacion>();
            Documentacion doc = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdBajaDocumentacion = new SqlCommand("ListadoDocumentacion", conexion);
                cmdBajaDocumentacion.CommandType = CommandType.StoredProcedure;


                conexion.Open();
                drDocumentacion = cmdBajaDocumentacion.ExecuteReader();
                while (drDocumentacion.Read())
                {
                    doc = new Documentacion((int)drDocumentacion["codigoInterno"], (string)drDocumentacion["nomDocumentacion"], (string)drDocumentacion["lugar"], (bool)drDocumentacion["activo"]);
                    listaDocumentacion.Add(doc);
                }
                return listaDocumentacion;
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
