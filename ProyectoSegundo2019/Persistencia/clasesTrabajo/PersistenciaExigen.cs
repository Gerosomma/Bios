using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases_de_trabajo
{
    internal class PersistenciaExigen
    {
        private static PersistenciaExigen _instancia = null;
        private PersistenciaExigen() { }
        public static PersistenciaExigen getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaExigen();
            return _instancia;
        }

        internal static void AltaExigen(Documentacion documentacion, Tramite tramite, SqlTransaction transaccion)
        {
            try
            {
                SqlCommand cmdAltaExigen = new SqlCommand("AltaExigen", transaccion.Connection);
                cmdAltaExigen.CommandType = CommandType.StoredProcedure;
                cmdAltaExigen.Parameters.AddWithValue("@codTramite", tramite.CodigoTramite);
                cmdAltaExigen.Parameters.AddWithValue("@codDocumentacion", documentacion.CodigoInterno);
                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaExigen.Parameters.Add(valorRetorno);


                cmdAltaExigen.Transaction = transaccion;
                cmdAltaExigen.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                    throw new Exception("Ocurrió un error al realizar el alta.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void BajaExigen(Tramite tramite, SqlTransaction transaccion)
        {
            try
            {
                SqlCommand cmdBajaExigen = new SqlCommand("BajaExigen", transaccion.Connection);
                cmdBajaExigen.CommandType = CommandType.StoredProcedure;
                cmdBajaExigen.Parameters.AddWithValue("@codTramite", tramite.CodigoTramite);
                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBajaExigen.Parameters.Add(valorRetorno);


                cmdBajaExigen.Transaction = transaccion;
                cmdBajaExigen.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("La fila no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al realizar la baja.");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal List<Documentacion> listadoDocumentacionExigida(string codigoTramite)
        {
            SqlConnection conexion = null;
            SqlDataReader drRelacion = null;
            List<Documentacion> listaDocumentacion = new List<Documentacion>();
            Documentacion doc = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdLisDocumentosTramite = new SqlCommand("BuscarDocumentacionTramite", conexion);
                cmdLisDocumentosTramite.CommandType = CommandType.StoredProcedure;

                cmdLisDocumentosTramite.Parameters.AddWithValue("@codigoTramite", codigoTramite);

                conexion.Open();
                drRelacion = cmdLisDocumentosTramite.ExecuteReader();
                while (drRelacion.Read())
                {
                    doc = PersistenciaDocumentacion.getInstancia().BuscarDocumentacion((int)drRelacion["codDocumentacion"]);
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
