using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using EntidadesCompartidas;
using Logica;

public class Service : IService
{
    //necesario para q serialize los dos tipos de cuentas hacia el WS
    //public void ParaSerializar(Empleado emp, Solicitante soli, Tramite tram, Solicitud sol, Documentacion doc) { }
    ////necesario para q serialize el tipo de cuenta no usado directamente desde el WS
    //public Solicitante ParaSerializarsol() { return new Solicitante(); }
    //public Tramite serTramite() { return new Tramite(); }
    //public Solicitud serSoli() { return new Solicitud(); }
    //public Documentacion serDoc() { return new Documentacion(); }


    void IService.AltaDocumentacion(Documentacion documentacion, Empleado empLog)
    {
        FabricaLogica.GetLogicaDocumentacion().AltaDocumentacion(documentacion, empLog);
    }

    void IService.AltaSolicitud(Solicitud solicitud, Usuario usLog)
    {
        FabricaLogica.GetLogicaSolicitud().AltaSolicitud(solicitud, usLog);
    }

    void IService.AltaTramite(Tramite tramite, Empleado empLog)
    {
        FabricaLogica.GetLogicaTramite().AltaTramite(tramite, empLog);
    }

    void IService.AltaUsuario(Usuario usuario, Usuario usLog)
    {
        FabricaLogica.GetLogicaUsuario().AltaUsuario(usuario, usLog);
    }

    void IService.BajaDocumentacion(Documentacion documentacion, Empleado empLog)
    {
        FabricaLogica.GetLogicaDocumentacion().BajaDocumentacion(documentacion, empLog);
    }

    void IService.BajaTramite(Tramite tramite, Empleado empLog)
    {
        FabricaLogica.GetLogicaTramite().BajaTramite(tramite, empLog);
    }

    void IService.BajaUsuario(Usuario empleado, Empleado empLog)
    {
        FabricaLogica.GetLogicaUsuario().BajaUsuario(empleado, empLog);
    }

    Documentacion IService.BuscarDocumentacion(int codigoInterno)
    {
        Documentacion doc = FabricaLogica.GetLogicaDocumentacion().BuscarDocumentacion(codigoInterno);
        return doc;
    }

    Solicitud IService.BuscarSolicitud(int documento, Usuario usLog)
    {
        Solicitud sol = FabricaLogica.GetLogicaSolicitud().BuscarSolicitud(documento, usLog);
        return sol;
    }

    void IService.CambiarEstadoSolicitud(int solicitud, int accion, Empleado usLog)
    {
        FabricaLogica.GetLogicaSolicitud().CambiarEstadoSolicitud(solicitud, accion, usLog);
    }

    Tramite IService.BuscarTramite(string codigoTramite, Usuario empLog)
    {
        return FabricaLogica.GetLogicaTramite().BuscarTramite(codigoTramite, empLog);
    }

    Usuario IService.BuscarUsuario(int documento, Usuario usLog)
    {
        return FabricaLogica.GetLogicaUsuario().BuscarUsuario(documento, usLog);
    }

    string IService.GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    CompositeType IService.GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }

    List<Documentacion> IService.listadoDocumentacion(Empleado empLog)
    {
        return FabricaLogica.GetLogicaDocumentacion().listadoDocumentacion(empLog);
    }

    List<Solicitud> IService.listadoSolicitud(Usuario usLog)
    {
        return FabricaLogica.GetLogicaSolicitud().listadoSolicitud(usLog);
    }

    string IService.listadoTramitesXml()
    {
        return FabricaLogica.GetLogicaTramite().listadoTramitesXml();
    }

    List<Tramite> IService.ListarTramites()
    {
        return FabricaLogica.GetLogicaTramite().ListarTramites();
    }

    Usuario IService.LogueoUsuario(int documento, string contraseana)
    {
        return FabricaLogica.GetLogicaUsuario().LogueoUsuario(documento, contraseana);
    }

    void IService.ModificarDocumentacion(Documentacion documentacion, Empleado empLog)
    {
        FabricaLogica.GetLogicaDocumentacion().ModificarDocumentacion(documentacion, empLog);
    }

    void IService.ModificarTramite(Tramite tramite, Empleado empLog)
    {
        FabricaLogica.GetLogicaTramite().ModificarTramite(tramite, empLog);
    }

    void IService.ModificarUsuario(Usuario empleado, Empleado empLog)
    {
        FabricaLogica.GetLogicaUsuario().ModificarUsuario(empleado, empLog);
    }
    void IService.AltaHoraExtra(EmpleadoHorasExtra hemp, Empleado empLog)
    {
        FabricaLogica.GetLogicaHorasExtra().AltaHoraExtra(hemp, empLog);
    }
}