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
    internal class PersistenciaSolicitud : IPersistenciaSolicitud
    {
        private static PersistenciaSolicitud _instancia = null;
        private PersistenciaSolicitud() { }
        public static PersistenciaSolicitud getInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaSolicitud();
            return _instancia;
        }

        public void AltaSolicitud(Solicitud solicitud, Usuario usLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));

                SqlCommand cmdAltaSolicitud = new SqlCommand("AltaSolicitud", conexion);
                cmdAltaSolicitud.CommandType = CommandType.StoredProcedure;

                cmdAltaSolicitud.Parameters.AddWithValue("@estado", solicitud.Estado);
                cmdAltaSolicitud.Parameters.AddWithValue("@fechaHora", solicitud.FechaHora);
                cmdAltaSolicitud.Parameters.AddWithValue("@docSolicitante", solicitud.Solicitante.Documento);
                cmdAltaSolicitud.Parameters.AddWithValue("@codTramite", solicitud.Tramite.CodigoTramite);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAltaSolicitud.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAltaSolicitud.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("El Solicitante no existe.");
                        break;
                    case -2:
                        throw new Exception("El trámite no existe.");
                        break;
                    case -3:
                        throw new Exception("Ocurrió un error al agregar la solicitud.");
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

        public Solicitud BuscarSolicitud(int documento, Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drSolicitud = null;
            Solicitud solicitud = null;
            Solicitante solicitante = null;
            Tramite tramite = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));
                SqlCommand cmdBuscarSolicitante = new SqlCommand("BuscarSolicitud", conexion);
                cmdBuscarSolicitante.CommandType = CommandType.StoredProcedure;

                cmdBuscarSolicitante.Parameters.AddWithValue("@numero", documento);

                conexion.Open();
                drSolicitud = cmdBuscarSolicitante.ExecuteReader();
                if (drSolicitud.Read())
                {
                    solicitante = PersistenciaSolicitante.getInstancia().BuscarSolicitante((int)drSolicitud["docSolicitante"], usLog);
                    tramite = PersistenciaTramite.getInstancia().BuscarTramite((string)drSolicitud["codTramite"], usLog);
                    solicitud = new Solicitud((int)drSolicitud["numero"], (string)drSolicitud["estado"], (DateTime)drSolicitud["fechaHora"], solicitante, tramite);
                }
                return solicitud;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (drSolicitud != null)
                {
                    drSolicitud.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void CambiarEstadoSolicitud(int solicitud, int accion, Empleado usLog)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));

                SqlCommand cmdCambioEstadoSolicitud = new SqlCommand("CambioEstadoSolicitud", conexion);
                cmdCambioEstadoSolicitud.CommandType = CommandType.StoredProcedure;

                cmdCambioEstadoSolicitud.Parameters.AddWithValue("@numero", solicitud);
                cmdCambioEstadoSolicitud.Parameters.AddWithValue("@accion", accion);


                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdCambioEstadoSolicitud.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdCambioEstadoSolicitud.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new Exception("Ocurrió un error al ralizar el cambio de estado.");
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

        public List<Solicitud> listadoSolicitud(Usuario usLog)
        {
            SqlConnection conexion = null;
            SqlDataReader drSolicitud = null;

            List<Solicitud> listaSolicitud = new List<Solicitud>();
            Solicitud solicitud = null;
            Solicitante solicitante = null;
            Tramite tramite = null;
            Documentacion documentacion = null;
            List<Documentacion> documentaciones = new List<Documentacion>();

            try
            {
                conexion = new SqlConnection(Conexion.ObtenerCadenaConexion(usLog.Documento, usLog.Contrasenia));

                SqlCommand cmdBajaDocumentacion = new SqlCommand("ListadoSolicitudes", conexion);
                cmdBajaDocumentacion.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                drSolicitud = cmdBajaDocumentacion.ExecuteReader();
                while (drSolicitud.Read())
                {
                    tramite = PersistenciaTramite.getInstancia().BuscarTramite((string)drSolicitud["codigoTramite"], usLog);
                    solicitante = PersistenciaSolicitante.getInstancia().BuscarSolicitante((int)drSolicitud["documento"], usLog);
                    solicitud = new Solicitud((int)drSolicitud["numero"], (string)drSolicitud["estado"], (DateTime)drSolicitud["fechaHora"], solicitante, tramite);
                    listaSolicitud.Add(solicitud);
                }
                return listaSolicitud;
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



        //va a ser necesario
        //public string xmlMedicamentos()
        //{
        //    List<Medicamento> listaMedicamentos = new List<Medicamento>();
        //    try
        //    {
        //        Empleado ususario = PersistenciaEmpleado.GetInstancia().LoguearEmpleado("web", "1995");
        //        if (ususario != null)
        //        {
        //            listaMedicamentos = ConsultaMedicamento(ususario);

        //            XmlDocument doc = new XmlDocument();
        //            XmlElement elementoRaiz = doc.CreateElement(string.Empty, "Medicamentos", string.Empty);
        //            doc.AppendChild(elementoRaiz);

        //            foreach (Medicamento med in listaMedicamentos)
        //            {
        //                XmlElement elementoMedicamento = doc.CreateElement(string.Empty, "Medicamento", string.Empty);
        //                elementoRaiz.AppendChild(elementoMedicamento);

        //                XmlElement elementoNombreFabricante = doc.CreateElement(string.Empty, "Fabricante", string.Empty);
        //                XmlText nombreFabricante = doc.CreateTextNode(med.Fabricante.Nombre.ToString());
        //                elementoNombreFabricante.AppendChild(nombreFabricante);
        //                elementoMedicamento.AppendChild(elementoNombreFabricante);

        //                XmlElement elementoDireccionFabricante = doc.CreateElement(string.Empty, "DireccionFabricante", string.Empty);
        //                XmlText direccionFarmaceutica = doc.CreateTextNode(med.Fabricante.DireccionFiscal.ToString());
        //                elementoDireccionFabricante.AppendChild(direccionFarmaceutica);
        //                elementoMedicamento.AppendChild(elementoDireccionFabricante);

        //                XmlElement elementoTelefono = doc.CreateElement(string.Empty, "Telefono", string.Empty);
        //                XmlText telefonoFarmaceutica = doc.CreateTextNode(med.Fabricante.Telefono.ToString());
        //                elementoTelefono.AppendChild(telefonoFarmaceutica);
        //                elementoMedicamento.AppendChild(elementoTelefono);

        //                XmlElement elementoEmail = doc.CreateElement(string.Empty, "Email", string.Empty);
        //                XmlText emailFarmaceutica = doc.CreateTextNode(med.Fabricante.CorreoElectronico.ToString());
        //                elementoEmail.AppendChild(emailFarmaceutica);
        //                elementoMedicamento.AppendChild(elementoEmail);

        //                XmlElement elementoCodigo = doc.CreateElement(string.Empty, "Codigo", string.Empty);
        //                XmlText codigoMedicamento = doc.CreateTextNode(med.Codigo.ToString());
        //                elementoCodigo.AppendChild(codigoMedicamento);
        //                elementoMedicamento.AppendChild(elementoCodigo);

        //                XmlElement elementoNombreMedicamento = doc.CreateElement(string.Empty, "Nombre", string.Empty);
        //                XmlText nombreMedicamento = doc.CreateTextNode(med.Nombre.ToString());
        //                elementoNombreMedicamento.AppendChild(nombreMedicamento);
        //                elementoMedicamento.AppendChild(elementoNombreMedicamento);

        //                XmlElement elementoDescripcion = doc.CreateElement(string.Empty, "Descripcion", string.Empty);
        //                XmlText descripcionMedicamento = doc.CreateTextNode(med.Descripcion.ToString());
        //                elementoDescripcion.AppendChild(descripcionMedicamento);
        //                elementoMedicamento.AppendChild(elementoDescripcion);

        //                XmlElement elementoTipo = doc.CreateElement(string.Empty, "Tipo", string.Empty);
        //                XmlText tipoMedicamento = doc.CreateTextNode(med.Tipo.ToString());
        //                elementoTipo.AppendChild(tipoMedicamento);
        //                elementoMedicamento.AppendChild(elementoTipo);

        //                XmlElement elementoPrecio = doc.CreateElement(string.Empty, "Precio", string.Empty);
        //                XmlText precioMedicamento = doc.CreateTextNode(med.Precio.ToString());
        //                elementoPrecio.AppendChild(precioMedicamento);
        //                elementoMedicamento.AppendChild(elementoPrecio);

        //                XmlElement elementoStock = doc.CreateElement(string.Empty, "StockActual", string.Empty);
        //                XmlText stockActual = doc.CreateTextNode(med.StockActual.ToString());
        //                elementoStock.AppendChild(stockActual);
        //                elementoMedicamento.AppendChild(elementoStock);
        //            }
        //            return doc.InnerXml;
        //        }
        //        else
        //        {
        //            throw new Exception("Error: no existe usuario");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error: " + ex.Message);
        //    }
        //}
    }
}
