using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
using Persistencia.Interfaces;
using EntidadesCompartidas;

namespace Persistencia.Clases_de_trabajo
{
    internal class PersistenciaSolicitante : IPersistenciaSolicitante
    {
        private static PersistenciaSolicitante _instancia = null;
        private PersistenciaSolicitante() { }
        public static PersistenciaSolicitante getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaSolicitante();
            return _instancia;
        }

        public EntidadesCompartidas.Solicitante LoguearSoli(int documento, string contrasena)
        {
            SqlConnection conexion = null;
            SqlDataReader drSolicitante = null;
            Solicitante solicitante = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(documento, contrasena));
                SqlCommand cmdBuscarSolicitante = new SqlCommand("BuscarSolicitante", conexion);
                cmdBuscarSolicitante.CommandType = CommandType.StoredProcedure;

                cmdBuscarSolicitante.Parameters.AddWithValue("@documento", documento);

                conexion.Open();
                drSolicitante = cmdBuscarSolicitante.ExecuteReader();
                if (drSolicitante.Read())
                {
                    solicitante = new Solicitante((int)drSolicitante["documento"], (string)drSolicitante["contrasena"], (string)drSolicitante["nombreCompleto"], (int)drSolicitante["telefono"]);
                }
                return solicitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drSolicitante != null)
                {
                    drSolicitante.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public EntidadesCompartidas.Solicitante BuscarSolicitante(int documento, Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drSolicitante = null;
            Solicitante solicitante = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                SqlCommand cmdBuscarSolicitante = new SqlCommand("BuscarSolicitante", conexion);
                cmdBuscarSolicitante.CommandType = CommandType.StoredProcedure;

                cmdBuscarSolicitante.Parameters.AddWithValue("@documento", documento);

                conexion.Open();
                drSolicitante = cmdBuscarSolicitante.ExecuteReader();
                if (drSolicitante.Read())
                {
                    solicitante = new Solicitante((int)drSolicitante["documento"], (string)drSolicitante["contrasena"], (string)drSolicitante["nombreCompleto"], (int)drSolicitante["telefono"]);
                }
                return solicitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drSolicitante != null)
                {
                    drSolicitante.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void AltaSolicitante(Solicitante solicitante)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAltaSolicitante = new SqlCommand("AltaSolicitante", conexion);
                cmdAltaSolicitante.CommandType = CommandType.StoredProcedure;

                cmdAltaSolicitante.Parameters.AddWithValue("@documento", solicitante.Documento);
                cmdAltaSolicitante.Parameters.AddWithValue("@contrasena", solicitante.Contrasenia);
                cmdAltaSolicitante.Parameters.AddWithValue("@nombreCompleto", solicitante.NombreCompleto);
                cmdAltaSolicitante.Parameters.AddWithValue("@telefono", solicitante.Telefono);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaSolicitante.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAltaSolicitante.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El documento ya existe en el sistema.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al agregar el usuario.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al agregar el solicitante.");
                        break;
                    case -4:
                        throw new Exception("Ocurrió un error al agregar el usuario SQL.");
                        break;
                    case -5:
                        throw new Exception("Ocurrió un error al dar permisos de usuario.");
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
