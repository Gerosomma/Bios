using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
using Persistencia.Interfaces;
using System.Xml;
using EntidadesCompartidas;

namespace Persistencia.Clases_de_trabajo
{
    internal class PersistenciaTramite : IPersistenciaTramite
    {
        private static PersistenciaTramite _instancia = null;
        private PersistenciaTramite() { }
        public static PersistenciaTramite getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaTramite();
            return _instancia;
        }

        public Tramite BuscarTramite(string codigoTramite, Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drTramite = null;
            Tramite tramite = null;
            List<Documentacion> documentacion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                SqlCommand cmdBuscarTramite = new SqlCommand("BuscarTramite", conexion);
                cmdBuscarTramite.CommandType = CommandType.StoredProcedure;

                cmdBuscarTramite.Parameters.AddWithValue("@codigoTramite", codigoTramite);

                conexion.Open();
                drTramite = cmdBuscarTramite.ExecuteReader();
                if (drTramite.Read())
                {
                    documentacion = PersistenciaExigen.getInstancia().listadoDocumentacionExigida((string)drTramite["codigoTramite"]);
                    tramite = new Tramite((string)drTramite["codigoTramite"], (string)drTramite["nombreTramite"], (string)drTramite["descripcion"], (decimal)drTramite["precio"], documentacion, (bool)drTramite["activo"]);
                }
                return tramite;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drTramite != null)
                {
                    drTramite.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public Tramite BuscarTramiteAux(string codigoTramite, Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drTramite = null;
            Tramite tramite = null;
            List<Documentacion> documentacion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                SqlCommand cmdBuscarTramite = new SqlCommand("BuscarTramiteAux", conexion);
                cmdBuscarTramite.CommandType = CommandType.StoredProcedure;

                cmdBuscarTramite.Parameters.AddWithValue("@codigoTramite", codigoTramite);

                conexion.Open();
                drTramite = cmdBuscarTramite.ExecuteReader();
                if (drTramite.Read())
                {
                    documentacion = PersistenciaExigen.getInstancia().listadoDocumentacionExigida((string)drTramite["codigoTramite"]);
                    tramite = new Tramite((string)drTramite["codigoTramite"], (string)drTramite["nombreTramite"], (string)drTramite["descripcion"], (decimal)drTramite["precio"], documentacion, (bool)drTramite["activo"]);
                }
                return tramite;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drTramite != null)
                {
                    drTramite.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public void AltaTramite(Tramite tramite, Empleado empLog)
        {
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdAltaTramite = new SqlCommand("AltaTramite", conexion);
                cmdAltaTramite.CommandType = CommandType.StoredProcedure;

                cmdAltaTramite.Parameters.AddWithValue("@codigoTramite", tramite.CodigoTramite);
                cmdAltaTramite.Parameters.AddWithValue("@nombreTramite", tramite.NombreTramite);
                cmdAltaTramite.Parameters.AddWithValue("@descripcion", tramite.Descripcion);
                cmdAltaTramite.Parameters.AddWithValue("@precio", tramite.Precio);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaTramite.Parameters.Add(valorRetorno);

                conexion.Open();

                transaccion = conexion.BeginTransaction();

                cmdAltaTramite.Transaction = transaccion;
                cmdAltaTramite.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El tipo de trámite ya existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al agregar el tipo de trámite.");
                        break;
                }

                foreach (Documentacion doc in tramite.DocumentacionExigida)
                {
                    PersistenciaExigen.AltaExigen(doc, tramite, transaccion);
                }

                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
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

        public void ModificarTramite(Tramite tramite, Empleado empLog)
        {
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdModificarTramite = new SqlCommand("ModificarTramite", conexion);
                cmdModificarTramite.CommandType = CommandType.StoredProcedure;

                cmdModificarTramite.Parameters.AddWithValue("@codigoTramite", tramite.CodigoTramite);
                cmdModificarTramite.Parameters.AddWithValue("@nombreTramite", tramite.NombreTramite);
                cmdModificarTramite.Parameters.AddWithValue("@descripcion", tramite.Descripcion);
                cmdModificarTramite.Parameters.AddWithValue("@precio", tramite.Precio);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarTramite.Parameters.Add(valorRetorno);

                conexion.Open();

                transaccion = conexion.BeginTransaction();

                cmdModificarTramite.Transaction = transaccion;
                cmdModificarTramite.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El tipo de trámite no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al modificar el tipo de trámite.");
                        break;
                }

                PersistenciaExigen.BajaExigen(tramite, transaccion);

                foreach (Documentacion doc in tramite.DocumentacionExigida)
                {
                    PersistenciaExigen.AltaExigen(doc, tramite, transaccion);
                }

                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
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

        public void BajaTramite(Tramite tramite, Empleado empLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(empLog.Documento, empLog.Contrasenia));

                SqlCommand cmdBajaTramite = new SqlCommand("BajaTramite", conexion);
                cmdBajaTramite.CommandType = CommandType.StoredProcedure;

                cmdBajaTramite.Parameters.AddWithValue("@codigoTramite", tramite.CodigoTramite);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBajaTramite.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdBajaTramite.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El tipo de trámite no existe.");
                        break;
                    case -2:
                        throw new Exception("Ocurrió un error al eliminar el tipo de trámite.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al eliminar el tipo de trámite.");
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


        public List<Tramite> ListarTramites()
        {
            SqlConnection conexion = null;
            SqlDataReader drTramite = null;
            Tramite tramite = null;
            List<Tramite> listaTramites = new List<Tramite>();
            List<Documentacion> documentacion = new List<Documentacion>();

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);
                SqlCommand cmdBuscarTramite = new SqlCommand("ListadoTramites", conexion);
                cmdBuscarTramite.CommandType = CommandType.StoredProcedure;


                conexion.Open();
                drTramite = cmdBuscarTramite.ExecuteReader();
                while (drTramite.Read())
                {
                    documentacion = PersistenciaExigen.getInstancia().listadoDocumentacionExigida((string)drTramite["codigoTramite"]);
                    tramite = new Tramite((string)drTramite["codigoTramite"], (string)drTramite["nombreTramite"], (string)drTramite["descripcion"], (decimal)drTramite["precio"], documentacion, (bool)drTramite["activo"]);
                    listaTramites.Add(tramite);
                }
                return listaTramites;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drTramite != null)
                {
                    drTramite.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public string listadoTramitesXml()
        {
            List<Tramite> listaTramites = new List<Tramite>();
            try
            {
                listaTramites = ListarTramites();

                XmlDocument doc = new XmlDocument();
                XmlElement elementoRaiz = doc.CreateElement(string.Empty, "Tramites", string.Empty);
                doc.AppendChild(elementoRaiz);

                foreach (Tramite med in listaTramites)
                {
                    XmlElement eTramite = doc.CreateElement(string.Empty, "Tramite", string.Empty);
                    elementoRaiz.AppendChild(eTramite);

                    XmlElement nodCodigo = doc.CreateElement(string.Empty, "codigo", string.Empty);
                    XmlText codigoTramite = doc.CreateTextNode(med.CodigoTramite);
                    nodCodigo.AppendChild(codigoTramite);
                    eTramite.AppendChild(nodCodigo);

                    XmlElement nodDescripcion = doc.CreateElement(string.Empty, "descripcion", string.Empty);
                    XmlText descripcion = doc.CreateTextNode(med.Descripcion);
                    nodDescripcion.AppendChild(descripcion);
                    eTramite.AppendChild(nodDescripcion);

                    XmlElement nodNombre = doc.CreateElement(string.Empty, "nombre", string.Empty);
                    XmlText nombre = doc.CreateTextNode(med.NombreTramite);
                    nodNombre.AppendChild(nombre);
                    eTramite.AppendChild(nodNombre);

                    XmlElement nodPrecio = doc.CreateElement(string.Empty, "precio", string.Empty);
                    XmlText precio = doc.CreateTextNode(med.Precio.ToString());
                    nodPrecio.AppendChild(precio);
                    eTramite.AppendChild(nodPrecio);

                    XmlElement eDocumentacionExigida = doc.CreateElement(string.Empty, "DocumentacionExigida", string.Empty);
                    eTramite.AppendChild(eDocumentacionExigida);

                    foreach (Documentacion d in med.DocumentacionExigida)
                    {
                        XmlElement eDocumentacion = doc.CreateElement(string.Empty, "Documento", string.Empty);
                        eDocumentacionExigida.AppendChild(eDocumentacion);

                        XmlElement nodCodigoDoc = doc.CreateElement(string.Empty, "codigo", string.Empty);
                        XmlText codDoc = doc.CreateTextNode(d.CodigoInterno.ToString());
                        nodCodigoDoc.AppendChild(codDoc);
                        eDocumentacion.AppendChild(nodCodigoDoc);

                        XmlElement nodNombreDoc = doc.CreateElement(string.Empty, "nombre", string.Empty);
                        XmlText nombreDoc = doc.CreateTextNode(d.NomDocumentacion);
                        nodNombreDoc.AppendChild(nombreDoc);
                        eDocumentacion.AppendChild(nodNombreDoc);

                        XmlElement nodLugarDoc = doc.CreateElement(string.Empty, "lugar", string.Empty);
                        XmlText lugarDoc = doc.CreateTextNode(d.NomDocumentacion);
                        nodLugarDoc.AppendChild(lugarDoc);
                        eDocumentacion.AppendChild(nodLugarDoc);
                    }
                }
                return doc.InnerXml;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

    }
}
